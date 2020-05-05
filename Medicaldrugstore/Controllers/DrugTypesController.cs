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
//using System.Collections.Generic;
using System;

namespace Medicaldrugstore.Controllers
{
    public class DrugTypesController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/DrugTypes/Index.cshtml", db.DrugTypes.ToList());
            }
        }

        [Authorize(Roles = "administrator")]
        public ActionResult ReadDrugTypes([DataSourceRequest]DataSourceRequest request, string drugTypeCode, string drugTypeName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<DrugType> drugtypes = db.DrugTypes;
                if (!string.IsNullOrEmpty(drugTypeName))
                {
                    drugtypes = drugtypes.Where(p => p.DrugTypeName.StartsWith(drugTypeName));
                }
                if (!string.IsNullOrEmpty(drugTypeCode))
                {
                    drugtypes = drugtypes.Where(p => p.DrugTypeCode.StartsWith(drugTypeCode));
                }
                DataSourceResult result = drugtypes.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "administrator")]
        public ActionResult CreateDrugType([DataSourceRequest]DataSourceRequest request, DrugType drugTypes)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new DrugType()
                    {
                        DrugTypeId = drugTypes.DrugTypeId,
                        DrugTypeName = drugTypes.DrugTypeName,
                        DrugTypeCode = drugTypes.DrugTypeCode,
                    };
                    db.DrugTypes.Add(entity);
                    db.SaveChanges();
                    drugTypes.DrugTypeId = entity.DrugTypeId;
                }
            }
            return Json(new[] { drugTypes }.ToDataSourceResult(request, ModelState));
        }

        [Authorize(Roles = "administrator")]
        public ActionResult UpdateDrugType([DataSourceRequest]DataSourceRequest request, DrugType drugTypes)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    db.DrugTypes.Attach(drugTypes);
                    db.Entry(drugTypes).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(new[] { drugTypes }.ToDataSourceResult(request, ModelState));
        }

        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateDrugTypeView()
        {
            //using (var db = new StoreContext())
            //{
                //var lOrganizations = new List<SelectListItem>();
                //lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                //ViewBag.vbOrganizations = lOrganizations;

                var item = new DrugType();
                return View("~/Views/Catalogs/DrugTypes/DrugTypeTemplate.cshtml", item);
            //}
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenUpdateDrugTypeView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                DrugType item = db.DrugTypes.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/DrugTypes/DrugTypeTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveDrugType(DrugType drugType)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    //int? cnt = db.DrugTypes.Where(p => p.DrugTypeId == drugType.DrugTypeId).Count();
                    //string drugClassName = db.DrugClasses.Find(drug.DrugClassId).DrugClassName;
                    if (drugType.DrugTypeId == 0)
                    {
                        var entity = new DrugType
                        {
                            DrugTypeId = drugType.DrugTypeId,
                            DrugTypeCode = drugType.DrugTypeCode,
                            DrugTypeName = drugType.DrugTypeName

                        };
                        db.DrugTypes.Add(entity);
                    }
                    else
                    {
                        DrugType item = db.DrugTypes.Find(drugType.DrugTypeId);
                        item.DrugTypeId = drugType.DrugTypeId;
                        item.DrugTypeCode = drugType.DrugTypeCode;
                        item.DrugTypeName = drugType.DrugTypeName;
                        db.DrugTypes.Attach(item);
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
        public ActionResult DeleteDrugType(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    DrugType item = db.DrugTypes.Find(id);
                    db.DrugTypes.Attach(item);
                    db.DrugTypes.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DestroyDrugType([DataSourceRequest]DataSourceRequest request, DrugType drugTypes)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new DrugType
                    {
                        DrugTypeId = drugTypes.DrugTypeId,
                    };
                    db.DrugTypes.Attach(entity);
                    db.DrugTypes.Remove(entity);
                    db.SaveChanges();
                }
            }
            return Json(new[] { drugTypes }.ToDataSourceResult(request, ModelState));
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DrugTypeDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DrugType drugType = db.DrugTypes.Find(id);
                if (drugType == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/DrugTypes/DrugTypeDetails.cshtml", drugType);
                }
            }
        }
    }
}
