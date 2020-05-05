//using System;
//using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
//using System.Web;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;

namespace Medicaldrugstore.Controllers
{
    public class ProductTypesController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/ProductTypes/Index.cshtml", db.ProductTypes.ToList());
            }
        }

        [Authorize(Roles = "administrator")]
        public ActionResult ReadProductTypes([DataSourceRequest]DataSourceRequest request, string productTypeCode, string productTypeName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<ProductType> producttypes = db.ProductTypes;
                if (!string.IsNullOrEmpty(productTypeName))
                {
                    producttypes = producttypes.Where(p => p.ProductTypeName.StartsWith(productTypeName));
                }
                if (!string.IsNullOrEmpty(productTypeCode))
                {
                    producttypes = producttypes.Where(p => p.ProductTypeCode.StartsWith(productTypeCode));
                }
                DataSourceResult result = producttypes.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //public ActionResult CreateProductType([DataSourceRequest]DataSourceRequest request, ProductType productType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new ProductType()
        //            {
        //                ProductTypeId = productType.ProductTypeId,
        //                ProductTypeName = productType.ProductTypeName,
        //                ProductTypeCode = productType.ProductTypeCode,
        //            };
        //            db.ProductTypes.Add(entity);
        //            db.SaveChanges();
        //            productType.ProductTypeId = entity.ProductTypeId;
        //        }
        //    }
        //    return Json(new[] { productType }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult UpdateProductType([DataSourceRequest]DataSourceRequest request, ProductType productType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            db.ProductTypes.Attach(productType);
        //            db.Entry(productType).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { productType }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult DestroyProductType([DataSourceRequest]DataSourceRequest request, ProductType productType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new ProductType
        //            {
        //                ProductTypeId = productType.ProductTypeId,
        //            };
        //            db.ProductTypes.Attach(entity);
        //            db.ProductTypes.Remove(entity);
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { productType }.ToDataSourceResult(request, ModelState));
        //}
        [Authorize(Roles = "administrator")]
        public ActionResult ProductTypeDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProductType productType = db.ProductTypes.Find(id);
                if (productType == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/ProductTypes/ProductTypeDetails.cshtml", productType);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateProductTypeView()
        {
            var item = new ProductType();
            return View("~/Views/Catalogs/ProductTypes/ProductTypeTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveProductType(ProductType productType)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (productType.ProductTypeId == 0)
                    {
                        var entity = new ProductType
                        {
                            ProductTypeId = productType.ProductTypeId,
                            ProductTypeCode = productType.ProductTypeCode,
                            ProductTypeName = productType.ProductTypeName

                        };
                        db.ProductTypes.Add(entity);
                    }
                    else
                    {
                        ProductType item = db.ProductTypes.Find(productType.ProductTypeId);
                        item.ProductTypeId = productType.ProductTypeId;
                        item.ProductTypeCode = productType.ProductTypeCode;
                        item.ProductTypeName = productType.ProductTypeName;
                        db.ProductTypes.Attach(item);
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
        public ActionResult OpenUpdateProductTypeView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ProductType item = db.ProductTypes.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/ProductTypes/ProductTypeTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteProductType(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ProductType item = db.ProductTypes.Find(id);
                    db.ProductTypes.Attach(item);
                    db.ProductTypes.Remove(item);
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
