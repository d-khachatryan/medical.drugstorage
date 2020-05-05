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

namespace Medicaldrugstore.Controllers
{
    public class PlacementStatusController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/PlacementStatus/Index.cshtml", db.PlacementStatuses.ToList());
            }
        }

        public ActionResult ReadStatuses([DataSourceRequest]DataSourceRequest request, string statusCode, string statusName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<PlacementStatus> statuses = db.PlacementStatuses;
                if (!string.IsNullOrEmpty(statusName))
                {
                    statuses = statuses.Where(p => p.PlacementStatusName.StartsWith(statusName));
                }
                if (!string.IsNullOrEmpty(statusCode))
                {
                    statuses = statuses.Where(p => p.PlacementStatusCode.StartsWith(statusCode));
                }
                DataSourceResult result = statuses.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult CreateStatus([DataSourceRequest]DataSourceRequest request, PlacementStatus status)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new PlacementStatus()
                    {
                        PlacementStatusId = status.PlacementStatusId,
                        PlacementStatusName = status.PlacementStatusName,
                        PlacementStatusCode = status.PlacementStatusCode,
                    };
                    db.PlacementStatuses.Add(entity);
                    db.SaveChanges();
                    status.PlacementStatusId = entity.PlacementStatusId;
                }
            }
            return Json(new[] { status }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult UpdateStatus([DataSourceRequest]DataSourceRequest request, PlacementStatus status)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    db.PlacementStatuses.Attach(status);
                    db.Entry(status).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(new[] { status }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult DestroyStatus([DataSourceRequest]DataSourceRequest request, PlacementStatus status)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new PlacementStatus()
                    {
                        PlacementStatusId = status.PlacementStatusId,
                    };
                    db.PlacementStatuses.Attach(entity);
                    db.PlacementStatuses.Remove(entity);
                    db.SaveChanges();
                }
            }
            return Json(new[] { status }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult StatusDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PlacementStatus status = db.PlacementStatuses.Find(id);
                if (status == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/PlacementStatus/StatusDetails.cshtml", status);
                }
            }
        }
    }
}
