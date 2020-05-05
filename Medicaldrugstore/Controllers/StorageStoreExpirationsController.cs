using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Data.SqlClient;
using System.Net;

namespace Medicaldrugstore.Controllers
{
    public class StorageStoreExpirationsController : Controller
    {

        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            return View();
        }

        public ActionResult ReadStorageStoreExpirations([DataSourceRequest]DataSourceRequest request, string organizationId, string calculationDate, string expirationDays)
        {
            using (var db = new StoreContext())
            {
                var prmOrganizationId = new SqlParameter("@OrganizationId", SqlDbType.Int);
                var prmCalculationDate = new SqlParameter("@CalculationDate", SqlDbType.Date);
                var prmExpirationDays = new SqlParameter("@ExpirationDays", SqlDbType.Int);

                //prmOrganizationId.Value = 1;
                //prmCalculationDate.Value = Convert.ToDateTime("09/30/2016");
                //prmExpirationDays.Value = 80;

                if (organizationId != "")
                {
                    prmOrganizationId.Value = Convert.ToInt32(organizationId);
                }
                else
                {
                    prmOrganizationId.Value = DBNull.Value;
                }

                if (calculationDate != "")
                {
                    prmCalculationDate.Value = Convert.ToDateTime(calculationDate);
                }
                else
                {
                    prmCalculationDate.Value = DBNull.Value;
                }

                if (expirationDays != "")
                {
                    prmExpirationDays.Value = Convert.ToInt32(expirationDays);
                }
                else
                {
                    prmExpirationDays.Value = DBNull.Value;
                }

                List <StorageStoreExpirations> products = db.Database.SqlQuery<StorageStoreExpirations>("spStorageStoreExpirations @OrganizationId, @CalculationDate, @ExpirationDays", prmOrganizationId, prmCalculationDate, prmExpirationDays).ToList();
                DataSourceResult result = products.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //public ActionResult StorageStoreExpirationDetails([DataSourceRequest]DataSourceRequest request, int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    using (var db = new StoreContext())
        //    {
        //        var details = new StorageStoreExpirations();
        //        details = ;
        //        if (details == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        else
        //        {
        //            return View("StorageStoreExpirationDetails", details);
        //        }
        //    }
        //}

        private void FillViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

        }

    }
}
