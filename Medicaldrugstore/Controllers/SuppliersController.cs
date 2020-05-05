using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;

namespace Medicaldrugstore.Controllers
{
    public class SuppliersController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/Suppliers/Index.cshtml", db.Suppliers.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadSuppliers([DataSourceRequest]DataSourceRequest request, string supplierCode, string supplierName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<Supplier> suppliers = db.Suppliers;
                if (!string.IsNullOrEmpty(supplierName))
                {
                    suppliers = suppliers.Where(p => p.SupplierName.StartsWith(supplierName));
                }
                if (!string.IsNullOrEmpty(supplierCode))
                {
                    suppliers = suppliers.Where(p => p.SupplierCode.StartsWith(supplierCode));
                }
                DataSourceResult result = suppliers.ToDataSourceResult(request);
                return Json(result);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult CreateSupplier([DataSourceRequest]DataSourceRequest request, Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new Supplier()
                    {
                        SupplierId = supplier.SupplierId,
                        SupplierName = supplier.SupplierName,
                        SupplierCode = supplier.SupplierCode,
                    };
                    db.Suppliers.Add(entity);
                    db.SaveChanges();
                    supplier.SupplierId = entity.SupplierId;
                }
            }
            return Json(new[] { supplier }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "administrator")]
        public ActionResult UpdateSupplier([DataSourceRequest]DataSourceRequest request, Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    db.Suppliers.Attach(supplier);
                    db.Entry(supplier).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(new[] { supplier }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DestroySupplier([DataSourceRequest]DataSourceRequest request, Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new Supplier
                    {
                        SupplierId = supplier.SupplierId,
                    };
                    db.Suppliers.Attach(entity);
                    db.Suppliers.Remove(entity);
                    db.SaveChanges();
                }
            }
            return Json(new[] { supplier }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SupplierDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Supplier supplier = db.Suppliers.Find(id);
                if (supplier == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/Suppliers/SupplierDetails.cshtml", supplier);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateSupplierView()
        {
            var item = new Supplier();
            return View("~/Views/Catalogs/Suppliers/SupplierTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveSupplier(Supplier supplier)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (supplier.SupplierId == 0)
                    {
                        var entity = new Supplier
                        {
                            SupplierId = supplier.SupplierId,
                            SupplierCode = supplier.SupplierCode,
                            SupplierName = supplier.SupplierName

                        };
                        db.Suppliers.Add(entity);
                    }
                    else
                    {
                        Supplier item = db.Suppliers.Find(supplier.SupplierId);
                        item.SupplierId = supplier.SupplierId;
                        item.SupplierCode = supplier.SupplierCode;
                        item.SupplierName = supplier.SupplierName;
                        db.Suppliers.Attach(item);
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
        public ActionResult OpenUpdateSupplierView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Supplier item = db.Suppliers.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/Suppliers/SupplierTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteSupplier(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Supplier item = db.Suppliers.Find(id);
                    db.Suppliers.Attach(item);
                    db.Suppliers.Remove(item);
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
