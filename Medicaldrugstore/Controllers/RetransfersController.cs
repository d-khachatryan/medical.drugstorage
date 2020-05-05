using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Medicaldrugstore.Controllers
{
    public class RetransfersController : Controller
    {
        [Authorize(Roles = "organizationrole")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            return View();
        }

        private void FillViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

            var lBaseDocuments = new List<SelectListItem>();
            lBaseDocuments = db.BaseDocuments.Select(x => new SelectListItem { Text = x.BaseDocumentName, Value = x.BaseDocumentId.ToString() }).ToList();
            ViewBag.vbBaseDocuments = lBaseDocuments;

            var lReplacementStatuses = new List<SelectListItem>();
            lReplacementStatuses = db.ReplacementStatuses.Select(x => new SelectListItem { Text = x.ReplacementStatusName, Value = x.ReplacementStatusId.ToString() }).ToList();
            ViewBag.vbReplacementStatuses = lReplacementStatuses;

            var lRetransferStatuses = new List<SelectListItem>();
            lRetransferStatuses = db.RetransferStatuses.Select(x => new SelectListItem { Text = x.RetransferStatusName, Value = x.RetransferStatusId.ToString() }).ToList();
            ViewBag.vbRetransferStatuses = lRetransferStatuses;
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult OrganizationInfo([DataSourceRequest]DataSourceRequest request, string id)
        {
            using (var db = new StoreContext())
            {
                int? organizationId = Convert.ToInt32(id);
                IQueryable<OrganizationDetail> query = from c in db.OrganizationDetails
                                                        where c.OrganizationId == organizationId
                                                        select c;
                DataSourceResult result = query.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadRetransfers([DataSourceRequest]DataSourceRequest request, string basedocumentId, string senderOrganizationId, string receiverOrganizationId, string startRetransferDate, string terminationRetransferDate)
        {
            using (var db = new StoreContext())
            {
                IQueryable<Retransfer> retransfers = db.Retransfers;
                if (basedocumentId != "")
                {
                    int id = Convert.ToInt32(basedocumentId);
                    retransfers = retransfers.Where(p => p.BaseDocumentId == id);
                }
                if (senderOrganizationId != "")
                {
                    int id = Convert.ToInt32(senderOrganizationId);
                    retransfers = retransfers.Where(p => p.SenderOrganizationId == id);
                }
                if (receiverOrganizationId != "")
                {
                    int id = Convert.ToInt32(receiverOrganizationId);
                    retransfers = retransfers.Where(p => p.ReceiverOrganizationId == id);
                }
                if (startRetransferDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startRetransferDate);
                    retransfers = retransfers.Where(p => p.RetransferDate >= dt);
                }
                if (terminationRetransferDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationRetransferDate);
                    retransfers = retransfers.Where(p => p.RetransferDate <= dt);
                }
                DataSourceResult result = retransfers.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult RetransferTemplate(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                FillViewBugs(db);

                Retransfer item;
                if (id == 0)
                {
                    item = new Retransfer();
                }
                else
                {
                    item = db.Retransfers.Find(id);
                }

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("RetransferTemplate", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult SaveRetransfer(Retransfer retransfer)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.Retransfers.Where(p => p.RetransferId == retransfer.RetransferId).Count();
                    if (cnt == 0)
                    {
                        db.Retransfers.Add(retransfer);
                    }
                    else
                    {
                        db.Retransfers.Attach(retransfer);
                        db.Entry(retransfer).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult DeleteRetransfer(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Retransfer item = db.Retransfers.Find(id);
                    db.Retransfers.Attach(item);
                    db.Retransfers.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult RetransferDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                RetransferDetails retransferdetails = db.RetransferDetails.Find(id);
                if (retransferdetails == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(retransferdetails);
                }
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult RepresentRetransfer(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Retransfer item = db.Retransfers.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("RepresentRetransfer", item);
                }
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult Represent(string rId, string rDate)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Retransfer item = db.Retransfers.Find(Convert.ToInt32(rId));
                    item.RetransferStatusId = 1;
                    item.RetransferDate = Convert.ToDateTime(rDate);
                    db.Retransfers.Attach(item);
                    db.Entry(item).State = EntityState.Modified;

                    foreach (Replacement replacementItem in db.Replacements.Where(p => p.RetransferId == item.RetransferId))
                    {
                        replacementItem.ReplacementStatusId = 3; //Կարգավիճակ: --Վերադարձման պատրաստ--
                        replacementItem.ReadyDate = item.RetransferDate;
                        db.Replacements.Attach(replacementItem);
                        db.Entry(replacementItem).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    if (item == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return Json("1", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadReplacements([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                int? organizationId = (db.Retransfers.Where(p => p.RetransferId == id)).First().ReceiverOrganizationId;
                IQueryable<Replacement> replacements = db.Replacements.Where(p => p.RetransferId == id || (p.RetransferId == null && p.DestinationOrganizationId == organizationId));
                DataSourceResult result = replacements.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult UpdatePlacement([DataSourceRequest]DataSourceRequest request, Placement placement, int id)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    Transfer transfer = db.Transfers.Find(id);
                    if (placement.IsTransfer == true)
                    {
                        placement.TransferId = id;
                        placement.PlacementStatusId = 4; //Կարգավիճակ: --Տրամադրված--
                        double? totalSum1 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.TransferId == id select n.TotalCost).Sum() ?? 0;
                        double? totalSum2 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.PlacementId == placement.PlacementId select n.TotalCost).Sum() ?? 0;
                        transfer.TransferTotal = totalSum1 + totalSum2;
                    }
                    else
                    {
                        placement.TransferId = null;
                        placement.ReadyDate = null;
                        placement.PlacementStatusId = 3; //Կարգավիճակ: --Համաձայնեցված--
                        double? totalSum1 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.TransferId == id select n.TotalCost).Sum() ?? 0;
                        double? totalSum2 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.PlacementId == placement.PlacementId select n.TotalCost).Sum() ?? 0;
                        transfer.TransferTotal = totalSum1 - totalSum2;
                    }

                    db.Transfers.Attach(transfer);
                    db.Entry(transfer).State = EntityState.Modified;

                    db.Placements.Attach(placement);
                    db.Entry(placement).State = EntityState.Modified;

                    db.SaveChanges();
                }
            }
            return Json(new[] { placement }.ToDataSourceResult(request, ModelState));
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult JoinReplacement(int? rpid, int? rid)
        {
            if (rpid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                Replacement replacement = db.Replacements.Find(rpid);
                replacement.RetransferId = rid;
                if (replacement == null)
                {
                    return HttpNotFound();
                }
                return View("JoinReplacement", replacement);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult Join(string rpId, string rId, string iRr)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Replacement replacement = db.Replacements.Find(Convert.ToInt32(rpId));
                    replacement.IsRetransfer = Convert.ToBoolean(iRr);
                    replacement.RetransferId = Convert.ToInt32(rId);

                    Retransfer retransfer = db.Retransfers.Find(Convert.ToInt32(rId));
                    if (replacement.IsRetransfer == true)
                    {
                        //replacement.ReplacementStatusId = 6; //Կարգավիճակ: --Տրամադրված--
                        double? totalSum1 = (from p in db.Replacements join n in db.ReplacementProducts on p.ReplacementId equals n.ReplacementId where p.RetransferId == replacement.RetransferId select n.TotalCost).Sum() ?? 0;
                        double? totalSum2 = (from p in db.Replacements join n in db.ReplacementProducts on p.ReplacementId equals n.ReplacementId where p.ReplacementId == replacement.ReplacementId select n.TotalCost).Sum() ?? 0;
                        retransfer.RetransferTotal = totalSum1 + totalSum2;
                    }
                    else
                    {
                        //replacement.ReplacementStatusId = 3; //Կարգավիճակ: --Համաձայնեցված--
                        double? totalSum1 = (from p in db.Replacements join n in db.ReplacementProducts on p.ReplacementId equals n.ReplacementId where p.RetransferId == replacement.RetransferId select n.TotalCost).Sum() ?? 0;
                        double? totalSum2 = (from p in db.Replacements join n in db.ReplacementProducts on p.ReplacementId equals n.ReplacementId where p.ReplacementId == replacement.ReplacementId select n.TotalCost).Sum() ?? 0;
                        retransfer.RetransferTotal = totalSum1 - totalSum2;
                        replacement.RetransferId = null;
                        replacement.ReadyDate = null;
                    }

                    db.Retransfers.Attach(retransfer);
                    db.Entry(retransfer).State = EntityState.Modified;

                    db.Replacements.Attach(replacement);
                    db.Entry(replacement).State = EntityState.Modified;

                    db.SaveChanges();
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
