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
    public class ProductCategoriesController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/ProductCategories/Index.cshtml", db.ProductCategorys.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadProductCategorys([DataSourceRequest]DataSourceRequest request, string productCategoryCode, string productCategoryName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<ProductCategory> productCategorys = db.ProductCategorys;
                if (!string.IsNullOrEmpty(productCategoryName))
                {
                    productCategorys = productCategorys.Where(p => p.ProductCategoryName.StartsWith(productCategoryName));
                }
                if (!string.IsNullOrEmpty(productCategoryCode))
                {
                    productCategorys = productCategorys.Where(p => p.ProductCategoryCode.StartsWith(productCategoryCode));
                }
                DataSourceResult result = productCategorys.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //public ActionResult CreateProductCategory([DataSourceRequest]DataSourceRequest request, ProductCategory productCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new ProductCategory()
        //            {
        //                ProductCategoryId = productCategory.ProductCategoryId,
        //                ProductCategoryName = productCategory.ProductCategoryName,
        //                ProductCategoryCode = productCategory.ProductCategoryCode,
        //            };
        //            db.ProductCategorys.Add(entity);
        //            db.SaveChanges();
        //            productCategory.ProductCategoryId = entity.ProductCategoryId;
        //        }
        //    }
        //    return Json(new[] { productCategory }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult UpdateProductCategory([DataSourceRequest]DataSourceRequest request, ProductCategory productCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            db.ProductCategorys.Attach(productCategory);
        //            db.Entry(productCategory).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { productCategory }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult DestroyProductCategory([DataSourceRequest]DataSourceRequest request, ProductCategory productCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new ProductCategory
        //            {
        //                ProductCategoryId = productCategory.ProductCategoryId,
        //            };
        //            db.ProductCategorys.Attach(entity);
        //            db.ProductCategorys.Remove(entity);
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { productCategory }.ToDataSourceResult(request, ModelState));
        //}
        [Authorize(Roles = "administrator")]
        public ActionResult ProductCategoryDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProductCategory productCategory = db.ProductCategorys.Find(id);
                if (productCategory == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/ProductCategories/ProductCategoryDetails.cshtml", productCategory);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateProductCategoryView()
        {
            var item = new ProductCategory();
            return View("~/Views/Catalogs/ProductCategories/ProductCategoryTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveProductCategory(ProductCategory productCategory)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (productCategory.ProductCategoryId == 0)
                    {
                        var entity = new ProductCategory
                        {
                            ProductCategoryId = productCategory.ProductCategoryId,
                            ProductCategoryCode = productCategory.ProductCategoryCode,
                            ProductCategoryName = productCategory.ProductCategoryName

                        };
                        db.ProductCategorys.Add(entity);
                    }
                    else
                    {
                        ProductCategory item = db.ProductCategorys.Find(productCategory.ProductCategoryId);
                        item.ProductCategoryId = productCategory.ProductCategoryId;
                        item.ProductCategoryCode = productCategory.ProductCategoryCode;
                        item.ProductCategoryName = productCategory.ProductCategoryName;
                        db.ProductCategorys.Attach(item);
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
        public ActionResult OpenUpdateProductCategoryView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ProductCategory item = db.ProductCategorys.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/ProductCategories/ProductCategoryTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteProductCategory(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ProductCategory item = db.ProductCategorys.Find(id);
                    db.ProductCategorys.Attach(item);
                    db.ProductCategorys.Remove(item);
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
