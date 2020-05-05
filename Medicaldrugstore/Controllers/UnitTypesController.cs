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
    public class UnitTypesController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/UnitTypes/Index.cshtml", db.UnitTypes.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadUnitTypes([DataSourceRequest]DataSourceRequest request, string unitTypeCode, string unitTypeName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<UnitType> drugtypes = db.UnitTypes;
                if (!string.IsNullOrEmpty(unitTypeName))
                {
                    drugtypes = drugtypes.Where(p => p.UnitTypeName.StartsWith(unitTypeName));
                }
                if (!string.IsNullOrEmpty(unitTypeCode))
                {
                    drugtypes = drugtypes.Where(p => p.UnitTypeCode.StartsWith(unitTypeCode));
                }
                DataSourceResult result = drugtypes.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //public ActionResult CreateUnitType([DataSourceRequest]DataSourceRequest request, UnitType unitTypes)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new UnitType()
        //            {
        //                UnitTypeId = unitTypes.UnitTypeId,
        //                UnitTypeName = unitTypes.UnitTypeName,
        //                UnitTypeCode = unitTypes.UnitTypeCode,
        //            };
        //            db.UnitTypes.Add(entity);
        //            db.SaveChanges();
        //            unitTypes.UnitTypeId = entity.UnitTypeId;
        //        }
        //    }
        //    return Json(new[] { unitTypes }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult UpdateUnitType([DataSourceRequest]DataSourceRequest request, UnitType unitTypes)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            db.UnitTypes.Attach(unitTypes);
        //            db.Entry(unitTypes).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { unitTypes }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult DestroyUnitType([DataSourceRequest]DataSourceRequest request, UnitType unitTypes)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new UnitType
        //            {
        //                UnitTypeId = unitTypes.UnitTypeId,
        //            };
        //            db.UnitTypes.Attach(entity);
        //            db.UnitTypes.Remove(entity);
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { unitTypes }.ToDataSourceResult(request, ModelState));
        //}
        [Authorize(Roles = "administrator")]
        public ActionResult UnitTypeDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                UnitType unitType = db.UnitTypes.Find(id);
                if (unitType == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/UnitTypes/UnitTypeDetails.cshtml", unitType);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateUnitTypeView()
        {
            var item = new UnitType();
            return View("~/Views/Catalogs/UnitTypes/UnitTypeTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveUnitType(UnitType unitType)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (unitType.UnitTypeId == 0)
                    {
                        var entity = new UnitType
                        {
                            UnitTypeId = unitType.UnitTypeId,
                            UnitTypeCode = unitType.UnitTypeCode,
                            UnitTypeName = unitType.UnitTypeName

                        };
                        db.UnitTypes.Add(entity);
                    }
                    else
                    {
                        UnitType item = db.UnitTypes.Find(unitType.UnitTypeId);
                        item.UnitTypeId = unitType.UnitTypeId;
                        item.UnitTypeCode = unitType.UnitTypeCode;
                        item.UnitTypeName = unitType.UnitTypeName;
                        db.UnitTypes.Attach(item);
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
        public ActionResult OpenUpdateUnitTypeView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                UnitType item = db.UnitTypes.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/UnitTypes/UnitTypeTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteUnitType(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    UnitType item = db.UnitTypes.Find(id);
                    db.UnitTypes.Attach(item);
                    db.UnitTypes.Remove(item);
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
