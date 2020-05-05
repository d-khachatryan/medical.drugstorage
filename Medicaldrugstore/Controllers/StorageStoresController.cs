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

namespace Medicaldrugstore.Controllers
{
    public class StorageStoresController : Controller
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
        public ActionResult ReadStorageStores([DataSourceRequest]DataSourceRequest request, string organizationId, string startDate, string terminationDate)
        {
            using (var db = new StoreContext())
            {
                var prmOrganizationId = new SqlParameter("@OrganizationId", SqlDbType.Int);
                var prmStartDate = new SqlParameter("@StartDate", SqlDbType.Date);
                var prmTerminationDate = new SqlParameter("@TerminationDate", SqlDbType.Date);

                if (organizationId != "")
                {
                    prmOrganizationId.Value = Convert.ToInt32(organizationId);
                }
                else
                {
                    prmOrganizationId.Value = DBNull.Value;
                }

                prmStartDate.Value = Convert.ToDateTime(startDate);
                prmTerminationDate.Value = Convert.ToDateTime(terminationDate);

                List<StorageStore> products = db.Database.SqlQuery<StorageStore>("spStorageStore @OrganizationId, @StartDate, @TerminationDate", prmOrganizationId, prmStartDate, prmTerminationDate).ToList();
                DataSourceResult result = products.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadStorageSubStores([DataSourceRequest]DataSourceRequest request, string organizationId, string startDate, string terminationDate, string productId)
        {
            using (var db = new StoreContext())
            {
                var prmOrganizationId = new SqlParameter("@OrganizationId", SqlDbType.Int);
                var prmStartDate = new SqlParameter("@StartDate", SqlDbType.Date);
                var prmTerminationDate = new SqlParameter("@TerminationDate", SqlDbType.Date);
                var prmProductId = new SqlParameter("@ProductId", SqlDbType.Int);

                prmOrganizationId.Value = Convert.ToInt32(organizationId);
                prmProductId.Value = Convert.ToInt32(productId);
                prmStartDate.Value = DateTime.ParseExact(startDate.Substring(0, 15), "ddd MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);
                prmTerminationDate.Value = DateTime.ParseExact(terminationDate.Substring(0, 15), "ddd MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);


                List<StorageSubStore> products = db.Database.SqlQuery<StorageSubStore>("spStorageSubStore @OrganizationId, @StartDate, @TerminationDate, @ProductId", prmOrganizationId, prmStartDate, prmTerminationDate, prmProductId).ToList();
                DataSourceResult result = products.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadStorageStoreIns([DataSourceRequest]DataSourceRequest request, string organizationId, string startDate, string terminationDate, string productId)
        {
            using (var db = new StoreContext())
            {
                var prmOrganizationId = new SqlParameter("@OrganizationId", SqlDbType.Int);
                var prmStartDate = new SqlParameter("@StartDate", SqlDbType.Date);
                var prmTerminationDate = new SqlParameter("@TerminationDate", SqlDbType.Date);
                var prmProductId = new SqlParameter("@ProductId", SqlDbType.Int);

                prmOrganizationId.Value = Convert.ToInt32(organizationId);
                prmProductId.Value = Convert.ToInt32(productId);
                prmStartDate.Value = DateTime.ParseExact(startDate.Substring(0, 15), "ddd MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);
                prmTerminationDate.Value = DateTime.ParseExact(terminationDate.Substring(0, 15), "ddd MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);


                List<StorageStoreIns> products = db.Database.SqlQuery<StorageStoreIns>("spStorageStoreIns @OrganizationId, @StartDate, @TerminationDate, @ProductId", prmOrganizationId, prmStartDate, prmTerminationDate, prmProductId).ToList();
                DataSourceResult result = products.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "storagerole")]
        public ActionResult ReadStorageStoreOuts([DataSourceRequest]DataSourceRequest request, string organizationId, string startDate, string terminationDate, string productId)
        {
            using (var db = new StoreContext())
            {
                var prmOrganizationId = new SqlParameter("@OrganizationId", SqlDbType.Int);
                var prmStartDate = new SqlParameter("@StartDate", SqlDbType.Date);
                var prmTerminationDate = new SqlParameter("@TerminationDate", SqlDbType.Date);
                var prmProductId = new SqlParameter("@ProductId", SqlDbType.Int);

                prmOrganizationId.Value = Convert.ToInt32(organizationId);
                prmProductId.Value = Convert.ToInt32(productId);
                prmStartDate.Value = DateTime.ParseExact(startDate.Substring(0, 15), "ddd MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);
                prmTerminationDate.Value = DateTime.ParseExact(terminationDate.Substring(0, 15), "ddd MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);


                List<StorageStoreOuts> products = db.Database.SqlQuery<StorageStoreOuts>("spStorageStoreOuts @OrganizationId, @StartDate, @TerminationDate, @ProductId", prmOrganizationId, prmStartDate, prmTerminationDate, prmProductId).ToList();
                DataSourceResult result = products.ToDataSourceResult(request);
                return Json(result);
            }
        }

        private void FillViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

            //var lProducts = new List<SelectListItem>();
            //lProducts = db.ProductDetails.Select(x => new SelectListItem { Text = x.DrugName, Value = x.ProductId.ToString() }).ToList();
            //ViewBag.vbProducts = lProducts;
        }

    }
}
