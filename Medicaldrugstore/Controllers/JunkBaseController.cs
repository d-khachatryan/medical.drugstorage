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
    public class JunkBaseController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/JunkBase/Index.cshtml", db.JunkBases.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadJunkBase([DataSourceRequest]DataSourceRequest request, string junkBaseCode, string junkBaseName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<JunkBase> placementBase = db.JunkBases;
                if (!string.IsNullOrEmpty(junkBaseName))
                {
                    placementBase = placementBase.Where(p => p.JunkBaseName.StartsWith(junkBaseName));
                }
                if (!string.IsNullOrEmpty(junkBaseCode))
                {
                    placementBase = placementBase.Where(p => p.JunkBaseCode.StartsWith(junkBaseCode));
                }
                DataSourceResult result = placementBase.ToDataSourceResult(request);
                return Json(result);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult JunkBaseDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                JunkBase placementBase = db.JunkBases.Find(id);
                if (placementBase == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/JunkBase/JunkBaseDetails.cshtml", placementBase);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateJunkBaseView()
        {
            var item = new JunkBase();
            return View("~/Views/Catalogs/JunkBase/JunkBaseTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveJunkBase(JunkBase junkBase)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (junkBase.JunkBaseId == 0)
                    {
                        var entity = new JunkBase
                        {
                            JunkBaseId = junkBase.JunkBaseId,
                            JunkBaseCode = junkBase.JunkBaseCode,
                            JunkBaseName = junkBase.JunkBaseName

                        };
                        db.JunkBases.Add(entity);
                    }
                    else
                    {
                        JunkBase item = db.JunkBases.Find(junkBase.JunkBaseId);
                        item.JunkBaseId = junkBase.JunkBaseId;
                        item.JunkBaseCode = junkBase.JunkBaseCode;
                        item.JunkBaseName = junkBase.JunkBaseName;
                        db.JunkBases.Attach(item);
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
        public ActionResult OpenUpdateJunkBaseView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                JunkBase item = db.JunkBases.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/JunkBase/JunkBaseTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteJunkBase(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    JunkBase item = db.JunkBases.Find(id);
                    db.JunkBases.Attach(item);
                    db.JunkBases.Remove(item);
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
