using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Medicaldrugstore.Controllers
{
    public class PlacementController : Controller
    {
        readonly string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        [Authorize(Roles = "organizationrole")]
        public ActionResult OrganizationIndex()
        {
            using (var db = new StoreContext())
            {
                OrganizationViewBugs(db);
            }
            return View();
        }

        private void OrganizationViewBugs(StoreContext db)
        {
            var lDrugClasses = new List<SelectListItem>();
            lDrugClasses = db.DrugClasses.Select(x => new SelectListItem { Text = x.DrugClassName, Value = x.DrugClassId.ToString() }).ToList();
            ViewBag.vbDrugClasses = lDrugClasses;

            List<Organization> organizationPlacementOrderOrganizations = db.Database.SqlQuery<Organization>("exec spOrganizationPlacementOrderOrganizations @UserId", new SqlParameter("UserId", userId)).ToList();
            var lOrganizations1 = new List<SelectListItem>();
            lOrganizations1 = organizationPlacementOrderOrganizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizationPlacementOrderOrganizations = lOrganizations1;

            List<Organization> organizationPlacementStorageOrganizations = db.Database.SqlQuery<Organization>("spOrganizationPlacementStorageOrganizations @UserId", new SqlParameter("UserId", userId)).ToList();
            var lOrganizations2 = new List<SelectListItem>();
            lOrganizations2 = organizationPlacementStorageOrganizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizationPlacementStorageOrganizations = lOrganizations2;

            List<Organization> organizationPlacementOrganizations = db.Database.SqlQuery<Organization>("spOrganizationPlacementOrganizations @UserId", new SqlParameter("UserId", userId)).ToList();
            var lOrganizations3 = new List<SelectListItem>();
            lOrganizations3 = organizationPlacementOrganizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizationPlacementOrganizations = lOrganizations3;


            var lPlacementStatuses = new List<SelectListItem>();
            lPlacementStatuses = db.PlacementStatuses.Select(x => new SelectListItem { Text = x.PlacementStatusName, Value = x.PlacementStatusId.ToString() }).ToList();
            ViewBag.vbPlacementStatuses = lPlacementStatuses;

            var lStorages = new List<SelectListItem>();
            lStorages = db.Storages.Select(x => new SelectListItem { Text = x.StorageName, Value = x.StorageId.ToString() }).ToList();
            ViewBag.vbStorages = lStorages;

            List<ProductList> products = db.Database.SqlQuery<ProductList>("spPlacementProducts").ToList();
            var lProducts = new List<SelectListItem>();
            lProducts = products.Select(x => new SelectListItem { Text = x.ProductName, Value = x.ProductId.ToString() }).ToList();
            ViewBag.vbProducts = lProducts;

            var lPlacementBases = new List<SelectListItem>();
            lPlacementBases = db.PlacementBases.Select(x => new SelectListItem { Text = x.PlacementBaseName, Value = x.PlacementBaseId.ToString() }).ToList();
            ViewBag.vbPlacementBases = lPlacementBases;
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult StorageIndex()
        {
            using (var db = new StoreContext())
            {
                StorageViewBugs(db);
            }
            return View();
        }

        private void StorageViewBugs(StoreContext db)
        {
            var lDrugClasses = new List<SelectListItem>();
            lDrugClasses = db.DrugClasses.Select(x => new SelectListItem { Text = x.DrugClassName, Value = x.DrugClassId.ToString() }).ToList();
            ViewBag.vbDrugClasses = lDrugClasses;

            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;
            ViewBag.vbOrderOrganizations = lOrganizations;

            var lPlacementStatuses = new List<SelectListItem>();
            lPlacementStatuses = db.PlacementStatuses.Select(x => new SelectListItem { Text = x.PlacementStatusName, Value = x.PlacementStatusId.ToString() }).ToList();
            ViewBag.vbPlacementStatuses = lPlacementStatuses;

            var lStorages = new List<SelectListItem>();
            lStorages = db.Storages.Select(x => new SelectListItem { Text = x.StorageName, Value = x.StorageId.ToString() }).ToList();
            ViewBag.vbStorages = lStorages;

            List<ProductList> products = db.Database.SqlQuery<ProductList>("spPlacementProducts").ToList();
            var lProducts = new List<SelectListItem>();
            lProducts = products.Select(x => new SelectListItem { Text = x.ProductName, Value = x.ProductId.ToString() }).ToList();
            ViewBag.vbProducts = lProducts;

            var lPlacementBases = new List<SelectListItem>();
            lPlacementBases = db.PlacementBases.Select(x => new SelectListItem { Text = x.PlacementBaseName, Value = x.PlacementBaseId.ToString() }).ToList();
            ViewBag.vbPlacementBases = lPlacementBases;
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadOrganizationPlacementDetails([DataSourceRequest]DataSourceRequest request, string placementId, string organizationId,
            string placementBaseId, string orderOrganizationId, string placementStatusId, string startPlacementDate, string terminationPlacementDate,
            string startCorrectionDate, string terminationCorrectionDate, string startConfirmDate, string terminationConfirmDate,
            string startReadyDate, string terminationReadyDate, string startReceiveDate, string terminationReceiveDate)
        {
            using (var db = new StoreContext())
            {
                IQueryable<PlacementDetail> placements = db.PlacementDetails;
                if (placementId != "")
                {
                    int id = Convert.ToInt32(placementId);
                    placements = placements.Where(p => p.PlacementId == id);
                }
                if (organizationId != "")
                {
                    int id = Convert.ToInt32(organizationId);
                    placements = placements.Where(p => p.OrganizationId == id);
                }
                if (placementBaseId != "")
                {
                    int id = Convert.ToInt32(placementBaseId);
                    placements = placements.Where(p => p.PlacementBaseId == id);
                }
                if (orderOrganizationId != "")
                {
                    int id = Convert.ToInt32(orderOrganizationId);
                    placements = placements.Where(p => p.OrganizationId == id);
                }
                if (placementStatusId != "")
                {
                    int id = Convert.ToInt32(placementStatusId);
                    placements = placements.Where(p => p.PlacementStatusId == id);
                }
                if (startPlacementDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startPlacementDate);
                    placements = placements.Where(p => p.PlacementDate >= dt);
                }
                if (terminationPlacementDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationPlacementDate);
                    placements = placements.Where(p => p.PlacementDate <= dt);
                }
                if (startCorrectionDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startCorrectionDate);
                    placements = placements.Where(p => p.CorrectionDate >= dt);
                }
                if (terminationCorrectionDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationCorrectionDate);
                    placements = placements.Where(p => p.CorrectionDate <= dt);
                }
                if (startConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startConfirmDate);
                    placements = placements.Where(p => p.ConfirmDate >= dt);
                }
                if (terminationConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationConfirmDate);
                    placements = placements.Where(p => p.ConfirmDate <= dt);
                }
                if (startReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startReadyDate);
                    placements = placements.Where(p => p.ReadyDate >= dt);
                }
                if (terminationReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationReadyDate);
                    placements = placements.Where(p => p.ReadyDate <= dt);
                }
                if (startReceiveDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startReceiveDate);
                    placements = placements.Where(p => p.ReceiveDate >= dt);
                }
                if (terminationReceiveDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationReceiveDate);
                    placements = placements.Where(p => p.ReceiveDate <= dt);
                }
                DataSourceResult result = placements.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadStoragePlacementDetails([DataSourceRequest]DataSourceRequest request, string placementId, string organizationId,
            string placementBaseId, string orderOrganizationId, string placementStatusId, string startPlacementDate, string terminationPlacementDate,
            string startCorrectionDate, string terminationCorrectionDate, string startConfirmDate, string terminationConfirmDate,
            string startReadyDate, string terminationReadyDate, string startReceiveDate, string terminationReceiveDate)
        {
            using (var db = new StoreContext())
            {
                IQueryable<PlacementDetail> placements = db.PlacementDetails;
                if (placementId != "")
                {
                    int id = Convert.ToInt32(placementId);
                    placements = placements.Where(p => p.PlacementId == id);
                }
                if (organizationId != "")
                {
                    int id = Convert.ToInt32(organizationId);
                    placements = placements.Where(p => p.OrganizationId == id);
                }
                if (placementBaseId != "")
                {
                    int id = Convert.ToInt32(placementBaseId);
                    placements = placements.Where(p => p.PlacementBaseId == id);
                }
                if (orderOrganizationId != "")
                {
                    int id = Convert.ToInt32(orderOrganizationId);
                    placements = placements.Where(p => p.OrganizationId == id);
                }
                if (placementStatusId != "")
                {
                    int id = Convert.ToInt32(placementStatusId);
                    placements = placements.Where(p => p.PlacementStatusId == id);
                }
                if (startPlacementDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startPlacementDate);
                    placements = placements.Where(p => p.PlacementDate >= dt);
                }
                if (terminationPlacementDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationPlacementDate);
                    placements = placements.Where(p => p.PlacementDate <= dt);
                }
                if (startCorrectionDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startCorrectionDate);
                    placements = placements.Where(p => p.CorrectionDate >= dt);
                }
                if (terminationCorrectionDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationCorrectionDate);
                    placements = placements.Where(p => p.CorrectionDate <= dt);
                }
                if (startConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startConfirmDate);
                    placements = placements.Where(p => p.ConfirmDate >= dt);
                }
                if (terminationConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationConfirmDate);
                    placements = placements.Where(p => p.ConfirmDate <= dt);
                }
                if (startReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startReadyDate);
                    placements = placements.Where(p => p.ReadyDate >= dt);
                }
                if (terminationReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationReadyDate);
                    placements = placements.Where(p => p.ReadyDate <= dt);
                }
                if (startReceiveDate != "")
                {
                    DateTime dt = Convert.ToDateTime(startReceiveDate);
                    placements = placements.Where(p => p.ReceiveDate >= dt);
                }
                if (terminationReceiveDate != "")
                {
                    DateTime dt = Convert.ToDateTime(terminationReceiveDate);
                    placements = placements.Where(p => p.ReceiveDate <= dt);
                }
                DataSourceResult result = placements.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole,storagerole")]
        public ActionResult ReadPlacementItemDetails([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<PlacementItemDetails> items = db.PlacementItemDetails.Where(p => p.PlacementId == id);
                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole,storagerole")]
        public ActionResult ReadPlacementItemProductDetails([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<PlacementItemProductDetails> items = db.PlacementItemProductDetails.Where(p => p.PlacementItemId == id);
                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadPlacementItems([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<PlacementItem> placmentItem = db.PlacementItems.Where(p => p.PlacementId == id);
                DataSourceResult result = placmentItem.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult OrganizationPlacementTemplate(int? placementId)
        {
            using (var db = new StoreContext())
            {
                OrganizationViewBugs(db);
                Placement item;
                if (placementId == 0)
                {
                    item = new Placement();
                }
                else
                {
                    item = db.Placements.Find(placementId);
                }
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("OrganizationPlacementTemplate", item);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult PlacementItemProductTemplate(int? placementItemProductId, int placementItemId)
        {
            using (var db = new StoreContext())
            {
                if (placementItemProductId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                StorageViewBugs(db);
                PlacementItemProduct item;
                if (placementItemProductId == 0)
                {
                    item = new PlacementItemProduct();
                    item.PlacementItemId = placementItemId;
                }
                else
                {
                    item = db.PlacementItemProducts.Find(placementItemProductId);
                }
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("PlacementItemProductTemplate", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult SavePlacement(Placement placement)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = (from p in db.Placements where p.PlacementId == placement.PlacementId select p).Count();
                    if (cnt == 0)
                    {
                        if (placement.PlacementItems != null)
                        {

                            foreach (var item in placement.PlacementItems)
                            {
                                if (item.RecordStatus == 1)
                                {
                                    item.Placement = placement;
                                    db.PlacementItems.Add(item);
                                }
                            }
                        }
                        db.Placements.Add(placement);
                    }
                    else
                    {
                        if (placement.PlacementItems != null)
                        {
                            foreach (var item in placement.PlacementItems)
                            {
                                if (item.RecordStatus == 1)
                                {
                                    item.Placement = placement;
                                    db.PlacementItems.Add(item);
                                }
                                else if (item.RecordStatus == 2)
                                {
                                    db.PlacementItems.Attach(item);
                                    db.Entry(item).State = EntityState.Modified;
                                }
                                else if (item.RecordStatus == 3)
                                {

                                    PlacementItem rPlacementItem = db.PlacementItems.Find(item.PlacementItemId);
                                    db.PlacementItems.Remove(rPlacementItem);
                                }
                            }
                        }
                        db.Placements.Attach(placement);
                        db.Entry(placement).State = EntityState.Modified;
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

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult SavePlacementItemProduct(PlacementItemProduct placementItemProduct)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    PlacementItem placementItem = db.PlacementItems.Find(placementItemProduct.PlacementItemId);
                    DrugClass drugClass = db.DrugClasses.Find(placementItem.DrugClassId);
                    Product product = db.Products.Find(placementItemProduct.ProductId);
                    DrugCategory drugCategory = db.DrugCategories.Find(drugClass.DrugCategoryId);
                    placementItemProduct.ItemQuantity = Convert.ToDouble(placementItemProduct.Quantity) / Convert.ToDouble(drugCategory.UnitItemQuantity);
                    placementItemProduct.UnitCost = product.UnitCost;
                    placementItemProduct.TotalCost = placementItemProduct.UnitCost * (Convert.ToDouble(placementItemProduct.Quantity) / Convert.ToDouble(drugCategory.UnitItemQuantity));
                    int? cnt = db.PlacementItemProducts.Where(p => p.PlacementItemProductId == placementItemProduct.PlacementItemProductId).Count();
                    if (cnt == 0)
                    {
                        db.PlacementItemProducts.Add(placementItemProduct);
                    }
                    else
                    {
                        db.PlacementItemProducts.Attach(placementItemProduct);
                        db.Entry(placementItemProduct).State = EntityState.Modified;
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
        public ActionResult DeletePlacement(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Placement item = db.Placements.Find(id);
                    db.Placements.Attach(item);
                    db.Placements.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult DeletePlacementItemProduct(string id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int placementItemProductId = Convert.ToInt32(id);
                    PlacementItemProduct item = db.PlacementItemProducts.Find(placementItemProductId);
                    db.PlacementItemProducts.Remove(item);
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
        public ActionResult PlacementDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                PlacementDetail placementdetails = db.PlacementDetails.Find(id);
                if (placementdetails == null)
                {
                    return HttpNotFound();
                }
                return View("PlacementDetails", placementdetails);
            }

        }

        [Authorize(Roles = "storagerole")]
        public ActionResult CurrentCountInfo([DataSourceRequest]DataSourceRequest request, string productId, string placementItemId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new StoreContext())
            {
                List<CurrentStoreStatus> lst = db.Database.SqlQuery<CurrentStoreStatus>("spCurrentStoreStatus @ProductId, @PlacementItemId", new SqlParameter("ProductId", productId), new SqlParameter("PlacementItemId", placementItemId)).ToList();
                DataSourceResult result = lst.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }


        /////////////////////////////////////////////////////////////////
        [Authorize(Roles = "organizationrole")]
        public ActionResult RepresentPlacement(int? id)
        {
            using (var db = new StoreContext())
            {
                var item = new PlacementRepresentation();
                Placement placement = db.Placements.Find(id);
                item.PlacementDate = placement.PlacementDate;
               
                item.PlacementId = placement.PlacementId;
                return View(item);
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult Represent(PlacementRepresentation placementRepresentation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        Placement item = db.Placements.Find(placementRepresentation.PlacementId);
                        item.PlacementDate = Convert.ToDateTime(placementRepresentation.PlacementDate);
                        item.PlacementStatusId = 1;
                        db.Placements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return View("RepresentPlacement", placementRepresentation);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ConfirmPlacement(int? id)
        {
            using (var db = new StoreContext())
            {
                var lPlacementStatuses = new List<SelectListItem>();
                lPlacementStatuses = db.PlacementStatuses.Where(p => p.PlacementStatusId == 3 || p.PlacementStatusId == 4).Select(x => new SelectListItem { Text = x.PlacementStatusName, Value = x.PlacementStatusId.ToString() }).ToList();
                ViewBag.vbPlacementStatuses = lPlacementStatuses;

                Placement placement = db.Placements.Find(id);
                var item = new PlacementConfirmation();
                item.PlacementId = placement.PlacementId;
                item.CorrectionDate = placement.CorrectionDate;
                //item.PlacementStatusId = placement.PlacementStatusId;
                item.ConfirmDate = placement.ConfirmDate;
                return View("ConfirmPlacement", item);
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult Confirm(PlacementConfirmation placementConfirmation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        Placement item = db.Placements.Find(placementConfirmation.PlacementId);
                        item.ConfirmDate = Convert.ToDateTime(placementConfirmation.ConfirmDate);
                        item.PlacementStatusId = placementConfirmation.PlacementStatusId; //Կարգավիճակ: --Համաձայնեցված կամ մերժված--
                        db.Placements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    using (var db = new StoreContext())
                    {
                        var lPlacementStatuses = new List<SelectListItem>();
                        lPlacementStatuses = db.PlacementStatuses.Where(p => p.PlacementStatusId == 3 || p.PlacementStatusId == 4).Select(x => new SelectListItem { Text = x.PlacementStatusName, Value = x.PlacementStatusId.ToString() }).ToList();
                        ViewBag.vbPlacementStatuses = lPlacementStatuses;
                    }
                    return View("ConfirmPlacement", placementConfirmation);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReceivePlacement(int? id)
        {
            using (var db = new StoreContext())
            {
                var item = new PlacementReception();
                Placement placement = db.Placements.Find(id);
                item.ReceiveDate = placement.ReceiveDate;
                item.ReleaseDate = placement.ReleaseDate;
                item.PlacementId = placement.PlacementId;
                return View(item);
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult Receive(PlacementReception placementReception)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        Placement item = db.Placements.Find(placementReception.PlacementId);
                        item.ReceiveDate = Convert.ToDateTime(placementReception.ReceiveDate);
                        item.PlacementStatusId = 7; //Կարգավիճակ: --Հիմնարկ մուտքագրված--
                        db.Placements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return View("ReceivePlacement", placementReception);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult CorrectPlacement(int? id)
        {
            using (var db = new StoreContext())
            {
                var item = new PlacementCorrection();
                Placement placement = db.Placements.Find(id);
                item.CorrectionDate = placement.CorrectionDate;
                item.PlacementDate = placement.PlacementDate;
                item.PlacementId = placement.PlacementId;
                return View(item);
            }
        }

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult Correct(PlacementCorrection placementCorrection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        Placement item = db.Placements.Find(placementCorrection.PlacementId);
                        item.CorrectionDate = Convert.ToDateTime(placementCorrection.CorrectionDate);
                        item.PlacementStatusId = 2; //Կարգավիճակ: --Բավարարված--
                        db.Placements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return View("CorrectPlacement", placementCorrection);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReleasePlacement(int? id)
        {
            using (var db = new StoreContext())
            {
                var item = new PlacementRelease();
                Placement placement = db.Placements.Find(id);
                item.ReleaseDate = placement.ReleaseDate;
                item.ReadyDate = placement.ReadyDate;
                item.PlacementId = placement.PlacementId;
                return View(item);
            }
        }

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult Release(PlacementRelease placementRelease)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        Placement item = db.Placements.Find(placementRelease.PlacementId);
                        item.ReleaseDate = Convert.ToDateTime(placementRelease.ReleaseDate);
                        item.PlacementStatusId = 6; //Կարգավիճակ: --Ստացվել է պահեստից--
                        db.Placements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return View("ReleasePlacement", placementRelease);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}