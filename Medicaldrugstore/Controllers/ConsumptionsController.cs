using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using Medicaldrugstore.Helpers;
using System.Web;

namespace Medicaldrugstore.Controllers
{
    public class ConsumptionsController : Controller
    {
        readonly string userId;

        public ConsumptionsController()
        {
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }

        public ConsumptionsController(string uId)
        {
            this.userId = uId;
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                //Select only the organization rows accesible for the curent user 
                var organizationHelper = new OrganizationHelper();
                List<SelectListItem> lOrganizations = organizationHelper.StorageOrganizations(userId, db);
                ViewBag.vbOrganizations = lOrganizations;

                var lConsumptionStatuses = new List<SelectListItem>();
                lConsumptionStatuses = db.ConsumptionStatuses.Select(x => new SelectListItem { Text = x.ConsumptionStatusName, Value = x.ConsumptionStatusId.ToString() }).ToList();
                ViewBag.vbConsumptionStatuses = lConsumptionStatuses;
            }
            return View();
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadConsumptions([DataSourceRequest]DataSourceRequest request, string organizationId, string startDate, string terminationDate, string consumptionStatusId)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ConsumptionDetail> items = db.ConsumptionDetails;

                if (!string.IsNullOrEmpty(organizationId))
                {
                    int id = Convert.ToInt32(organizationId);
                    items = items.Where(p => p.OrganizationId == id);
                }

                if (startDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startDate);
                    items = items.Where(p => p.ConsumptionDate >= dt);
                }
                if (terminationDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationDate);
                    items = items.Where(p => p.ConsumptionDate <= dt);
                }
                if (consumptionStatusId != "")
                {
                    int id = Convert.ToInt32(consumptionStatusId);
                    items = items.Where(p => p.ConsumptionStatusId == id);
                }
                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public JsonResult GetOrganizations()
        {
            using (var db = new StoreContext())
            {
                var organizationHelper = new OrganizationHelper();
                return Json(organizationHelper.StorageOrganizations(userId, db).Select(c => new { OrganizationId = c.Value, OrganizationName = c.Text }), JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ConsumptionTemplate(int? consumptionId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (consumptionId == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    List<ProductList> products = db.Database.SqlQuery<ProductList>("spReplacementProducts").ToList();
                    var lProducts = new List<SelectListItem>();
                    lProducts = products.Select(x => new SelectListItem { Text = x.ProductName, Value = x.ProductId.ToString() }).ToList();
                    ViewBag.vbProducts = lProducts;

                    var item = new ConsumptionTemplate();

                    if (consumptionId != 0)
                    {
                        Consumption consumption = db.Consumptions.Find(consumptionId);
                        item.ConsumptionId = consumption.ConsumptionId;
                        item.ConsumptionDate = consumption.ConsumptionDate;
                        item.TerminationDate = consumption.TerminationDate;
                        item.OrganizationId = consumption.OrganizationId;
                    }

                    if (item == null)
                    {
                        throw new HttpException(404, "Not found");
                    }
                    else
                    {
                        return View("ConsumptionTemplate", item);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Consumption", "ConsumptionTemplate"));
            }
        }


        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult SaveConsumption(ConsumptionTemplate consumptionTemplate)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new StoreContext())
                {


                    if (consumptionTemplate.ConsumptionId == 0)
                    {
                        var item = new Consumption();
                        item.ConsumptionId = consumptionTemplate.ConsumptionId;
                        item.ConsumptionDate = consumptionTemplate.ConsumptionDate;
                        item.TerminationDate = consumptionTemplate.TerminationDate;
                        item.OrganizationId = consumptionTemplate.OrganizationId;
                        db.Consumptions.Add(item);

                        //Subtable
                        if (consumptionTemplate.ConsumptionProducts != null)
                        {
                            foreach (var itm in consumptionTemplate.ConsumptionProducts)
                            {
                                if (itm.RecordStatus == 1)
                                {
                                    var consumptionProduct = new ConsumptionProduct();
                                    var calculationHelper = new CalculationHelper(itm.ProductId, itm.Quantity);
                                    consumptionProduct.Consumption = item;
                                    consumptionProduct.ProductId = itm.ProductId;
                                    consumptionProduct.Quantity = itm.Quantity;
                                    consumptionProduct.ItemQuantity = calculationHelper.ItemQuantity;
                                    consumptionProduct.TotalCost = calculationHelper.TotalCost;
                                    consumptionProduct.UnitCost = calculationHelper.UnitCost;
                                    db.ConsumptionProducts.Add(consumptionProduct);
                                }
                            }
                        }
                    }
                    else
                    {
                        Consumption item = db.Consumptions.Find(consumptionTemplate.ConsumptionId);

                        //If JunkProductStatus is set then this record can not be changed
                        if (item.ConsumptionStatusId != null)
                        {
                            ModelState.AddModelError("ConsumptionStatusNull", "ConsumptionStatus can not be null");
                            return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                        }

                        item.ConsumptionId = consumptionTemplate.ConsumptionId;
                        item.ConsumptionDate = consumptionTemplate.ConsumptionDate;
                        item.TerminationDate = consumptionTemplate.TerminationDate;
                        item.OrganizationId = consumptionTemplate.OrganizationId;
                        db.Consumptions.Attach(item);
                        db.Entry(item).State = EntityState.Modified;


                        //Subtable
                        if (consumptionTemplate.ConsumptionProducts != null)
                        {
                            foreach (var itm in consumptionTemplate.ConsumptionProducts)
                            {
                                if (itm.RecordStatus == 1)
                                {
                                    var consumptionProduct = new ConsumptionProduct();
                                    var calculationHelper = new CalculationHelper(itm.ProductId, itm.Quantity);
                                    consumptionProduct.Consumption = item;
                                    consumptionProduct.ProductId = itm.ProductId;
                                    consumptionProduct.Quantity = itm.Quantity;
                                    consumptionProduct.ItemQuantity = calculationHelper.ItemQuantity;
                                    consumptionProduct.TotalCost = calculationHelper.TotalCost;
                                    consumptionProduct.UnitCost = calculationHelper.UnitCost;
                                    db.ConsumptionProducts.Add(consumptionProduct);
                                }
                                else if (itm.RecordStatus == 2)
                                {
                                    ConsumptionProduct consumptionProduct = db.ConsumptionProducts.Find(itm.ConsumptionProductId);
                                    var calculationHelper = new CalculationHelper(itm.ProductId, itm.Quantity);
                                    consumptionProduct.ProductId = itm.ProductId;
                                    consumptionProduct.Quantity = itm.Quantity;
                                    consumptionProduct.ItemQuantity = calculationHelper.ItemQuantity;
                                    consumptionProduct.TotalCost = calculationHelper.TotalCost;
                                    consumptionProduct.UnitCost = calculationHelper.UnitCost;
                                    db.ConsumptionProducts.Attach(consumptionProduct);
                                    db.Entry(consumptionProduct).State = EntityState.Modified;
                                }
                                else if (itm.RecordStatus == 3)
                                {
                                    ConsumptionProduct consumptionProduct = db.ConsumptionProducts.Find(itm.ConsumptionProductId);
                                    db.ConsumptionProducts.Remove(consumptionProduct);
                                }
                            }
                        }


                    }

                    db.SaveChanges();
                    return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult RepresentConsumption(string consumptionId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Consumption item = db.Consumptions.Find(Convert.ToInt32(consumptionId));
                    item.ConsumptionStatusId = 1;
                    db.Consumptions.Attach(item);
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult DeleteConsumption(int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Consumption()
                        {
                            ConsumptionId = Convert.ToInt32(id),
                        };
                        db.Consumptions.Attach(item);
                        db.Consumptions.Remove(item);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ConsumptionDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                var details = new ConsumptionDetail();
                details = db.ConsumptionDetails.Find(id);
                if (details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("ConsumptionDetail", details);
                }
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadConsumptionProductDetails([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ConsumptionProductDetail> consumptionProducts = db.ConsumptionProductDetails.Where(p => p.ConsumptionId == id);
                DataSourceResult result = consumptionProducts.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadConsumptionProducts([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ConsumptionProduct> consumptionProducts = db.ConsumptionProducts.Where(p => p.ConsumptionId == id);
                DataSourceResult result = consumptionProducts.ToDataSourceResult(request);
                return Json(result);
            }
        }

    }
}
