using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Helpers;
using Medicaldrugstore.Models;
using Microsoft.AspNet.Identity;
using System.Web;

namespace Medicaldrugstore.Controllers
{
    public class TransfersController : Controller
    {
        readonly string userId;

        public TransfersController()
        {
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        }

        public TransfersController(string uId)
        {
            userId = uId;
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                //Select only the organization rows accesible for the curent user 
                var organizationHelper = new OrganizationHelper();
                List<SelectListItem> lSenderOrganizations = organizationHelper.StorageOrganizations(userId, db);
                ViewBag.vbSenderOrganizations = lSenderOrganizations;

                var lReceiverOrganizations = new List<SelectListItem>();
                lReceiverOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbReceiverOrganizations = lReceiverOrganizations;

                var lBaseDocuments = new List<SelectListItem>();
                lBaseDocuments = db.BaseDocuments.Select(x => new SelectListItem { Text = x.BaseDocumentName, Value = x.BaseDocumentId.ToString() }).ToList();
                ViewBag.vbBaseDocuments = lBaseDocuments;

            }
            return View();
        }

        [Authorize(Roles = "storagerole")]
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

        public JsonResult GetSenderOrganizations()
        {
            using (var db = new StoreContext())
            {
                var organizationHelper = new OrganizationHelper();
                return Json(organizationHelper.UserOrganizations(userId, db).Select(c => new { OrganizationId = c.Value, OrganizationName = c.Text }), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetReceiverOrganizations()
        {
            using (var db = new StoreContext())
            {
                IQueryable<Organization> organizations = db.Organizations .AsQueryable();
                return Json(organizations.ToList().Select(c => new { OrganizationId = c.OrganizationId, OrganizationName = c.OrganizationName }), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetBaseDocuments()
        {
            using (var db = new StoreContext())
            {
                IQueryable<BaseDocument> baseDocuments = db.BaseDocuments.AsQueryable();
                return Json(baseDocuments.ToList().Select(c => new { BaseDocumentId = c.BaseDocumentId, BaseDocumentName = c.BaseDocumentName }), JsonRequestBehavior.AllowGet);
            }
        }

        
        [Authorize(Roles = "storagerole")]
        public ActionResult ReadTransfers([DataSourceRequest]DataSourceRequest request, string basedocumentId, string senderOrganizationId, string receiverOrganizationId, string startTransferDate, string terminationTransferDate)
        {
            using (var db = new StoreContext())
            {
                IQueryable<TransferDetail> items = db.TransferDetails;
                if (basedocumentId != "")
                {
                    int id = Convert.ToInt32(basedocumentId);
                    items = items.Where(p => p.BaseDocumentId == id);
                }
                if (senderOrganizationId != "")
                {
                    int id = Convert.ToInt32(senderOrganizationId);
                    items = items.Where(p => p.SenderOrganizationId == id);
                }
                if (receiverOrganizationId != "")
                {
                    int id = Convert.ToInt32(receiverOrganizationId);
                    items = items.Where(p => p.ReceiverOrganizationId == id);
                }
                if (startTransferDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startTransferDate);
                    items = items.Where(p => p.TransferDate >= dt);
                }
                if (terminationTransferDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationTransferDate);
                    items = items.Where(p => p.TransferDate <= dt);
                }
                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult OpenCreateTransferView()
        {
            using (var db = new StoreContext())
            {

                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;

                var lBaseDocuments = new List<SelectListItem>();
                lBaseDocuments = db.BaseDocuments.Select(x => new SelectListItem { Text = x.BaseDocumentName, Value = x.BaseDocumentId.ToString() }).ToList();
                ViewBag.vbBaseDocuments = lBaseDocuments;

                var item = new Transfer();
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("TransferTemplate", item);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult OpenUpdateTransferView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;

                var lBaseDocuments = new List<SelectListItem>();
                lBaseDocuments = db.BaseDocuments.Select(x => new SelectListItem { Text = x.BaseDocumentName, Value = x.BaseDocumentId.ToString() }).ToList();
                ViewBag.vbBaseDocuments = lBaseDocuments;

                Transfer item = db.Transfers.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("TransferTemplate", item);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult TransferTemplate(int? transferId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (transferId == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    var item = new TransferTemplate();

                    if (transferId != 0)
                    {
                        Transfer transfer = db.Transfers.Find(transferId);
                        item.TransferId = Convert.ToInt32 (transferId);
                        item.SenderOrganizationId = transfer.SenderOrganizationId;
                        item.SenderTin = transfer.SenderTin;
                        item.SenderName = transfer.SenderName;
                        item.SenderLocation = transfer.SenderLocation;
                        item.SenderBankName = transfer.SenderBankName;
                        item.SenderSupplyLocation = transfer.SenderSupplyLocation;
                        item.SenderAccountNumber = transfer.SenderAccountNumber;
                        item.SenderHeadName = transfer.SenderHeadName;
                        item.SenderAccountantName = transfer.SenderAccountantName;
                        item.SenderResponsibleName = transfer.SenderResponsibleName;

                        item.ReceiverOrganizationId = transfer.ReceiverOrganizationId;
                        item.ReceiverTin = transfer.ReceiverTin;
                        item.ReceiverName = transfer.ReceiverName;
                        item.ReceiverLocation = transfer.ReceiverLocation;
                        item.ReceiverBankName = transfer.ReceiverBankName;
                        item.ReceiverSupplyLocation = transfer.ReceiverSupplyLocation;
                        item.ReceiverAccountNumber = transfer.ReceiverAccountNumber;
                        item.ReceiverHeadName = transfer.ReceiverHeadName;
                        item.ReceiverAccountantName = transfer.ReceiverAccountantName;
                        item.ReceiverResponsibleName = transfer.ReceiverResponsibleName;

                        item.BaseDocumentId = transfer.BaseDocumentId;
                        //item.TransferDate = transfer.TransferDate;
                        item.DealInfo = transfer.DealInfo;
                        item.Comment = transfer.Comment;
                    }

                    if (item == null)
                    {
                        throw new HttpException(404, "Not found");
                    }
                    else
                    {
                        return View("TransferTemplate", item);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Transfer", "TransferTemplate"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult SaveTransfer(TransferTemplate transferTemplate)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new StoreContext())
                {

                    if (transferTemplate.TransferId == 0)
                    {
                        var item = new Transfer();

                        item.SenderOrganizationId = transferTemplate.SenderOrganizationId;                        
                        item.SenderTin = transferTemplate.SenderTin ;
                        item.SenderName = transferTemplate.SenderName ;
                        item.SenderLocation = transferTemplate.SenderLocation ;
                        item.SenderBankName = transferTemplate.SenderBankName;
                        item.SenderSupplyLocation = transferTemplate.SenderSupplyLocation;
                        item.SenderAccountNumber = transferTemplate.SenderAccountNumber;
                        item.SenderHeadName = transferTemplate.SenderHeadName;
                        item.SenderAccountantName = transferTemplate.SenderAccountantName;
                        item.SenderResponsibleName = transferTemplate.SenderResponsibleName;

                        item.ReceiverOrganizationId = transferTemplate.ReceiverOrganizationId;                                     
                        item.ReceiverTin = transferTemplate.ReceiverTin;
                        item.ReceiverName = transferTemplate.ReceiverName;
                        item.ReceiverLocation = transferTemplate.ReceiverLocation;
                        item.ReceiverBankName = transferTemplate.ReceiverBankName;
                        item.ReceiverSupplyLocation = transferTemplate.ReceiverSupplyLocation;
                        item.ReceiverAccountNumber = transferTemplate.ReceiverAccountNumber;
                        item.ReceiverHeadName = transferTemplate.ReceiverHeadName;
                        item.ReceiverAccountantName = transferTemplate.ReceiverAccountantName;
                        item.ReceiverResponsibleName = transferTemplate.ReceiverResponsibleName;

                        item.BaseDocumentId = transferTemplate.BaseDocumentId;
                        item.DealInfo = transferTemplate.DealInfo;
                        item.Comment = transferTemplate.Comment;

                        db.Transfers.Add(item);
                    }
                    else
                    {
                        Transfer item = db.Transfers.Find(transferTemplate.TransferId);

                        //If JunkProductStatus is set then this record can not be changed
                        if (item.TransferStatusId != null)
                        {
                            ModelState.AddModelError("TransferStatusNull", "TransferStatus can not be null");
                            return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                        }

                        item.SenderOrganizationId = transferTemplate.SenderOrganizationId;
                        item.SenderOrganizationId = transferTemplate.SenderOrganizationId;
                        item.SenderTin = transferTemplate.SenderTin;
                        item.SenderName = transferTemplate.SenderName;
                        item.SenderLocation = transferTemplate.SenderLocation;
                        item.SenderBankName = transferTemplate.SenderBankName;
                        item.SenderSupplyLocation = transferTemplate.SenderSupplyLocation;
                        item.SenderAccountNumber = transferTemplate.SenderAccountNumber;
                        item.SenderHeadName = transferTemplate.SenderHeadName;
                        item.SenderAccountantName = transferTemplate.SenderAccountantName;
                        item.SenderResponsibleName = transferTemplate.SenderResponsibleName;

                        item.ReceiverOrganizationId = transferTemplate.ReceiverOrganizationId;
                        item.ReceiverTin = transferTemplate.ReceiverTin;
                        item.ReceiverName = transferTemplate.ReceiverName;
                        item.ReceiverLocation = transferTemplate.ReceiverLocation;
                        item.ReceiverBankName = transferTemplate.ReceiverBankName;
                        item.ReceiverSupplyLocation = transferTemplate.ReceiverSupplyLocation;
                        item.ReceiverAccountNumber = transferTemplate.ReceiverAccountNumber;
                        item.ReceiverHeadName = transferTemplate.ReceiverHeadName;
                        item.ReceiverAccountantName = transferTemplate.ReceiverAccountantName;
                        item.ReceiverResponsibleName = transferTemplate.ReceiverResponsibleName;

                        item.BaseDocumentId = transferTemplate.BaseDocumentId;
                        item.DealInfo = transferTemplate.DealInfo;
                        item.Comment = transferTemplate.Comment;

                        db.Transfers.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult DeleteTransfer([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Transfer()
                        {
                            TransferId = Convert.ToInt32(id),
                        };
                        db.Transfers.Attach(item);
                        db.Transfers.Remove(item);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult TransferDetail([DataSourceRequest]DataSourceRequest request, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                var details = new TransferDetail();
                details = db.TransferDetails.Find(id);
                if (details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("TransferDetail", details);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult TransferRepresentationTemplate([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Transfer item = db.Transfers.Find(id);
                if (item == null)
                {                    
                    return HttpNotFound();
                }
                else
                {
                    var t = new TransferRepresentationTemplate();
                    t.TransferId = item.TransferId;
                    t.TransferDate = item.TransferDate;
                    return View("TransferRepresentationTemplate", t);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult RepresentTransfer(TransferRepresentationTemplate transferRepresentationTemplate)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Transfer item = db.Transfers.Find(transferRepresentationTemplate.TransferId);
                    item.TransferStatusId = 1;
                    item.TransferDate = transferRepresentationTemplate.TransferDate;
                    db.Transfers.Attach(item);
                    db.Entry(item).State = EntityState.Modified;

                    foreach (Placement placementItem in db.Placements.Where(p => p.TransferId == item.TransferId))
                    {
                        placementItem.ReadyDate = item.TransferDate;
                        db.Placements.Attach(placementItem);
                        db.Entry(placementItem).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [Authorize(Roles = "storagerole")]
        public ActionResult ReadTransferPlacements([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                int? organizationId = 0;
                if (db.Transfers.Where(p => p.TransferId == id).Count ()>0)
                {
                     organizationId = (db.Transfers.Where(p => p.TransferId == id)).First().ReceiverOrganizationId;
                }                
                IQueryable<TransferPlacement> item = db.TransferPlacements.Where(p => p.TransferId == id || (p.TransferId == null && p.OrganizationId == organizationId));
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //[Authorize(Roles = "storagerole")]
        //public ActionResult UpdatePlacement([DataSourceRequest]DataSourceRequest request, Placement placement, int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            Transfer transfer = db.Transfers.Find(id);
        //            if (placement.IsTransfer == true)
        //            {
        //                placement.TransferId = id;
        //                placement.PlacementStatusId = 4; //Կարգավիճակ: --Տրամադրված--
        //                double? totalSum1 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.TransferId == id select n.TotalCost).Sum() ?? 0;
        //                double? totalSum2 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.PlacementId == placement.PlacementId select n.TotalCost).Sum() ?? 0;
        //                transfer.TransferTotal = totalSum1 + totalSum2;
        //            }
        //            else
        //            {
        //                placement.TransferId = null;
        //                placement.ReadyDate = null;
        //                placement.PlacementStatusId = 3; //Կարգավիճակ: --Համաձայնեցված--
        //                double? totalSum1 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.TransferId == id select n.TotalCost).Sum() ?? 0;
        //                double? totalSum2 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.PlacementId == placement.PlacementId select n.TotalCost).Sum() ?? 0;
        //                transfer.TransferTotal = totalSum1 - totalSum2;
        //            }

        //            db.Transfers.Attach(transfer);
        //            db.Entry(transfer).State = EntityState.Modified;

        //            db.Placements.Attach(placement);
        //            db.Entry(placement).State = EntityState.Modified;

        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { placement }.ToDataSourceResult(request, ModelState));
        //}

        //private void FillViewBugs(StoreContext db)
        //{
        //    var lOrganizations = new List<SelectListItem>();
        //    lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
        //    ViewBag.vbOrganizations = lOrganizations;

        //    var lBaseDocuments = new List<SelectListItem>();
        //    lBaseDocuments = db.BaseDocuments.Select(x => new SelectListItem { Text = x.BaseDocumentName, Value = x.BaseDocumentId.ToString() }).ToList();
        //    ViewBag.vbBaseDocuments = lBaseDocuments;

        //    var lPlacementStatuses = new List<SelectListItem>();
        //    lPlacementStatuses = db.PlacementStatuses.Select(x => new SelectListItem { Text = x.PlacementStatusName, Value = x.PlacementStatusId.ToString() }).ToList();
        //    ViewBag.vbPlacementStatuses = lPlacementStatuses;

        //    var lTransferStatuses = new List<SelectListItem>();
        //    lTransferStatuses = db.TransferStatuses.Select(x => new SelectListItem { Text = x.TransferStatusName, Value = x.TransferStatusId.ToString() }).ToList();
        //    ViewBag.vbTransferStatuses = lTransferStatuses;
        //}



        [Authorize(Roles = "storagerole")]
        public ActionResult JoinPlacement(int? pid, int? tid)
        {
            if (pid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                Placement placement = db.Placements.Find(pid);
                placement.TransferId = tid;
                if (placement == null)
                {
                    return HttpNotFound();
                }
                return View("PlacementJoinTemplate",placement);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult Join(string pId, string tId, string iTr)
        {
            using (var db = new StoreContext())
            {
                Placement placement = db.Placements.Find(Convert.ToInt32(pId));
                placement.IsTransfer = Convert.ToBoolean(iTr);
                placement.TransferId = Convert.ToInt32(tId);

                Transfer transfer = db.Transfers.Find(Convert.ToInt32(tId));
                if (placement.IsTransfer == true)
                {
                    placement.PlacementStatusId = 5; //Կարգավիճակ: --Տրամադրված--
                    double? totalSum1 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.TransferId == placement.TransferId select n.TotalCost).Sum() ?? 0;
                    double? totalSum2 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.PlacementId == placement.PlacementId select n.TotalCost).Sum() ?? 0;
                    transfer.TransferTotal = totalSum1 + totalSum2;
                }
                else
                {
                    placement.PlacementStatusId = 3; //Կարգավիճակ: --Համաձայնեցված--
                    double? totalSum1 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.TransferId == placement.TransferId select n.TotalCost).Sum() ?? 0;
                    double? totalSum2 = (from p in db.Placements join o in db.PlacementItems on p.PlacementId equals o.PlacementId join n in db.PlacementItemProducts on o.PlacementItemId equals n.PlacementItemId where p.PlacementId == placement.PlacementId select n.TotalCost).Sum() ?? 0;
                    transfer.TransferTotal = totalSum1 - totalSum2;
                    placement.TransferId = null;
                    placement.ReadyDate = null;
                }

                db.Transfers.Attach(transfer);
                db.Entry(transfer).State = EntityState.Modified;

                db.Placements.Attach(placement);
                db.Entry(placement).State = EntityState.Modified;

                db.SaveChanges();
                if (placement == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return Json("-1", JsonRequestBehavior.AllowGet);
                }
            }
        }

    }
}