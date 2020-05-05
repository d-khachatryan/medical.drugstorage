using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Data.SqlClient;

namespace Medicaldrugstore.Controllers
{
    public class StoragePlacementsController : Controller
    {
        [Authorize(Roles = "storagerole")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            return View();
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

        [Authorize(Roles = "storagerole")]
        public ActionResult CorrectPlacement(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Placement placement = db.Placements.Find(id);
                if (placement == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(placement);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult Correct(string pId, string cDate, string cQuantity)
        {
            using (var db = new StoreContext())
            {
                Placement placement = db.Placements.Find(Convert.ToInt32(pId));
                placement.PlacementStatusId = 2; //Կարգավիճակ: --Բավարարված--
                placement.CorrectionDate = Convert.ToDateTime(cDate);
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

        [Authorize(Roles = "storagerole")]
        public ActionResult ReleasePlacement(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Placement placement = db.Placements.Find(id);
                if (placement == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(placement);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult Release(string pId, string rDate)
        {
            using (var db = new StoreContext())
            {
                Placement placement = db.Placements.Find(Convert.ToInt32(pId));
                placement.PlacementStatusId = 6; //Կարգավիճակ: --Ստացվել է պահեստից--
                placement.ReleaseDate = Convert.ToDateTime(rDate);
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

        [Authorize(Roles = "storagerole")]
        public ActionResult PlacementDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                PlacementDetail placementdetails = db.PlacementDetails.Find(id);
                //foreach (var item in db.PlacementItemDetails.Where(p => p.PlacementId == id).ToList())
                //{
                //    foreach (var itm in db.PlacementItemProductDetails.Where(p => p.PlacementItemId == item.PlacementItemId).ToList())
                //    {
                //        item.PlacementItemProductDetails.Add(itm);
                //    }
                //    placementdetails.PlacementItemDetails.Add(item);
                //}

                if (placementdetails == null)
                {
                    return HttpNotFound();
                }
                return View(placementdetails);
            }

        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadPlacementItems([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<PlacementItem> placements = db.PlacementItems.Where(p => p.PlacementId == id);
                DataSourceResult result = placements.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadPlacementItemProducts([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<PlacementItemProduct> placementitemproducts = db.PlacementItemProducts.Where(p => p.PlacementItemId == id);
                DataSourceResult result = placementitemproducts.ToDataSourceResult(request);
                return Json(result);
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

                FillViewBugs(db);

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

        [Authorize(Roles = "storagerole")]
        public ActionResult DestroyPlacementItemProduct(string pipId)
        {
            using (var db = new StoreContext())
            {
                int placementItemProductId = Convert.ToInt32(pipId);
                PlacementItemProduct pip = db.PlacementItemProducts.Find(placementItemProductId);
                db.PlacementItemProducts.Remove(pip);
                db.SaveChanges();
                if (pip == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return Json("-1", JsonRequestBehavior.AllowGet);
                }
            }
        }

        private void FillViewBugs(StoreContext db)
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
    }
}