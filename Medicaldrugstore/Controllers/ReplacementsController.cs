using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Medicaldrugstore.Controllers
{
    public class ReplacementsController : Controller
    {
        readonly string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        [Authorize(Roles = "organizationrole")]
        public ActionResult Source()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            return View();
        }

        [Authorize(Roles = "confirmreplacementrole")]
        public ActionResult Supervisor()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            return View();
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult Destination()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            return View();
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult Storage()
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

            //////
            var lSourceOrganizations = new List<SelectListItem>();
            lSourceOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbSourceOrganizations = lSourceOrganizations;

            var lDestinationOrganizations = new List<SelectListItem>();
            lDestinationOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbDestinationOrganizations = lDestinationOrganizations;

            var lConfirmOrganizations = new List<SelectListItem>();
            lConfirmOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbConfirmOrganizations = lConfirmOrganizations;
            /////////


            var lStorages = new List<SelectListItem>();
            lStorages = db.Storages.Select(x => new SelectListItem { Text = x.StorageName, Value = x.StorageId.ToString() }).ToList();
            ViewBag.vbStorages = lStorages;

            List<ProductList> products = db.Database.SqlQuery<ProductList>("spReplacementProducts").ToList();
            var lProducts = new List<SelectListItem>();
            lProducts = products.Select(x => new SelectListItem { Text = x.ProductName, Value = x.ProductId.ToString() }).ToList();
            ViewBag.vbProducts = lProducts;

            var lReplacementStatuses = new List<SelectListItem>();
            lReplacementStatuses = db.ReplacementStatuses.Select(x => new SelectListItem { Text = x.ReplacementStatusName, Value = x.ReplacementStatusId.ToString() }).ToList();
            ViewBag.vbReplacementStatuses = lReplacementStatuses;

            var lReplacementBases = new List<SelectListItem>();
            lReplacementBases = db.ReplacementBases.Select(x => new SelectListItem { Text = x.ReplacementBaseName, Value = x.ReplacementBaseId.ToString() }).ToList();
            ViewBag.vbReplacementBases = lReplacementBases;

        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadSourceReplacements([DataSourceRequest]DataSourceRequest request,
            string srcOrgID, string dstOrgID, string cnfOrgID, string rplBaseID,
            string stRplBaseDate, string trRplBaseDate,
            string rplStatusID, string stRplDate, string trRplDate,
            string stConfirmDate, string trConfirmDate,
            string stReadyDate, string trReadyDate
            )
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReplacementDetails> replacements = db.ReplacementDetails;
                if (srcOrgID != "")
                {
                    int id = Convert.ToInt32(srcOrgID);
                    replacements = replacements.Where(p => p.SourceOrganizationId == id);
                }
                if (dstOrgID != "")
                {
                    int id = Convert.ToInt32(dstOrgID);
                    replacements = replacements.Where(p => p.DestinationOrganizationId == id);
                }
                if (cnfOrgID != "")
                {
                    int id = Convert.ToInt32(cnfOrgID);
                    replacements = replacements.Where(p => p.ConfirmOrganizationId == id);
                }
                if (rplBaseID != "")
                {
                    int id = Convert.ToInt32(rplBaseID);
                    replacements = replacements.Where(p => p.ReplacementBaseId == id);
                }
                if (stRplBaseDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stRplBaseDate);
                    replacements = replacements.Where(p => p.ReplacementBaseDate >= dt);
                }
                if (trRplBaseDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trRplBaseDate);
                    replacements = replacements.Where(p => p.ReplacementBaseDate <= dt);
                }
                if (rplStatusID != "")
                {
                    int id = Convert.ToInt32(rplStatusID);
                    replacements = replacements.Where(p => p.ReplacementStatusId == id);
                }
                if (stRplDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stRplDate);
                    replacements = replacements.Where(p => p.ReplacementDate >= dt);
                }
                if (trRplDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trRplDate);
                    replacements = replacements.Where(p => p.ReplacementDate <= dt);
                }
                if (stConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stConfirmDate);
                    replacements = replacements.Where(p => p.ConfirmDate >= dt);
                }
                if (trConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trConfirmDate);
                    replacements = replacements.Where(p => p.ConfirmDate <= dt);
                }

                if (stReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stReadyDate);
                    replacements = replacements.Where(p => p.ReadyDate >= dt);
                }
                if (trReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trReadyDate);
                    replacements = replacements.Where(p => p.ReadyDate <= dt);
                }
                DataSourceResult result = replacements.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReadDestinationReplacements([DataSourceRequest]DataSourceRequest request,
            string srcOrgID, string dstOrgID, string cnfOrgID, string rplBaseID,
            string stRplBaseDate, string trRplBaseDate,
            string rplStatusID, string stRplDate, string trRplDate,
            string stConfirmDate, string trConfirmDate,
            string stReadyDate, string trReadyDate
            )
        {
            using (var db = new StoreContext())
            {
                IQueryable<Replacement> replacements = db.Replacements;
                if (srcOrgID != "")
                {
                    int id = Convert.ToInt32(srcOrgID);
                    replacements = replacements.Where(p => p.SourceOrganizationId == id);
                }
                if (dstOrgID != "")
                {
                    int id = Convert.ToInt32(dstOrgID);
                    replacements = replacements.Where(p => p.DestinationOrganizationId == id);
                }
                if (cnfOrgID != "")
                {
                    int id = Convert.ToInt32(cnfOrgID);
                    replacements = replacements.Where(p => p.ConfirmOrganizationId == id);
                }
                if (rplBaseID != "")
                {
                    int id = Convert.ToInt32(rplBaseID);
                    replacements = replacements.Where(p => p.ReplacementBaseId == id);
                }
                if (stRplBaseDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stRplBaseDate);
                    replacements = replacements.Where(p => p.ReplacementBaseDate >= dt);
                }
                if (trRplBaseDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trRplBaseDate);
                    replacements = replacements.Where(p => p.ReplacementBaseDate <= dt);
                }
                if (rplStatusID != "")
                {
                    int id = Convert.ToInt32(rplStatusID);
                    replacements = replacements.Where(p => p.ReplacementStatusId == id);
                }
                if (stRplDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stRplDate);
                    replacements = replacements.Where(p => p.ReplacementDate >= dt);
                }
                if (trRplDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trRplDate);
                    replacements = replacements.Where(p => p.ReplacementDate <= dt);
                }
                if (stConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stConfirmDate);
                    replacements = replacements.Where(p => p.ConfirmDate >= dt);
                }
                if (trConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trConfirmDate);
                    replacements = replacements.Where(p => p.ConfirmDate <= dt);
                }

                if (stReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stReadyDate);
                    replacements = replacements.Where(p => p.ReadyDate >= dt);
                }
                if (trReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trReadyDate);
                    replacements = replacements.Where(p => p.ReadyDate <= dt);
                }
                DataSourceResult result = replacements.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "confirmreplacementrole")]
        public ActionResult ReadSupervisorReplacements([DataSourceRequest]DataSourceRequest request,
            string srcOrgID, string dstOrgID, string cnfOrgID, string rplBaseID,
            string stRplBaseDate, string trRplBaseDate,
            string rplStatusID, string stRplDate, string trRplDate,
            string stConfirmDate, string trConfirmDate,
            string stReadyDate, string trReadyDate
            )
        {
            using (var db = new StoreContext())
            {
                IQueryable<Replacement> replacements = db.Replacements;
                if (srcOrgID != "")
                {
                    int id = Convert.ToInt32(srcOrgID);
                    replacements = replacements.Where(p => p.SourceOrganizationId == id);
                }
                if (dstOrgID != "")
                {
                    int id = Convert.ToInt32(dstOrgID);
                    replacements = replacements.Where(p => p.DestinationOrganizationId == id);
                }
                if (cnfOrgID != "")
                {
                    int id = Convert.ToInt32(cnfOrgID);
                    replacements = replacements.Where(p => p.ConfirmOrganizationId == id);
                }
                if (rplBaseID != "")
                {
                    int id = Convert.ToInt32(rplBaseID);
                    replacements = replacements.Where(p => p.ReplacementBaseId == id);
                }
                if (stRplBaseDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stRplBaseDate);
                    replacements = replacements.Where(p => p.ReplacementBaseDate >= dt);
                }
                if (trRplBaseDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trRplBaseDate);
                    replacements = replacements.Where(p => p.ReplacementBaseDate <= dt);
                }
                if (rplStatusID != "")
                {
                    int id = Convert.ToInt32(rplStatusID);
                    replacements = replacements.Where(p => p.ReplacementStatusId == id);
                }
                if (stRplDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stRplDate);
                    replacements = replacements.Where(p => p.ReplacementDate >= dt);
                }
                if (trRplDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trRplDate);
                    replacements = replacements.Where(p => p.ReplacementDate <= dt);
                }
                if (stConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stConfirmDate);
                    replacements = replacements.Where(p => p.ConfirmDate >= dt);
                }
                if (trConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trConfirmDate);
                    replacements = replacements.Where(p => p.ConfirmDate <= dt);
                }

                if (stReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stReadyDate);
                    replacements = replacements.Where(p => p.ReadyDate >= dt);
                }
                if (trReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trReadyDate);
                    replacements = replacements.Where(p => p.ReadyDate <= dt);
                }
                DataSourceResult result = replacements.ToDataSourceResult(request);
                return Json(result);
            }
        }

       // [Authorize(Roles = "storagerole")]
        public ActionResult ReadStorageReplacements([DataSourceRequest]DataSourceRequest request,
            string srcOrgID, string dstOrgID, string cnfOrgID, string rplBaseID,
            string stRplBaseDate, string trRplBaseDate,
            string rplStatusID, string stRplDate, string trRplDate,
            string stConfirmDate, string trConfirmDate,
            string stReadyDate, string trReadyDate
            )
        {
            using (var db = new StoreContext())
            {
                IQueryable<Replacement> replacements = db.Replacements;
                if (srcOrgID != "")
                {
                    int id = Convert.ToInt32(srcOrgID);
                    replacements = replacements.Where(p => p.SourceOrganizationId == id);
                }
                if (dstOrgID != "")
                {
                    int id = Convert.ToInt32(dstOrgID);
                    replacements = replacements.Where(p => p.DestinationOrganizationId == id);
                }
                if (cnfOrgID != "")
                {
                    int id = Convert.ToInt32(cnfOrgID);
                    replacements = replacements.Where(p => p.ConfirmOrganizationId == id);
                }
                if (rplBaseID != "")
                {
                    int id = Convert.ToInt32(rplBaseID);
                    replacements = replacements.Where(p => p.ReplacementBaseId == id);
                }
                if (stRplBaseDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stRplBaseDate);
                    replacements = replacements.Where(p => p.ReplacementBaseDate >= dt);
                }
                if (trRplBaseDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trRplBaseDate);
                    replacements = replacements.Where(p => p.ReplacementBaseDate <= dt);
                }
                if (rplStatusID != "")
                {
                    int id = Convert.ToInt32(rplStatusID);
                    replacements = replacements.Where(p => p.ReplacementStatusId == id);
                }
                if (stRplDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stRplDate);
                    replacements = replacements.Where(p => p.ReplacementDate >= dt);
                }
                if (trRplDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trRplDate);
                    replacements = replacements.Where(p => p.ReplacementDate <= dt);
                }
                if (stConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stConfirmDate);
                    replacements = replacements.Where(p => p.ConfirmDate >= dt);
                }
                if (trConfirmDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trConfirmDate);
                    replacements = replacements.Where(p => p.ConfirmDate <= dt);
                }

                if (stReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(stReadyDate);
                    replacements = replacements.Where(p => p.ReadyDate >= dt);
                }
                if (trReadyDate != "")
                {
                    DateTime dt = Convert.ToDateTime(trReadyDate);
                    replacements = replacements.Where(p => p.ReadyDate <= dt);
                }
                DataSourceResult result = replacements.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReplacementTemplate(int? id)
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

                var lReplacementBases = new List<SelectListItem>();
                lReplacementBases = db.ReplacementBases.Select(x => new SelectListItem { Text = x.ReplacementBaseName, Value = x.ReplacementBaseId.ToString() }).ToList();
                ViewBag.vbReplacementBases = lReplacementBases;

                List<ProductList> products = db.Database.SqlQuery<ProductList>("spReplacementProducts").ToList();
                var lProducts = new List<SelectListItem>();
                lProducts = products.Select(x => new SelectListItem { Text = x.ProductName, Value = x.ProductId.ToString() }).ToList();
                ViewBag.vbProducts = lProducts;

                Replacement item;
                if (id == 0)
                {
                    item = new Replacement();
                }
                else
                {
                    item = db.Replacements.Find(id);
                }

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("ReplacementTemplate", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult SaveReplacement(Replacement replacement)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.Replacements.Where(p => p.ReplacementId == replacement.ReplacementId).Count();
                    if (cnt == 0)
                    {
                        db.Replacements.Add(replacement);
                        if (replacement.ReplacementProduct != null)
                        {
                            foreach (var item in replacement.ReplacementProduct)
                            {
                                if (item.RecordStatus == 1)
                                {
                                    item.Replacement = replacement;
                                    db.ReplacementProducts.Add(item);
                                }
                            }
                        }                        
                    }
                    else
                    {
                        Replacement mReplacement = db.Replacements.Find(replacement.ReplacementId);
                        mReplacement.ReplacementId = replacement.ReplacementId;
                        mReplacement.SourceOrganizationId  = replacement.SourceOrganizationId;
                        mReplacement.DestinationOrganizationId = replacement.DestinationOrganizationId;
                        mReplacement.ConfirmOrganizationId = replacement.ConfirmOrganizationId;
                        mReplacement.ReplacementBaseDate  = replacement.ReplacementBaseDate;
                        mReplacement.ReplacementBaseId  = replacement.ReplacementBaseId;
                        mReplacement.ReplacementBaseText  = replacement.ReplacementBaseText;

                        db.Entry(mReplacement).State = EntityState.Modified;

                        if (replacement.ReplacementProduct != null)
                        {
                            foreach (var item in replacement.ReplacementProduct)
                            {
                                if (item.RecordStatus == 1)
                                {
                                    item.Replacement = mReplacement ;
                                    db.ReplacementProducts.Add(item);
                                }
                                else if (item.RecordStatus == 2)
                                {
                                    db.ReplacementProducts.Attach(item);
                                    db.Entry(item).State = EntityState.Modified;
                                }
                                else if (item.RecordStatus == 3)
                                {
                                    ReplacementProduct rReplacementProduct = db.ReplacementProducts.Find(item.ReplacementProductId);
                                    db.ReplacementProducts.Remove(rReplacementProduct);
                                }
                            }
                        }
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
        public ActionResult DeleteReplacement(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Replacement item = db.Replacements.Find(id);
                    db.Replacements.Attach(item);
                    db.Replacements.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole,storagerole,confirmreplacementrole")]
        public ActionResult ReadReplacementProducts([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReplacementProduct> item = db.ReplacementProducts.Where(p => p.ReplacementId == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ReplacementProductTemplate(int? replacementProductId, int replacementId)
        {
            using (var db = new StoreContext())
            {
                if (replacementProductId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                List<ProductList> products = db.Database.SqlQuery<ProductList>("spReplacementProducts").ToList();
                var lProducts = new List<SelectListItem>();
                lProducts = products.Select(x => new SelectListItem { Text = x.ProductName, Value = x.ProductId.ToString() }).ToList();
                ViewBag.vbProducts = lProducts;

                ReplacementProduct item;

                if (replacementProductId == 0)
                {
                    item = new ReplacementProduct();
                    item.ReplacementId = replacementId;
                }
                else
                {
                    item = db.ReplacementProducts.Find(replacementProductId);
                }

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("ReplacementProductTemplate", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult SaveReplacementProduct(ReplacementProduct replacementProduct)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? productId = Convert.ToInt32(replacementProduct.ProductId);
                    Product product = db.Products.Find(productId);
                    Drug drug = db.Drugs.Find(product.DrugId);
                    DrugClass drugClass = db.DrugClasses.Find(drug.DrugClassId);

                    int? unitItemQuantity = db.DrugCategories.Find(drugClass.DrugCategoryId).UnitItemQuantity;
                    double? unitCost = drug.UnitCost;
                    Replacement rpItem = db.Replacements.Find(Convert.ToInt32(replacementProduct.ReplacementId));

                    int? replacementProductId = Convert.ToInt32(replacementProduct.ReplacementProductId);
                    if (replacementProductId == 0)
                    {
                        var entity = new ReplacementProduct
                        {
                            ReplacementId = Convert.ToInt32(replacementProduct.ReplacementId),
                            ProductId = productId,
                            Quantity = Convert.ToInt32(replacementProduct.Quantity),

                            ItemQuantity = Convert.ToDouble(replacementProduct.Quantity) / Convert.ToDouble(unitItemQuantity),
                            UnitCost = unitCost,
                            TotalCost = unitCost * (Convert.ToDouble(replacementProduct.Quantity) / Convert.ToDouble(unitItemQuantity))
                        };
                        db.ReplacementProducts.Add(entity);

                        double? tmpSum = (from p in db.ReplacementProducts where p.ReplacementId == rpItem.ReplacementId select (double?) p.TotalCost).Sum() ?? 0;
                        rpItem.ReplacementSum = tmpSum + entity.TotalCost;
                    }
                    else
                    {
                        ReplacementProduct item = db.ReplacementProducts.Find(replacementProductId);
                        item.ProductId = productId;
                        item.Quantity = Convert.ToInt32(replacementProduct.Quantity);
                        item.ItemQuantity = Convert.ToDouble(replacementProduct.Quantity) / Convert.ToDouble(unitItemQuantity);
                        item.UnitCost = unitCost;
                        item.TotalCost = unitCost * (Convert.ToDouble(replacementProduct.Quantity) / Convert.ToDouble(unitItemQuantity));
                        db.ReplacementProducts.Attach(item);
                        db.Entry(item).State = EntityState.Modified;

                        double? tmpSum = (from p in db.ReplacementProducts where p.ReplacementId == rpItem.ReplacementId && p.ReplacementProductId != item.ReplacementProductId select (double?) p.TotalCost).Sum() ?? 0;
                        rpItem.ReplacementSum = tmpSum + item.TotalCost;

                    }

                    db.Replacements.Attach(rpItem);
                    db.Entry(rpItem).State = EntityState.Modified;


                    db.SaveChanges();
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult DeleteReplacementProduct(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReplacementProduct item = db.ReplacementProducts.Find(id);
                    db.ReplacementProducts.Attach(item);
                    db.ReplacementProducts.Remove(item);
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
        public ActionResult ReadReplacementProductStorages([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReplacementProductStorage> item = db.ReplacementProductStorages.Where(p => p.ReplacementProductId == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReplacementProductStorageTemplate(int? replacementProductStorageid, int replacementProductId)
        {
            using (var db = new StoreContext())
            {
                if (replacementProductStorageid == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                FillViewBugs(db);

                ReplacementProductStorage item;

                if (replacementProductStorageid == 0)
                {
                    item = new ReplacementProductStorage();
                    item.ReplacementProductId = replacementProductId;
                }
                else
                {
                    item = db.ReplacementProductStorages.Find(replacementProductStorageid);
                }

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("ReplacementProductStorageTemplate", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult SaveReplacementProductStorage(ReplacementProductStorage replacementProductStorage)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReplacementProduct replacementProduct = db.ReplacementProducts.Find(replacementProductStorage.ReplacementProductId);
                    Product product = db.Products.Find(replacementProduct.ProductId);
                    Drug drug = db.Drugs.Find(product.DrugId);
                    DrugClass drugClass = db.DrugClasses.Find(drug.DrugClassId);
                    DrugCategory drugCategory = db.DrugCategories.Find(drugClass.DrugCategoryId);

                    int? cnt = db.ReplacementProductStorages.Where(p => p.ReplacementProductStorageId == replacementProductStorage.ReplacementProductStorageId).Count();
                    if (cnt == 0)
                    {
                        replacementProductStorage.ProductId = product.ProductId;
                        replacementProductStorage.ItemQuantity = Convert.ToDouble(replacementProductStorage.Quantity) / Convert.ToDouble(drugCategory.UnitItemQuantity);
                        replacementProductStorage.UnitCost = drug.UnitCost;
                        replacementProductStorage.TotalCost = replacementProductStorage.UnitCost * (Convert.ToDouble(replacementProductStorage.Quantity) / Convert.ToDouble(replacementProductStorage.ItemQuantity));
                        db.ReplacementProductStorages.Add(replacementProductStorage);
                    }
                    else
                    {
                        replacementProductStorage.ProductId = product.ProductId;
                        replacementProductStorage.ItemQuantity = Convert.ToDouble(replacementProductStorage.Quantity) / Convert.ToDouble(drugCategory.UnitItemQuantity);
                        replacementProductStorage.UnitCost = drug.UnitCost;
                        replacementProductStorage.TotalCost = replacementProductStorage.UnitCost * (Convert.ToDouble(replacementProductStorage.Quantity) / Convert.ToDouble(replacementProductStorage.ItemQuantity));
                        db.ReplacementProductStorages.Attach(replacementProductStorage);
                        db.Entry(replacementProductStorage).State = EntityState.Modified;
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
        public ActionResult DeleteReplacementProductStorage(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReplacementProductStorage item = db.ReplacementProductStorages.Find(id);
                    db.ReplacementProductStorages.Attach(item);
                    db.ReplacementProductStorages.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "organizationrole,storagerole,confirmreplacementrole")]
        public ActionResult ReplacementDetails([DataSourceRequest]DataSourceRequest request, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                var details = db.ReplacementDetails.Find(id);
                if (details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("ReplacementDetails", details);
                }
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult RepresentReplacement(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Replacement replacement = db.Replacements.Find(id);
                var item = new Representation();
                item.ReplacementId = replacement.ReplacementId;
                item.ReplacementDate = replacement.ReplacementDate;

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("RepresentReplacement", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult Represent(Representation representation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new StoreContext())
                    {
                        Replacement item = db.Replacements.Find(Convert.ToInt32(representation.ReplacementId));
                        item.ReplacementDate = Convert.ToDateTime(representation.ReplacementDate);
                        item.ReplacementStatusId = 1; //Ներկայացված
                        db.Replacements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
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
            else
            {
                return View("RepresentReplacement", representation);
            }
        }

        [Authorize(Roles = "confirmreplacementrole")]
        public ActionResult ConfirmReplacement(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Replacement replacement = db.Replacements.Find(id);
                var item = new Confirmation();
                item.ReplacementId = replacement.ReplacementId;
                item.ConfirmDate = replacement.ConfirmDate;

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("ConfirmReplacement", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "confirmreplacementrole")]
        public ActionResult Confirm(Confirmation confirmation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new StoreContext())
                    {
                        Replacement item = db.Replacements.Find(Convert.ToInt32(confirmation.ReplacementId));
                        item.ConfirmDate = Convert.ToDateTime(confirmation.ConfirmDate);
                        item.ReplacementStatusId = 2; // Համաձայնեցված
                        db.Replacements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
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
            else
            {
                return View("ConfirmReplacement", confirmation);
            }
        }

        [Authorize(Roles = "organizationrole")]
        public ActionResult ProvideReplacement(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Replacement replacement = db.Replacements.Find(id);
                var item = new Provision();
                item.ReplacementId = replacement.ReplacementId;
                item.ProvisionDate = replacement.ProvisionDate;

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("ProvideReplacement", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole")]
        public ActionResult Provide(Provision provision)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new StoreContext())
                    {
                        Replacement item = db.Replacements.Find(Convert.ToInt32(provision.ReplacementId));
                        item.ProvisionDate = Convert.ToDateTime(provision.ProvisionDate);
                        item.ReplacementStatusId = 4; // Տրամադրվել է
                        db.Replacements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
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
            else
            {
                return View("ProvideReplacement", provision);
            }
        }

        [Authorize(Roles = "organizationrole,storagerole")]
        public ActionResult ReceiveReplacement(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Replacement replacement = db.Replacements.Find(id);
                var item = new Reception();
                item.ReplacementId = replacement.ReplacementId;
                item.ReceiveDate = replacement.ReceiveDate;

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("ReceiveReplacement", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "organizationrole,storagerole")]
        public ActionResult Receive(Reception reception)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new StoreContext())
                    {
                        Replacement item = db.Replacements.Find(Convert.ToInt32(reception.ReplacementId));
                        item.ReceiveDate = Convert.ToDateTime(reception.ReceiveDate);
                        item.ReplacementStatusId = 5; //-Ստացված է

                        db.Replacements.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
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
            else
            {
                return View("ReceiveReplacement", reception);
            }
        }

        public ActionResult ReadProducts([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReplacementProduct> replacmentProduct = db.ReplacementProducts.Where(p => p.ReplacementId == id);
                DataSourceResult result = replacmentProduct.ToDataSourceResult(request);
                return Json(result);
            }
        }
        //public ActionResult StorageUpdateReplacement([DataSourceRequest]DataSourceRequest request, Replacement item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            item.ReplacementStatusId = 4;
        //            db.Replacements.Attach(item);
        //            db.Entry(item).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { item }.ToDataSourceResult(request, ModelState));
        //}
    }
}