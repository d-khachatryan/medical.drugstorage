using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Medicaldrugstore.Controllers
{
    public class OrganizationsController : Controller
    {

        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "administrator")]
        public ActionResult ReadOrganizations([DataSourceRequest]DataSourceRequest request, string organizationCode, string organizationName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<OrganizationDetail> items = db.OrganizationDetails;
                if (!string.IsNullOrEmpty(organizationName))
                {
                    items = items.Where(p => p.OrganizationName.StartsWith(organizationName));
                }
                if (!string.IsNullOrEmpty(organizationCode))
                {
                    items = items.Where(p => p.OrganizationCode.StartsWith(organizationCode));
                }
                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        

        [Authorize(Roles = "administrator")]
        public ActionResult OrganizationDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new StoreContext())
            {
                var details = new OrganizationDetail();
                details = db.OrganizationDetails.Find(id);
                if (details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("OrganizationDetail", details);
                }
            }
        }

        public JsonResult GetRegions()
        {
            using (var db = new StoreContext())
            {
                IQueryable<Organization> organizations = db.Organizations.Where(p => p.IsRegion == true).AsQueryable();
                return Json(organizations.ToList().Select(c => new { OrganizationId = c.OrganizationId, OrganizationName = c.OrganizationName }), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetGoverments()
        {
            using (var db = new StoreContext())
            {
                IQueryable<Organization> organizations = db.Organizations.Where(p => p.IsGoverment == true).AsQueryable();
                return Json(organizations.ToList().Select(c => new { OrganizationId = c.OrganizationId, OrganizationName = c.OrganizationName }), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetBanks()
        {
            using (var db = new StoreContext())
            {
                IQueryable<Bank> banks = db.Banks.AsQueryable();
                return Json(banks.ToList().Select(c => new { BankId = c.BankId, BankName = c.BankName }), JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "administrator")]
        public ActionResult OrganizationTemplate(int? organizationId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (organizationId == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    var item = new OrganizationTemplate();

                    if (organizationId != 0)
                    {
                        Organization organization = db.Organizations.Find(organizationId);
                        item.OrganizationId = organization.OrganizationId;
                        item.RegionId = organization.RegionId;
                        item.GovermentId = organization.GovermentId;
                        item.OrganizationCode = organization.OrganizationCode;
                        item.OrganizationName = organization.OrganizationName;
                        item.OrganizationLocation = organization.OrganizationLocation;
                        item.DeliveryLocation = organization.DeliveryLocation;
                        item.RegistrationNumber = organization.RegistrationNumber;
                        item.BankId = organization.BankId;
                        item.BankAccountNumber = organization.BankAccountNumber;
                        item.TinNumber = organization.TinNumber;
                        item.HeadName = organization.HeadName;
                        item.AccountantName = organization.AccountantName;
                        item.ResponsibleName = organization.ResponsibleName;
                        item.IsOrganization = organization.IsOrganization;
                        item.IsStorage = organization.IsStorage;
                        item.IsRegion = organization.IsRegion;
                        item.IsGoverment = organization.IsGoverment;
                    }

                    if (item == null)
                    {
                        throw new HttpException(404, "Not found");
                    }
                    else
                    {
                        return View("OrganizationTemplate", item);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Organization", "OrganizationTemplate"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "administrator")]
        public ActionResult SaveOrganization(OrganizationTemplate organizationTemplate)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new StoreContext())
                {
                    if (organizationTemplate.OrganizationId == 0)
                    {
                        var item = new Organization();
                        item.OrganizationId = organizationTemplate.OrganizationId;
                        item.RegionId = organizationTemplate.RegionId;
                        item.GovermentId = organizationTemplate.GovermentId;
                        item.OrganizationCode = organizationTemplate.OrganizationCode;
                        item.OrganizationName = organizationTemplate.OrganizationName;
                        item.OrganizationLocation = organizationTemplate.OrganizationLocation;
                        item.DeliveryLocation = organizationTemplate.DeliveryLocation;
                        item.RegistrationNumber = organizationTemplate.RegistrationNumber;
                        item.BankId = organizationTemplate.BankId;
                        item.BankAccountNumber = organizationTemplate.BankAccountNumber;
                        item.TinNumber = organizationTemplate.TinNumber;
                        item.HeadName = organizationTemplate.HeadName;
                        item.AccountantName = organizationTemplate.AccountantName;
                        item.ResponsibleName = organizationTemplate.ResponsibleName;
                        item.IsOrganization = organizationTemplate.IsOrganization;
                        item.IsStorage = organizationTemplate.IsStorage;
                        item.IsRegion = organizationTemplate.IsRegion;
                        item.IsGoverment = organizationTemplate.IsGoverment;
                        db.Organizations.Add(item);
                    }
                    else
                    {
                        Organization item = db.Organizations.Find(organizationTemplate.OrganizationId);
                        item.OrganizationId = organizationTemplate.OrganizationId;
                        item.RegionId = organizationTemplate.RegionId;
                        item.GovermentId = organizationTemplate.GovermentId;
                        item.OrganizationCode = organizationTemplate.OrganizationCode;
                        item.OrganizationName = organizationTemplate.OrganizationName;
                        item.OrganizationLocation = organizationTemplate.OrganizationLocation;
                        item.DeliveryLocation = organizationTemplate.DeliveryLocation;
                        item.RegistrationNumber = organizationTemplate.RegistrationNumber;
                        item.BankId = organizationTemplate.BankId;
                        item.BankAccountNumber = organizationTemplate.BankAccountNumber;
                        item.TinNumber = organizationTemplate.TinNumber;
                        item.HeadName = organizationTemplate.HeadName;
                        item.AccountantName = organizationTemplate.AccountantName;
                        item.ResponsibleName = organizationTemplate.ResponsibleName;
                        item.IsOrganization = organizationTemplate.IsOrganization;
                        item.IsStorage = organizationTemplate.IsStorage;
                        item.IsRegion = organizationTemplate.IsRegion;
                        item.IsGoverment = organizationTemplate.IsGoverment;
                        db.Organizations.Attach(item);
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

        [Authorize(Roles = "administrator")]
        public ActionResult DeleteOrganization(int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Organization()
                        {
                            OrganizationId = Convert.ToInt32(id),
                        };
                        db.Organizations.Attach(item);
                        db.Organizations.Remove(item);
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

        [Authorize(Roles = "administrator")]
        public ActionResult ReadStorages([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<StorageDetail> items = db.StorageDetails.Where(p => p.OrganizationId == id);
                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "administrator")]
        public ActionResult StorageTemplate(int? storageId, int organizationId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (storageId == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    var item = new StorageTemplate();

                    if (storageId != 0)
                    {
                        Storage storage = db.Storages .Find(storageId);
                        item.StorageId = storage.StorageId;
                        item.StorageCode = storage.StorageCode;
                        item.StorageName = storage.StorageName;
                        item.OrganizationId = storage.OrganizationId;                        
                    }
                    else
                    {
                        item.OrganizationId = organizationId;
                    }

                    if (item == null)
                    {
                        throw new HttpException(404, "Not found");
                    }
                    else
                    {
                        return View("StorageTemplate", item);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Organization", "StorageTemplate"));
            }
        }

        [HttpPost]
        [Authorize(Roles = "administrator")]
        public ActionResult SaveStorage(StorageTemplate storageTemplate)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, responseText = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new StoreContext())
                {
                    if (storageTemplate.StorageId == 0)
                    {
                        var item = new Storage();
                        item.StorageId = storageTemplate.StorageId;
                        item.StorageCode = storageTemplate.StorageCode;
                        item.StorageName = storageTemplate.StorageName;
                        item.OrganizationId = storageTemplate.OrganizationId;
                        db.Storages.Add(item);
                    }
                    else
                    {
                        Storage item = db.Storages.Find(storageTemplate.StorageId);
                        item.StorageId = storageTemplate.StorageId;
                        item.StorageCode = storageTemplate.StorageCode;
                        item.StorageName = storageTemplate.StorageName;
                        item.OrganizationId = storageTemplate.OrganizationId;
                        db.Storages.Attach(item);
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

        [Authorize(Roles = "administrator")]
        public ActionResult DeleteStorage(int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Storage()
                        {
                            StorageId = Convert.ToInt32(id),
                        };
                        db.Storages.Attach(item);
                        db.Storages.Remove(item);
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

    }
}
