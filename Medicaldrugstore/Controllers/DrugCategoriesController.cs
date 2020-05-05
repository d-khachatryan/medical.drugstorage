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
    public class DrugCategoriesController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/DrugCategories/Index.cshtml", db.DrugCategories.ToList());
            }
        }

        [Authorize(Roles = "administrator")]
        public ActionResult ReadDrugCategories([DataSourceRequest]DataSourceRequest request, string drugCategoryCode, string drugCategoryName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<DrugCategory> drugcategories = db.DrugCategories;
                if (!string.IsNullOrEmpty(drugCategoryName))
                {
                    drugcategories = drugcategories.Where(p => p.DrugCategoryName.StartsWith(drugCategoryName));
                }
                if (!string.IsNullOrEmpty(drugCategoryCode))
                {
                    drugcategories = drugcategories.Where(p => p.DrugCategoryCode.StartsWith(drugCategoryCode));
                }
                DataSourceResult result = drugcategories.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //public ActionResult CreateDrugCategory([DataSourceRequest]DataSourceRequest request, DrugCategory drugCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new DrugCategory()
        //            {
        //                DrugCategoryId = drugCategory.DrugCategoryId,
        //                DrugCategoryName = drugCategory.DrugCategoryName,
        //                DrugCategoryCode = drugCategory.DrugCategoryCode,
        //            };
        //            db.DrugCategories.Add(entity);
        //            db.SaveChanges();
        //            drugCategory.DrugCategoryId = entity.DrugCategoryId;
        //        }
        //    }
        //    return Json(new[] { drugCategory }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult UpdateDrugCategory([DataSourceRequest]DataSourceRequest request, DrugCategory drugCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            db.DrugCategories.Attach(drugCategory);
        //            db.Entry(drugCategory).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { drugCategory }.ToDataSourceResult(request, ModelState));
        //}



        //public ActionResult DestroyDrugCategory([DataSourceRequest]DataSourceRequest request, DrugCategory drugCategory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new DrugCategory
        //            {
        //                DrugCategoryId = drugCategory.DrugCategoryId,
        //            };
        //            db.DrugCategories.Attach(entity);
        //            db.DrugCategories.Remove(entity);
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { drugCategory }.ToDataSourceResult(request, ModelState));
        //}
        [Authorize(Roles = "administrator")]
        public ActionResult DrugCategoryDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DrugCategory drugCategory = db.DrugCategories.Find(id);
                if (drugCategory == null)
                {
                    return HttpNotFound();
                }
                return View("~/Views/Catalogs/DrugCategories/DrugCategoryDetails.cshtml", drugCategory);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateDrugCategoryView()
        {
            //using (var db = new StoreContext())
            //{
                var item = new DrugCategory();
                return View("~/Views/Catalogs/DrugCategories/DrugCategoryTemplate.cshtml", item);
            //}
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenUpdateDrugCategoryView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                DrugCategory item = db.DrugCategories.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/DrugCategories/DrugCategoryTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveDrugCategory(DrugCategory drugCategory)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (drugCategory.DrugCategoryId == 0)
                    {
                        var entity = new DrugCategory
                        {
                            DrugCategoryId = drugCategory.DrugCategoryId,
                            DrugCategoryCode = drugCategory.DrugCategoryCode,
                            DrugCategoryName = drugCategory.DrugCategoryName,
                            UnitItemQuantity = drugCategory.UnitItemQuantity

                        };
                        db.DrugCategories.Add(entity);
                    }
                    else
                    {
                        DrugCategory item = db.DrugCategories.Find(drugCategory.DrugCategoryId);
                        item.DrugCategoryId = drugCategory.DrugCategoryId;
                        item.DrugCategoryCode = drugCategory.DrugCategoryCode;
                        item.DrugCategoryName = drugCategory.DrugCategoryName;
                        item.UnitItemQuantity = drugCategory.UnitItemQuantity;
                        db.DrugCategories.Attach(item);
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
        public ActionResult DeleteDrugCategory(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    DrugCategory item = db.DrugCategories.Find(id);
                    db.DrugCategories.Attach(item);
                    db.DrugCategories.Remove(item);
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
