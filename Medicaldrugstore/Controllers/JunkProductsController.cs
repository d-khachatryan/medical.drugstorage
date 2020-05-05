using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Helpers;
using Medicaldrugstore.Models;
using Microsoft.AspNet.Identity;

namespace Medicaldrugstore.Controllers
{

    public class JunkProductsController : Controller
    {
        readonly string userId;

        public JunkProductsController()
        {
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }

        public JunkProductsController(string uId)
        {
            userId = uId;
        }

        [Authorize(Roles = "storagerole")]
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

        public ActionResult GetStorages([DataSourceRequest]DataSourceRequest request, string id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<Storage> storages = db.Storages.AsQueryable();

                if (!String.IsNullOrEmpty(id))
                {
                    int organizationId = Convert.ToInt32(id);
                    storages = storages.Where(p => p.OrganizationId == organizationId);
                }

                return Json(storages.ToList().Select(p => new { StorageId = p.StorageId, StorageName = p.StorageName }), JsonRequestBehavior.AllowGet);
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
                return Json(junkBases.ToList ().Select(c => new { JunkBaseId = c.JunkBaseId, JunkBaseName = c.JunkBaseName }), JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadJunkProducts([DataSourceRequest]DataSourceRequest request, string startDate, string terminationDate, string organizationId, string productId)
        {
            using (var db = new StoreContext())
            {

                IQueryable<JunkProductDetail> items = db.JunkProductDetails;

                if (startDate != "")
                {
                    DateTime dts = Convert.ToDateTime(startDate);
                    items = items.Where(p => p.JunkProductDate >= dts);
                }

                if (terminationDate != "")
                {
                    DateTime dtt = Convert.ToDateTime(terminationDate);
                    items = items.Where(p => p.JunkProductDate <= dtt);
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

        [Authorize(Roles = "storagerole")]
        public ActionResult JunkProductTemplate(int? junkProductId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (junkProductId == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    var item = new JunkProductTemplate();

                    if (junkProductId != 0)
                    {
                        JunkProduct junkProduct = db.JunkProducts.Find(junkProductId);
                        item.JunkProductId = junkProduct.JunkProductId;
                        item.OrganizationId = junkProduct.OrganizationId;
                        item.ProductId = junkProduct.ProductId;
                        item.JunkProductDate = junkProduct.JunkProductDate;
                        item.StorageId = junkProduct.StorageId;
                        item.Quantity = junkProduct.Quantity;
                        item.JunkBaseId = junkProduct.JunkBaseId;
                    }

                    if (item == null)
                    {
                        throw new HttpException(404, "Not found");
                    }
                    else
                    {
                        return View("JunkProductTemplate", item);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "JunkProduct", "JunkProductTemplate"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult SaveJunkProduct(JunkProductTemplate junkProductTemplate)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new StoreContext())
                {
                    var calculationHelper = new CalculationHelper(junkProductTemplate.ProductId, junkProductTemplate.Quantity);

                    if (junkProductTemplate.JunkProductId == 0)
                    {
                        var item = new JunkProduct();
                        item.JunkProductId = junkProductTemplate.JunkProductId;
                        item.OrganizationId = junkProductTemplate.OrganizationId;
                        item.ProductId = junkProductTemplate.ProductId;
                        item.JunkProductDate = junkProductTemplate.JunkProductDate;
                        item.StorageId = junkProductTemplate.StorageId;
                        item.Quantity = junkProductTemplate.Quantity;
                        item.JunkBaseId = junkProductTemplate.JunkBaseId;
                        item.JunkProductStatusId = null;
                        item.ItemQuantity = calculationHelper.ItemQuantity;
                        item.TotalCost = calculationHelper.TotalCost;
                        item.UnitCost = calculationHelper.UnitCost;
                        db.JunkProducts.Add(item);
                    }
                    else
                    {
                        JunkProduct item = db.JunkProducts.Find(junkProductTemplate.JunkProductId);

                        //If JunkProductStatus is set then this record can not be changed
                        if (item.JunkProductStatusId != null)
                        {
                            ModelState.AddModelError("JunkProductStatusNull", "JunkProductStatus can not be null");
                            return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                        }

                        item.JunkProductId = junkProductTemplate.JunkProductId;
                        item.OrganizationId = junkProductTemplate.OrganizationId;
                        item.ProductId = junkProductTemplate.ProductId;
                        item.JunkProductDate = junkProductTemplate.JunkProductDate;
                        item.StorageId = junkProductTemplate.StorageId;
                        item.Quantity = junkProductTemplate.Quantity;
                        item.JunkBaseId = junkProductTemplate.JunkBaseId;
                        item.ItemQuantity = calculationHelper.ItemQuantity;
                        item.TotalCost = calculationHelper.TotalCost;
                        item.UnitCost = calculationHelper.UnitCost;
                        db.JunkProducts.Attach(item);
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

        [Authorize(Roles = "storagerole")]
        public ActionResult DeleteJunkProduct([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new JunkProduct()
                        {
                            JunkProductId = Convert.ToInt32(id),
                        };
                        db.JunkProducts.Attach(item);
                        db.JunkProducts.Remove(item);
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

        [Authorize(Roles = "storagerole")]
        public ActionResult JunkProductDetail([DataSourceRequest]DataSourceRequest request, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                var details = new JunkProductDetail();
                details = db.JunkProductDetails.Find(id);
                if (details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("JunkProductDetail", details);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult RepresentJunkProduct(string junkProductId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    JunkProduct item = db.JunkProducts.Find(Convert.ToInt32(junkProductId));
                    item.JunkProductStatusId = 1;
                    db.JunkProducts.Attach(item);
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