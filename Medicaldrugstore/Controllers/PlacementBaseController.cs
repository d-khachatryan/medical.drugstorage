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
    public class PlacementBaseController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/PlacementBase/Index.cshtml", db.PlacementBases.ToList());
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult ReadPlacementBase([DataSourceRequest]DataSourceRequest request, string placementBaseCode, string placementBaseName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<PlacementBase> placementBase = db.PlacementBases;
                if (!string.IsNullOrEmpty(placementBaseName))
                {
                    placementBase = placementBase.Where(p => p.PlacementBaseName.StartsWith(placementBaseName));
                }
                if (!string.IsNullOrEmpty(placementBaseCode))
                {
                    placementBase = placementBase.Where(p => p.PlacementBaseCode.StartsWith(placementBaseCode));
                }
                DataSourceResult result = placementBase.ToDataSourceResult(request);
                return Json(result);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult PlacementBaseDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PlacementBase placementBase = db.PlacementBases.Find(id);
                if (placementBase == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/PlacementBase/PlacementBaseDetails.cshtml", placementBase);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreatePlacementBaseView()
        {
            var item = new PlacementBase();
            return View("~/Views/Catalogs/PlacementBase/PlacementBaseTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SavePlacementBase(PlacementBase placementBase)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (placementBase.PlacementBaseId == 0)
                    {
                        var entity = new PlacementBase
                        {
                            PlacementBaseId = placementBase.PlacementBaseId,
                            PlacementBaseCode = placementBase.PlacementBaseCode,
                            PlacementBaseName = placementBase.PlacementBaseName

                        };
                        db.PlacementBases.Add(entity);
                    }
                    else
                    {
                        PlacementBase item = db.PlacementBases.Find(placementBase.PlacementBaseId);
                        item.PlacementBaseId = placementBase.PlacementBaseId;
                        item.PlacementBaseCode = placementBase.PlacementBaseCode;
                        item.PlacementBaseName = placementBase.PlacementBaseName;
                        db.PlacementBases.Attach(item);
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
        public ActionResult OpenUpdatePlacementBaseView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PlacementBase item = db.PlacementBases.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/PlacementBase/PlacementBaseTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeletePlacementBase(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    PlacementBase item = db.PlacementBases.Find(id);
                    db.PlacementBases.Attach(item);
                    db.PlacementBases.Remove(item);
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
