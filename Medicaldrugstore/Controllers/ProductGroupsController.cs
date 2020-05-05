using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Medicaldrugstore.Controllers
{
    public class ProductGroupsController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/ProductGroups/Index.cshtml", db.ProductGroups.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadProductGroups([DataSourceRequest]DataSourceRequest request, string productGroupCode, string productGroupName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<ProductGroup> productGroups = db.ProductGroups;
                if (!string.IsNullOrEmpty(productGroupName))
                {
                    productGroups = productGroups.Where(p => p.ProductGroupName.StartsWith(productGroupName));
                }
                if (!string.IsNullOrEmpty(productGroupCode))
                {
                    productGroups = productGroups.Where(p => p.ProductGroupCode.StartsWith(productGroupCode));
                }
                DataSourceResult result = productGroups.ToDataSourceResult(request);
                return Json(result);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult CreateProductGroup([DataSourceRequest]DataSourceRequest request, ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new ProductGroup()
                    {
                        ProductGroupId = productGroup.ProductGroupId,
                        ProductGroupName = productGroup.ProductGroupName,
                        ProductGroupCode = productGroup.ProductGroupCode,
                    };
                    db.ProductGroups.Add(entity);
                    db.SaveChanges();
                    productGroup.ProductGroupId = entity.ProductGroupId;
                }
            }
            return Json(new[] { productGroup }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "administrator")]
        public ActionResult UpdateProductGroup([DataSourceRequest]DataSourceRequest request, ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    db.ProductGroups.Attach(productGroup);
                    db.Entry(productGroup).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(new[] { productGroup }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DestroyProductGroup([DataSourceRequest]DataSourceRequest request, ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new ProductGroup
                    {
                        ProductGroupId = productGroup.ProductGroupId,
                    };
                    db.ProductGroups.Attach(entity);
                    db.ProductGroups.Remove(entity);
                    db.SaveChanges();
                }
            }
            return Json(new[] { productGroup }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ProductGroupDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProductGroup productGroup = db.ProductGroups.Find(id);
                if (productGroup == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/ProductGroups/ProductGroupDetails.cshtml", productGroup);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateProductGroupView()
        {
            var item = new ProductGroup();
            return View("~/Views/Catalogs/ProductGroups/ProductGroupTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveProductGroup(ProductGroup productGroup)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (productGroup.ProductGroupId == 0)
                    {
                        var entity = new ProductGroup
                        {
                            ProductGroupId = productGroup.ProductGroupId,
                            ProductGroupCode = productGroup.ProductGroupCode,
                            ProductGroupName = productGroup.ProductGroupName

                        };
                        db.ProductGroups.Add(entity);
                    }
                    else
                    {
                        ProductGroup item = db.ProductGroups.Find(productGroup.ProductGroupId);
                        item.ProductGroupId = productGroup.ProductGroupId;
                        item.ProductGroupCode = productGroup.ProductGroupCode;
                        item.ProductGroupName = productGroup.ProductGroupName;
                        db.ProductGroups.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenUpdateProductGroupView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ProductGroup item = db.ProductGroups.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/ProductGroups/ProductGroupTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteProductGroup(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ProductGroup item = db.ProductGroups.Find(id);
                    db.ProductGroups.Attach(item);
                    db.ProductGroups.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
