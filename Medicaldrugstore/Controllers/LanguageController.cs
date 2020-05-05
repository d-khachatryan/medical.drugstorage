using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Medicaldrugstore.Controllers
{
    public class LanguageController : BaseController
    {
        public ActionResult SetLanguage(string name)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(name);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            HttpContext.Session["culture"] = name;

            var cookie = new HttpCookie("_culture", name);
            cookie.Expires = DateTime.Today.AddYears(1);
            Response.SetCookie(cookie);

            return RedirectToAction("Index", "Home");
        }
    }
}