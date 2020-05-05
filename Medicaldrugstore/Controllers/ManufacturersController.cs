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
//using PagedList;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;

namespace Medicaldrugstore.Controllers
{
    public class ManufacturersController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/Manufacturers/Index.cshtml", db.Manufacturers.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadManufacturers([DataSourceRequest]DataSourceRequest request, string manufacturerCode, string manufacturerName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<Manufacturer> manufacturers = db.Manufacturers;
                if (!string.IsNullOrEmpty(manufacturerName))
                {
                    manufacturers = manufacturers.Where(p => p.ManufacturerName.StartsWith(manufacturerName));
                }
                if (!string.IsNullOrEmpty(manufacturerCode))
                {
                    manufacturers = manufacturers.Where(p => p.ManufacturerCode.StartsWith(manufacturerCode));
                }
                DataSourceResult result = manufacturers.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //public ActionResult CreateManufacturer([DataSourceRequest]DataSourceRequest request, Manufacturer manufacturer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new Manufacturer()
        //            {
        //                ManufacturerId = manufacturer.ManufacturerId,
        //                ManufacturerName = manufacturer.ManufacturerName,
        //                ManufacturerCode = manufacturer.ManufacturerCode,
        //            };
        //            db.Manufacturers.Add(entity);
        //            db.SaveChanges();
        //            manufacturer.ManufacturerId = entity.ManufacturerId;
        //        }
        //    }
        //    return Json(new[] { manufacturer }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult UpdateManufacturer([DataSourceRequest]DataSourceRequest request, Manufacturer manufacturer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            db.Manufacturers.Attach(manufacturer);
        //            db.Entry(manufacturer).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { manufacturer }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult DestroyManufacturer([DataSourceRequest]DataSourceRequest request, Manufacturer manufacturer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new Manufacturer
        //            {
        //                ManufacturerId = manufacturer.ManufacturerId,
        //            };
        //            db.Manufacturers.Attach(entity);
        //            db.Manufacturers.Remove(entity);
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { manufacturer }.ToDataSourceResult(request, ModelState));
        //}
        [Authorize(Roles = "administrator")]
        public ActionResult ManufacturerDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Manufacturer manufacturer = db.Manufacturers.Find(id);
                if (manufacturer == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/Manufacturers/ManufacturerDetails.cshtml", manufacturer);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateManufacturerView()
        {
            var item = new Manufacturer();
            return View("~/Views/Catalogs/Manufacturers/ManufacturerTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveManufacturer(Manufacturer manufacturer)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (manufacturer.ManufacturerId == 0)
                    {
                        var entity = new Manufacturer
                        {
                            ManufacturerId = manufacturer.ManufacturerId,
                            ManufacturerCode = manufacturer.ManufacturerCode,
                            ManufacturerName = manufacturer.ManufacturerName

                        };
                        db.Manufacturers.Add(entity);
                    }
                    else
                    {
                        Manufacturer item = db.Manufacturers.Find(manufacturer.ManufacturerId);
                        item.ManufacturerId = manufacturer.ManufacturerId;
                        item.ManufacturerCode = manufacturer.ManufacturerCode;
                        item.ManufacturerName = manufacturer.ManufacturerName;
                        db.Manufacturers.Attach(item);
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
        public ActionResult OpenUpdateManufacturerView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Manufacturer item = db.Manufacturers.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/Manufacturers/ManufacturerTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteManufacturer(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Manufacturer item = db.Manufacturers.Find(id);
                    db.Manufacturers.Attach(item);
                    db.Manufacturers.Remove(item);
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
