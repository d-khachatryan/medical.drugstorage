using Medicaldrugstore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicaldrugstore.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index01()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;
            }
            return View();
        }

        public ActionResult Report01(string startDate, string terminationDate, string organizationId)
        {
            ViewBag.StartDate = startDate;
            ViewBag.TerminationDate = terminationDate;
            ViewBag.OrganizationId = organizationId;
            using (var db = new StoreContext())
            {
                int id = Convert.ToInt32(organizationId);
                ViewBag.OrganizationName = db.Organizations.Where(p => p.OrganizationId == id).First().OrganizationName;
            }                
            return View();
        }

        public ActionResult Index02()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;
            }
            return View();
        }

        public ActionResult Report02(string startDate, string terminationDate, string organizationId)
        {
            ViewBag.StartDate = startDate;
            ViewBag.TerminationDate = terminationDate;
            ViewBag.OrganizationId = organizationId;
            using (var db = new StoreContext())
            {
                int id = Convert.ToInt32(organizationId);
                ViewBag.OrganizationName = db.Organizations.Where(p => p.OrganizationId == id).First().OrganizationName;
            }

            return View();
        }

        public ActionResult Index03()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;

                //diagnose
            }
            return View();
        }

        public ActionResult Report03(string startDate, string terminationDate, string organizationId, string diagnoseId)
        {
            ViewBag.StartDate = startDate;
            ViewBag.TerminationDate = terminationDate;
            ViewBag.OrganizationId = organizationId;
            ViewBag.DiagnoseId = diagnoseId;
            using (var db = new StoreContext())
            {
                int id = Convert.ToInt32(organizationId);
                ViewBag.OrganizationName = db.Organizations.Where(p => p.OrganizationId == id).First().OrganizationName;
                ViewBag.DiagnoseName = "-----";
            }

            return View();
        }

        public ActionResult Index04()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;
            }
            return View();
        }

        public ActionResult Report04(string startDate, string terminationDate, string mId)
        {
            ViewBag.StartDate = startDate;
            ViewBag.TerminationDate = terminationDate;
            ViewBag.MarzId = 0; // mId;
            using (var db = new StoreContext())
            {
                int id = Convert.ToInt32(mId);
                ViewBag.MarzName = "----";//  db.Organizations.Where(p => p.OrganizationId == id).First().OrganizationName;
            }
            return View();
        }

        public ActionResult Index05()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;
            }
            return View();
        }        

        public ActionResult Report05(string reportDate, string organizationId)
        {
            ViewBag.ReportDate = reportDate;
            ViewBag.OrganizationId = organizationId;
            using (var db = new StoreContext())
            {
                int id = Convert.ToInt32(organizationId);
                ViewBag.OrganizationName = db.Organizations.Where(p => p.OrganizationId == id).First().OrganizationName;
            }
            return View();
        }

        public ActionResult Index06()
        {
            return View();
        }

        public ActionResult Report06(string startDate, string terminationDate)
        {
            ViewBag.StartDate = startDate;
            ViewBag.TerminationDate = terminationDate;            
            return View();
        }

        public ActionResult Index07()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;
            }
            return View();
        }

        public ActionResult Report07(string startDate, string terminationDate, string mId)
        {
            ViewBag.StartDate = startDate;
            ViewBag.TerminationDate = terminationDate;
            ViewBag.MarzId = 0; // mId;
            using (var db = new StoreContext())
            {
                int id = Convert.ToInt32(mId);
                ViewBag.MarzName = "----";//  db.Organizations.Where(p => p.OrganizationId == id).First().OrganizationName;
            }
            return View();
        }

        public ActionResult Index08()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;
            }
            return View();
        }

        public ActionResult Report08(string startDate, string terminationDate, string organizationId)
        {
            ViewBag.StartDate = startDate;
            ViewBag.TerminationDate = terminationDate;
            ViewBag.OrganizationId = organizationId;
            using (var db = new StoreContext())
            {
                int id = Convert.ToInt32(organizationId);
                ViewBag.OrganizationName = db.Organizations.Where(p => p.OrganizationId == id).First().OrganizationName;
            }

            return View();
        }
    }
}