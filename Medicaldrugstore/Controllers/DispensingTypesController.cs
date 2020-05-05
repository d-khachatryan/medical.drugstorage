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
    public class DispensingTypesController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/DispensingTypes/index.cshtml", db.DispensingTypes.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadDispensingTypes([DataSourceRequest]DataSourceRequest request, string dispensingTypeCode, string dispensingTypeName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<DispensingType> drugtypes = db.DispensingTypes;
                if (!string.IsNullOrEmpty(dispensingTypeName))
                {
                    drugtypes = drugtypes.Where(p => p.DispensingTypeName.StartsWith(dispensingTypeName));
                }
                if (!string.IsNullOrEmpty(dispensingTypeCode))
                {
                    drugtypes = drugtypes.Where(p => p.DispensingTypeCode.StartsWith(dispensingTypeCode));
                }
                DataSourceResult result = drugtypes.ToDataSourceResult(request);
                return Json(result);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DispensingTypeDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DispensingType dispensingType = db.DispensingTypes.Find(id);
                if (dispensingType == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/DispensingTypes/DispensingTypeDetails.cshtml", dispensingType);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateDispensingTypeView()
        {
            var item = new DispensingType();
            return View("~/Views/Catalogs/DispensingTypes/DispensingTypeTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveDispensingType(DispensingType dispensingType)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (dispensingType.DispensingTypeId == 0)
                    {
                        var entity = new DispensingType
                        {
                            DispensingTypeId = dispensingType.DispensingTypeId,
                            DispensingTypeCode = dispensingType.DispensingTypeCode,
                            DispensingTypeName = dispensingType.DispensingTypeName

                        };
                        db.DispensingTypes.Add(entity);
                    }
                    else
                    {
                        DispensingType item = db.DispensingTypes.Find(dispensingType.DispensingTypeId);
                        item.DispensingTypeId = dispensingType.DispensingTypeId;
                        item.DispensingTypeCode = dispensingType.DispensingTypeCode;
                        item.DispensingTypeName = dispensingType.DispensingTypeName;
                        db.DispensingTypes.Attach(item);
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
        public ActionResult OpenUpdateDispensingTypeView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                DispensingType item = db.DispensingTypes.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/DispensingTypes/DispensingTypeTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteDispensingType(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    DispensingType item = db.DispensingTypes.Find(id);
                    db.DispensingTypes.Attach(item);
                    db.DispensingTypes.Remove(item);
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
