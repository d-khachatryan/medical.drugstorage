using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Collections.Generic;
using System;
using System.IO;
using Medicaldrugstore.Helpers;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNet.Identity;

namespace Medicaldrugstore.Controllers
{
    public class DrugClassesController : Controller
    {
        readonly string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        [Authorize(Roles = "storagerole")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                var lProductGroups = new List<SelectListItem>();
                lProductGroups = db.ProductGroups.Select(x => new SelectListItem { Text = x.ProductGroupName, Value = x.ProductGroupId.ToString() }).ToList();
                ViewBag.vbProductGroups = lProductGroups;

                var lProductCategories = new List<SelectListItem>();
                lProductCategories = db.ProductCategorys.Select(x => new SelectListItem { Text = x.ProductCategoryName, Value = x.ProductCategoryId.ToString() }).ToList();
                ViewBag.vbProductCategories = lProductCategories;

                var lDrugCategories = new List<SelectListItem>();
                lDrugCategories = db.DrugCategories.Select(x => new SelectListItem { Text = x.DrugCategoryName, Value = x.DrugCategoryId.ToString() }).ToList();
                ViewBag.vbDrugCategories = lDrugCategories;

                var lDrugTypes = new List<SelectListItem>();
                lDrugTypes = db.DrugTypes.Select(x => new SelectListItem { Text = x.DrugTypeName, Value = x.DrugTypeId.ToString() }).ToList();
                ViewBag.vbDrugTypes = lDrugTypes;

                var lProductTypes = new List<SelectListItem>();
                lProductTypes = db.ProductTypes.Select(x => new SelectListItem { Text = x.ProductTypeName, Value = x.ProductTypeId.ToString() }).ToList();
                ViewBag.vbProductTypes = lProductTypes;
            }
            return View();
        }

        private void DrugClassViewBugs(StoreContext db)
        {
            var lProductCategories = new List<SelectListItem>();
            lProductCategories = db.ProductCategorys.Select(x => new SelectListItem { Text = x.ProductCategoryName, Value = x.ProductCategoryId.ToString() }).ToList();
            ViewBag.vbProductCategories = lProductCategories;

            var lProductGroups = new List<SelectListItem>();
            lProductGroups = db.ProductGroups.Select(x => new SelectListItem { Text = x.ProductGroupName, Value = x.ProductGroupId.ToString() }).ToList();
            ViewBag.vbProductGroups = lProductGroups;

            var lProductTypes = new List<SelectListItem>();
            lProductTypes = db.ProductTypes.Select(x => new SelectListItem { Text = x.ProductTypeName, Value = x.ProductTypeId.ToString() }).ToList();
            ViewBag.vbProductTypes = lProductTypes;

            var lDrugCategories = new List<SelectListItem>();
            lDrugCategories = db.DrugCategories.Select(x => new SelectListItem { Text = x.DrugCategoryName, Value = x.DrugCategoryId.ToString() }).ToList();
            ViewBag.vbDrugCategories = lDrugCategories;

            var lDrugTypes = new List<SelectListItem>();
            lDrugTypes = db.DrugTypes.Select(x => new SelectListItem { Text = x.DrugTypeName, Value = x.DrugTypeId.ToString() }).ToList();
            ViewBag.vbDrugTypes = lDrugTypes;

            var lStorages = new List<SelectListItem>();
            lStorages = db.Storages.Select(x => new SelectListItem { Text = x.StorageName, Value = x.StorageId.ToString() }).ToList();
            ViewBag.vbStorages = lStorages;

            var prmUserId = new SqlParameter("@UserId", SqlDbType.NVarChar);
            prmUserId.Value = userId;
            var lStoreOrganizations = new List<SelectListItem>();
            List<StoreOrganization> storeOrganizations = db.Database.SqlQuery<StoreOrganization>("spStoreOrganizations @UserId", prmUserId).ToList();
            lStoreOrganizations = storeOrganizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbStoreOrganizations = lStoreOrganizations;
        }

        private void DrugViewBugs(StoreContext db, int? storeOrganizationId)
        {
            var lDrugClasses = new List<SelectListItem>();
            lDrugClasses = db.DrugClasses.Select(x => new SelectListItem { Text = x.DrugClassName, Value = x.DrugClassId.ToString() }).ToList();
            ViewBag.vbDrugClasses = lDrugClasses;

            var lProductCategories = new List<SelectListItem>();
            lProductCategories = db.ProductCategorys.Select(x => new SelectListItem { Text = x.ProductCategoryName, Value = x.ProductCategoryId.ToString() }).ToList();
            ViewBag.vbProductCategories = lProductCategories;

            var lProductGroups = new List<SelectListItem>();
            lProductGroups = db.ProductGroups.Select(x => new SelectListItem { Text = x.ProductGroupName, Value = x.ProductGroupId.ToString() }).ToList();
            ViewBag.vbProductGroups = lProductGroups;

            var lProductTypes = new List<SelectListItem>();
            lProductTypes = db.ProductTypes.Select(x => new SelectListItem { Text = x.ProductTypeName, Value = x.ProductTypeId.ToString() }).ToList();
            ViewBag.vbProductTypes = lProductTypes;

            var lUnitTypes = new List<SelectListItem>();
            lUnitTypes = db.UnitTypes.Select(x => new SelectListItem { Text = x.UnitTypeName, Value = x.UnitTypeId.ToString() }).ToList();
            ViewBag.vbUnitTypes = lUnitTypes;

            var lDrugCategories = new List<SelectListItem>();
            lDrugCategories = db.DrugCategories.Select(x => new SelectListItem { Text = x.DrugCategoryName, Value = x.DrugCategoryId.ToString() }).ToList();
            ViewBag.vbDrugCategories = lDrugCategories;

            var lDrugTypes = new List<SelectListItem>();
            lDrugTypes = db.DrugTypes.Select(x => new SelectListItem { Text = x.DrugTypeName, Value = x.DrugTypeId.ToString() }).ToList();
            ViewBag.vbDrugTypes = lDrugTypes;

            var lDrugSources = new List<SelectListItem>();
            lDrugSources = db.DrugSources.Select(x => new SelectListItem { Text = x.DrugSourceName, Value = x.DrugSourceId.ToString() }).ToList();
            ViewBag.vbDrugSources = lDrugSources;

            var lSuppliers = new List<SelectListItem>();
            lSuppliers = db.Suppliers.Select(x => new SelectListItem { Text = x.SupplierName, Value = x.SupplierId.ToString() }).ToList();
            ViewBag.vbSuppliers = lSuppliers;

            var lCountries = new List<SelectListItem>();
            lCountries = db.Countries.Select(x => new SelectListItem { Text = x.CountryName, Value = x.CountryId.ToString() }).ToList();
            ViewBag.vbCountries = lCountries;

            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

            var lStorages = new List<SelectListItem>();
            lStorages = db.Storages.Where(p => p.OrganizationId == storeOrganizationId).Select(x => new SelectListItem { Text = x.StorageName, Value = x.StorageId.ToString() }).ToList();
            ViewBag.vbStorages = lStorages;
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadDrugClasses([DataSourceRequest]DataSourceRequest request, string drugClassName, string genericName, string productCategoryId, string productTypeId, string productGroupId, string drugCategoryId, string drugTypeId, string IsActive)
        {
            using (var db = new StoreContext())
            {

                IQueryable<DrugClassDetail> items = from p in db.DrugClassDetails join o in db.Organizations on p.StoreOrganizationId equals o.OrganizationId join n in db.UserOrganizations on o.OrganizationId equals n.OrganizationId where n.Id == userId && o.IsStorage == true select p;

                if (!string.IsNullOrEmpty(drugClassName))
                {
                    items = items.Where(p => p.DrugClassName.StartsWith(drugClassName));
                }

                if (!string.IsNullOrEmpty(genericName))
                {
                    items = items.Where(p => p.GenericName.StartsWith(genericName));
                }


                if (!string.IsNullOrEmpty(productCategoryId))
                {
                    int id = Convert.ToInt32(productCategoryId);
                    items = items.Where(p => p.ProductCategoryId == id);
                }

                if (!string.IsNullOrEmpty(productTypeId))
                {
                    int id = Convert.ToInt32(productTypeId);
                    items = items.Where(p => p.ProductTypeId == id);
                }

                if (!string.IsNullOrEmpty(productGroupId))
                {
                    int id = Convert.ToInt32(productGroupId);
                    items = items.Where(p => p.ProductGroupId == id);
                }

                if (!string.IsNullOrEmpty(drugCategoryId))
                {
                    int id = Convert.ToInt32(drugCategoryId);
                    items = items.Where(p => p.DrugCategoryId == id);
                }

                if (!string.IsNullOrEmpty(drugTypeId))
                {
                    int id = Convert.ToInt32(drugTypeId);
                    items = items.Where(p => p.DrugTypeId == id);
                }

                bool drugClassStatus = Convert.ToBoolean(IsActive, null);
                items = items.Where(p => p.DrugClassStatus == drugClassStatus);


                DataSourceResult result = items.OrderBy(p => p.DrugCategoryId).ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadDrugs([DataSourceRequest]DataSourceRequest request, string drugClassName, string genericName, string productCategoryId, string productTypeId, string productGroupId, string drugCategoryId, string drugTypeId, string IsActive)
        {
            using (var db = new StoreContext())
            {
                IQueryable<DrugItem> items = from p in db.DrugItems join o in db.Organizations on p.StoreOrganizationId equals o.OrganizationId join n in db.UserOrganizations on o.OrganizationId equals n.OrganizationId where n.Id == userId && o.IsStorage == true select p;


                if (!string.IsNullOrEmpty(drugClassName))
                {
                    items = items.Where(p => p.DrugClassName.StartsWith(drugClassName));
                }

                if (!string.IsNullOrEmpty(genericName))
                {
                    items = items.Where(p => p.GenericName.StartsWith(genericName));
                }


                if (!string.IsNullOrEmpty(productCategoryId))
                {
                    int id = Convert.ToInt32(productCategoryId);
                    items = items.Where(p => p.ProductCategoryId == id);
                }

                if (!string.IsNullOrEmpty(productTypeId))
                {
                    int id = Convert.ToInt32(productTypeId);
                    items = items.Where(p => p.ProductTypeId == id);
                }

                if (!string.IsNullOrEmpty(productGroupId))
                {
                    int id = Convert.ToInt32(productGroupId);
                    items = items.Where(p => p.ProductGroupId == id);
                }

                if (!string.IsNullOrEmpty(drugCategoryId))
                {
                    int id = Convert.ToInt32(drugCategoryId);
                    items = items.Where(p => p.DrugCategoryId == id);
                }

                if (!string.IsNullOrEmpty(drugTypeId))
                {
                    int id = Convert.ToInt32(drugTypeId);
                    items = items.Where(p => p.DrugTypeId == id);
                }

                bool drugClassStatus = Convert.ToBoolean(IsActive, null);
                items = items.Where(p => p.DrugClassStatus == drugClassStatus);




                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadProducts([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ProductDetail> items = db.ProductDetails.Where(p => p.DrugId == id);
                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult DrugClassDetails([DataSourceRequest]DataSourceRequest request, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                DrugClassDetail detail = db.DrugClassDetails.Find(id);
                if (detail == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("DrugClassDetail", detail);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult DrugDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DrugDetail detail = db.DrugDetails.Include(s => s.Files).SingleOrDefault(s => s.DrugId == id);
                if (detail == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("DrugDetail", detail);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult CreateDrugClass()
        {
            using (var db = new StoreContext())
            {
                DrugClassViewBugs(db);

                var item = new DrugClass();
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("DrugClassTemplate", item);
                }
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult UpdateDrugClass(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                DrugClassViewBugs(db);

                DrugClass item = db.DrugClasses.Find(id);

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("DrugClassTemplate", item);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult SaveDrugClass(DrugClass drugClass)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (drugClass.DrugClassId == 0)

                        db.DrugClasses.Add(drugClass);
                    else
                    {
                        db.DrugClasses.Attach(drugClass);
                        db.Entry(drugClass).State = EntityState.Modified;
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
        public ActionResult DeleteDrugClass([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new DrugClass()
                        {
                            DrugClassId = Convert.ToInt32(id),
                        };
                        db.DrugClasses.Attach(item);
                        db.DrugClasses.Remove(item);
                        db.SaveChanges();
                    }
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult CreateDrug(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    DrugClass drugClass = db.DrugClasses.Find(id);

                    DrugViewBugs(db, drugClass.StoreOrganizationId);

                    var item = new DrugTemplate();
                    item.DrugClassId = id;
                    item.StoreOrganizationId = drugClass.StoreOrganizationId;
                    item.Quantity = 0;

                    if (item == null)
                    {
                        throw new HttpException(404, "Not found");
                    }
                    else
                    {
                        return View("DrugTemplate", item);
                    }

                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "DrugClass", "DrugTemplate"));
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult UpdateDrug(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    var item = new DrugTemplate();

                    if (id != 0)
                    {
                        Drug drug = db.Drugs.Find(id);

                        item.DrugClassId = drug.DrugClassId;
                        item.Quantity = drug.Quantity;
                        item.DrugId = drug.DrugId;
                        item.Seria = drug.Seria;
                        item.ExpirationDate = drug.ExpirationDate;
                        item.UnitTypeId = drug.UnitTypeId;
                        item.UnitCost = drug.UnitCost;
                        item.OrganizationId = drug.OrganizationId;
                        item.StoreOrganizationId = drug.StoreOrganizationId;
                        item.DrugSourceId = drug.DrugSourceId;
                        item.SupplierId = drug.SupplierId;
                        item.CountryId = drug.CountryId;
                        item.Manufacturer = drug.Manufacturer;
                        item.Description = drug.Description;

                        DrugViewBugs(db, drug.StoreOrganizationId);

                    }



                    if (item == null)
                    {
                        throw new HttpException(404, "Not found");
                    }
                    else
                    {
                        return View("DrugTemplate", item);
                    }

                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "DrugClass", "DrugTemplate"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "storagerole")]
        public ActionResult SaveDrug(DrugTemplate drugTemplate)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new StoreContext())
                {
                    //check if the is already exists
                    int? cnt = db.Drugs.Where(p => p.DrugId == drugTemplate.DrugId).Count();

                    if (cnt == 0)
                    {
                        DrugClass drugClass = db.DrugClasses.Find(drugTemplate.DrugClassId); //get the DrugClass in orfer to build a Drug Name

                        var drug = new Drug();

                        drug.DrugName = drugClass.DrugClassName + " " + drug.Seria + " " + Convert.ToDateTime(drug.ExpirationDate).ToShortDateString();
                        drug.DrugClassId = drugTemplate.DrugClassId;
                        drug.Quantity = drugTemplate.Quantity;
                        drug.DrugId = drugTemplate.DrugId;
                        drug.Seria = drugTemplate.Seria;
                        drug.ExpirationDate = drugTemplate.ExpirationDate;
                        drug.UnitTypeId = drugTemplate.UnitTypeId;
                        drug.UnitCost = drugTemplate.UnitCost;
                        drug.OrganizationId = drugTemplate.OrganizationId;
                        drug.StoreOrganizationId = drugTemplate.StoreOrganizationId;
                        drug.DrugSourceId = drugTemplate.DrugSourceId;
                        drug.SupplierId = drugTemplate.SupplierId;
                        drug.CountryId = drugTemplate.CountryId;
                        drug.Manufacturer = drugTemplate.Manufacturer;
                        drug.Description = drugTemplate.Description;

                        if (drugTemplate.Products != null)
                        {
                            foreach (var item in drugTemplate.Products)
                            {
                                if (item.RecordStatus == 1)
                                {
                                    var product = new Product();

                                    var productCalculationHelper = new DrugCalculationHelper(drug.DrugClassId, item.Quantity, drug.UnitCost);

                                    product.RegistrationDate = item.RegistrationDate;
                                    product.Drug = drug;
                                    product.StorageId = item.StorageId;
                                    product.Quantity = item.Quantity;
                                    product.ItemQuantity = productCalculationHelper.ItemQuantity;
                                    product.TotalCost = productCalculationHelper.TotalCost;
                                    product.UnitCost = productCalculationHelper.UnitCost;

                                    drug.Quantity = drug.Quantity + item.Quantity; //increment drug quantity by product quantity

                                    db.Products.Add(product);
                                }
                            }
                        }

                        var drugCalculationHelper = new DrugCalculationHelper(drug.DrugClassId, drug.Quantity, drug.UnitCost);
                        drug.ItemQuantity = drugCalculationHelper.ItemQuantity;
                        drug.TotalCost = drugCalculationHelper.TotalCost;

                        db.Drugs.Add(drug);
                    }
                    else
                    {
                        DrugClass drugClass = db.DrugClasses.Find(drugTemplate.DrugClassId);

                        Drug drug = db.Drugs.Find(drugTemplate.DrugId);

                        drug.DrugName = drugClass.DrugClassName + " " + drug.Seria + " " + Convert.ToDateTime(drug.ExpirationDate).ToShortDateString();
                        drug.DrugClassId = drugTemplate.DrugClassId;
                        drug.Quantity = drugTemplate.Quantity;
                        drug.DrugId = drugTemplate.DrugId;
                        drug.Seria = drugTemplate.Seria;
                        drug.ExpirationDate = drugTemplate.ExpirationDate;
                        drug.UnitTypeId = drugTemplate.UnitTypeId;
                        drug.UnitCost = drugTemplate.UnitCost;
                        drug.OrganizationId = drugTemplate.OrganizationId;
                        drug.StoreOrganizationId = drugTemplate.StoreOrganizationId;
                        drug.DrugSourceId = drugTemplate.DrugSourceId;
                        drug.SupplierId = drugTemplate.SupplierId;
                        drug.CountryId = drugTemplate.CountryId;
                        drug.Manufacturer = drugTemplate.Manufacturer;
                        drug.Description = drugTemplate.Description;

                        if (drugTemplate.Products != null)
                        {
                            foreach (var item in drugTemplate.Products)
                            {

                                if (item.RecordStatus == 1)
                                {
                                    var product = new Product();
                                    var productCalculationHelper = new DrugCalculationHelper(drug.DrugClassId, item.Quantity, drug.UnitCost);
                                    product.RegistrationDate = item.RegistrationDate;
                                    product.Drug = drug;
                                    product.StorageId = item.StorageId;
                                    product.Quantity = item.Quantity;
                                    product.ItemQuantity = productCalculationHelper.ItemQuantity;
                                    product.TotalCost = productCalculationHelper.TotalCost;
                                    product.UnitCost = productCalculationHelper.UnitCost;
                                    drug.Quantity = drug.Quantity + item.Quantity; //increment drug quantity by product quantity
                                    db.Products.Add(product);
                                }
                                else if (item.RecordStatus == 2)
                                {
                                    Product product = db.Products.Find(item.ProductId);
                                    var productCalculationHelper = new DrugCalculationHelper(drug.DrugClassId, item.Quantity, drug.UnitCost);
                                    product.RegistrationDate = item.RegistrationDate;
                                    product.Drug = drug;
                                    product.StorageId = item.StorageId;
                                    product.ItemQuantity = productCalculationHelper.ItemQuantity;
                                    product.TotalCost = productCalculationHelper.TotalCost;
                                    product.UnitCost = productCalculationHelper.UnitCost;
                                    drug.Quantity = drug.Quantity + item.Quantity - product.Quantity; //increment drug quantity by product quantity decrement by existing one
                                    product.Quantity = item.Quantity;
                                    db.Products.Attach(product);
                                    db.Entry(product).State = EntityState.Modified;
                                }
                                else if (item.RecordStatus == 3)
                                {
                                    Product product = db.Products.Find(item.ProductId);
                                    drug.Quantity = drug.Quantity - product.Quantity;
                                    db.Products.Remove(product);
                                }
                            }
                        }
                        var drugCalculationHelper = new DrugCalculationHelper(drug.DrugClassId, drug.Quantity, drug.UnitCost);
                        drug.ItemQuantity = drugCalculationHelper.ItemQuantity;
                        drug.TotalCost = drugCalculationHelper.TotalCost;
                        db.Drugs.Attach(drug);
                        db.Entry(drug).State = EntityState.Modified;
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
        public ActionResult DeleteDrug([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Drug()
                        {
                            DrugId = Convert.ToInt32(id),
                        };
                        db.Drugs.Attach(item);
                        db.Drugs.Remove(item);
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
        public ActionResult UploadFile(int? id)
        {
            using (var db = new StoreContext())
            {
                ViewBag.imageName = Guid.NewGuid().ToString();
                DrugDetail item = db.DrugDetails.Find(id);
                return View("UploadFile", item);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult SaveFile(IEnumerable<HttpPostedFileBase> files, int DID, string drugFileName)
        {
            try
            {
                var db = new StoreContext();
                Drug drug = db.Drugs.Find(DID);
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        db.DrugPictures.RemoveRange(db.DrugPictures.Where(x => x.DrugId == DID));

                        var drugPicture = new DrugPicture
                        {
                            FileName = System.IO.Path.GetFileName(drugFileName),
                            FileType = FileType.Avatar,
                            ContentType = file.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(file.InputStream))
                        {
                            drugPicture.Content = reader.ReadBytes(file.ContentLength);
                        }
                        drugPicture.DrugId = DID;
                        drugPicture.Drug = drug;
                        db.DrugPictures.Add(drugPicture);

                    }
                    db.SaveChanges();

                }
                return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult CancelUpload(string name)
        {
            try
            {
                var db = new StoreContext();
                //Drug drug = db.Drugs.Find(id);
                db.DrugPictures.RemoveRange(db.DrugPictures.Where(x => x.FileName == name));
                db.SaveChanges();

                return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}