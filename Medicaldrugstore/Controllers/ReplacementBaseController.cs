using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Medicaldrugstore.Controllers
{
    public class ReplacementBaseController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/ReplacementBase/Index.cshtml", db.ReplacementBases.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadReplacementBase([DataSourceRequest]DataSourceRequest request, string replacementBaseCode, string replacementBaseName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<ReplacementBase> placementBase = db.ReplacementBases;
                if (!string.IsNullOrEmpty(replacementBaseName))
                {
                    placementBase = placementBase.Where(p => p.ReplacementBaseName.StartsWith(replacementBaseName));
                }
                if (!string.IsNullOrEmpty(replacementBaseCode))
                {
                    placementBase = placementBase.Where(p => p.ReplacementBaseCode.StartsWith(replacementBaseCode));
                }
                DataSourceResult result = placementBase.ToDataSourceResult(request);
                return Json(result);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReplacementBaseDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ReplacementBase placementBase = db.ReplacementBases.Find(id);
                if (placementBase == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/ReplacementBase/ReplacementBaseDetails.cshtml", placementBase);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateReplacementBaseView()
        {
            var item = new ReplacementBase();
            return View("~/Views/Catalogs/ReplacementBase/ReplacementBaseTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveReplacementBase(ReplacementBase replacementBase)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (replacementBase.ReplacementBaseId == 0)
                    {
                        var entity = new ReplacementBase
                        {
                            ReplacementBaseId = replacementBase.ReplacementBaseId,
                            ReplacementBaseCode = replacementBase.ReplacementBaseCode,
                            ReplacementBaseName = replacementBase.ReplacementBaseName

                        };
                        db.ReplacementBases.Add(entity);
                    }
                    else
                    {
                        ReplacementBase item = db.ReplacementBases.Find(replacementBase.ReplacementBaseId);
                        item.ReplacementBaseId = replacementBase.ReplacementBaseId;
                        item.ReplacementBaseCode = replacementBase.ReplacementBaseCode;
                        item.ReplacementBaseName = replacementBase.ReplacementBaseName;
                        db.ReplacementBases.Attach(item);
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
        public ActionResult OpenUpdateReplacementBaseView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ReplacementBase item = db.ReplacementBases.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/ReplacementBase/ReplacementBaseTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteReplacementBase(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReplacementBase item = db.ReplacementBases.Find(id);
                    db.ReplacementBases.Attach(item);
                    db.ReplacementBases.Remove(item);
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
