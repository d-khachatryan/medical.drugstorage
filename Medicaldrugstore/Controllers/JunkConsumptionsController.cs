using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Collections.Generic;
using System;
using System.IO;
using Medicaldrugstore.Helpers;
using Microsoft.AspNet.Identity;

namespace Medicaldrugstore.Controllers
{
    public class JunkConsumptionsController : Controller
    {
        readonly string userId;

        public JunkConsumptionsController()
        {
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
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

                List<ProductList> products = db.Database.SqlQuery<ProductList>("spReplacementProducts").ToList();
                var lProducts = new List<SelectListItem>();
                lProducts = products.Select(x => new SelectListItem { Text = x.ProductName, Value = x.ProductId.ToString() }).ToList();
                ViewBag.vbProducts = lProducts;
            }
            return View();
        }

        
        public JsonResult GetOrganizations()
        {
            using (var db = new StoreContext())
            {
                var organizationHelper = new OrganizationHelper();
                return Json(organizationHelper.StorageOrganizations(userId, db).Select(c => new { OrganizationId = c.Value, OrganizationName = c.Text }), JsonRequestBehavior.AllowGet);
            }
        }
    
        public JsonResult GetProducts()
        {
            using (var db = new StoreContext())
            {
                List<ProductList> products = db.Database.SqlQuery<ProductList>("spReplacementProducts").ToList();
                return Json(products.Select(c => new { ProductId = c.ProductId, ProductName = c.ProductName }), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetJunkBases()
        {
            using (var db = new StoreContext())
            {
                IQueryable<JunkBase> junkBases = db.JunkBases.AsQueryable();
                return Json(junkBases.ToList().Select(c => new { JunkBaseId = c.JunkBaseId, JunkBaseName = c.JunkBaseName }), JsonRequestBehavior.AllowGet);
            }
        }


        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadJunkConsumptions([DataSourceRequest]DataSourceRequest request, string startDate, string terminationDate, string organizationId, string productId)
        {
            using (var db = new StoreContext())
            {

                IQueryable<JunkConsumptionDetail> items = db.JunkConsumptionDetails;

                if (startDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startDate);
                    items = items.Where(p => p.JunkConsumptionDate >= dt);
                }

                if (terminationDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startDate);
                    items = items.Where(p => p.JunkConsumptionDate <= dt);
                }

                if (!string.IsNullOrEmpty(organizationId))
                {
                    int id = Convert.ToInt32(organizationId);
                    items = items.Where(p => p.OrganizationId == id);
                }

                if (!string.IsNullOrEmpty(productId))
                {
                    int id = Convert.ToInt32(productId);
                    items = items.Where(p => p.ProductId == id);
                }

                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult JunkConsumptionTemplate(int? junkConsumptionId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (junkConsumptionId == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    var item = new JunkConsumptionTemplate();

                    if (junkConsumptionId != 0)
                    {
                        JunkConsumption junkConsumption = db.JunkConsumptions.Find(junkConsumptionId);
                        item.JunkConsumptionId = junkConsumption.JunkConsumptionId;
                        item.OrganizationId = junkConsumption.OrganizationId;
                        item.ProductId = junkConsumption.ProductId;
                        item.JunkConsumptionDate = junkConsumption.JunkConsumptionDate;
                        item.Quantity = junkConsumption.Quantity;
                        item.JunkBaseId = junkConsumption.JunkBaseId;
                    }

                    if (item == null)
                    {
                        throw new HttpException(404, "Not found");
                    }
                    else
                    {
                        return View("JunkConsumptionTemplate", item);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "JunkConsumption", "JunkConsumptionTemplate"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult SaveJunkConsumption(JunkConsumptionTemplate junkConsumptionTemplate)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new StoreContext())
                {
                    var calculationHelper = new CalculationHelper(junkConsumptionTemplate.ProductId, junkConsumptionTemplate.Quantity);

                    if (junkConsumptionTemplate.JunkConsumptionId == 0)
                    {
                        var item = new JunkConsumption();
                        item.JunkConsumptionId = junkConsumptionTemplate.JunkConsumptionId;
                        item.OrganizationId = junkConsumptionTemplate.OrganizationId;
                        item.ProductId = junkConsumptionTemplate.ProductId;
                        item.JunkConsumptionDate = junkConsumptionTemplate.JunkConsumptionDate;
                        item.Quantity = junkConsumptionTemplate.Quantity;
                        item.JunkBaseId = junkConsumptionTemplate.JunkBaseId;
                        item.JunkConsumptionStatusId = null;
                        item.ItemQuantity = calculationHelper.ItemQuantity;
                        item.TotalCost = calculationHelper.TotalCost;
                        item.UnitCost = calculationHelper.UnitCost;
                        db.JunkConsumptions.Add(item);
                    }
                    else
                    {
                        JunkConsumption item = db.JunkConsumptions.Find(junkConsumptionTemplate.JunkConsumptionId);

                        //If JunkProductStatus is set then this record can not be changed
                        if (item.JunkConsumptionStatusId != null)
                        {
                            ModelState.AddModelError("JunkConsumptionStatusNull", "JunkConsumptionStatus can not be null");
                            return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                        }

                        item.JunkConsumptionId = junkConsumptionTemplate.JunkConsumptionId;
                        item.OrganizationId = junkConsumptionTemplate.OrganizationId;
                        item.ProductId = junkConsumptionTemplate.ProductId;
                        item.JunkConsumptionDate = junkConsumptionTemplate.JunkConsumptionDate;
                        item.Quantity = junkConsumptionTemplate.Quantity;
                        item.JunkBaseId = junkConsumptionTemplate.JunkBaseId;
                        item.ItemQuantity = calculationHelper.ItemQuantity;
                        item.TotalCost = calculationHelper.TotalCost;
                        item.UnitCost = calculationHelper.UnitCost;
                        db.JunkConsumptions.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
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
        public ActionResult DeleteJunkConsumption([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new JunkConsumption()
                        {
                            JunkConsumptionId = Convert.ToInt32(id),
                        };
                        db.JunkConsumptions.Attach(item);
                        db.JunkConsumptions.Remove(item);
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
        public ActionResult JunkConsumptionDetails([DataSourceRequest]DataSourceRequest request, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                var details = new JunkConsumptionDetail();
                details = db.JunkConsumptionDetails.Find(id);
                if (details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("JunkConsumptionDetail", details);
                }
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult RepresentJunkConsumption(string junkConsumptionId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    JunkConsumption item = db.JunkConsumptions.Find(Convert.ToInt32(junkConsumptionId));
                    item.JunkConsumptionStatusId = 1;
                    db.JunkConsumptions.Attach(item);
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
    }

}