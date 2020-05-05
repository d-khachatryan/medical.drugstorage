using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Medicaldrugstore.Controllers
{
    public class BanksController : Controller
    {
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                return View("~/Views/Catalogs/Banks/Index.cshtml", db.Banks.ToList());
            }
        }

        [Authorize(Roles = "administrator")]
        public ActionResult ReadBanks([DataSourceRequest]DataSourceRequest request, string bankCode, string bankName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<Bank> banks = db.Banks;
                if (!string.IsNullOrEmpty(bankName))
                {
                    banks = banks.Where(p => p.BankName.StartsWith(bankName));
                }
                if (!string.IsNullOrEmpty(bankCode))
                {
                    banks = banks.Where(p => p.BankCode.StartsWith(bankCode));
                }
                DataSourceResult result = banks.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "administrator")]
        public ActionResult BankDetails(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bank bank = db.Banks.Find(id);
                if (bank == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/Banks/BankDetails.cshtml", bank);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenCreateBankView()
        {
            var item = new Bank();
            return View("~/Views/Catalogs/Banks/BankTemplate.cshtml", item);
        }
        [Authorize(Roles = "administrator")]
        public ActionResult SaveBank(Bank bank)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    if (bank.BankId == 0)
                    {
                        var entity = new Bank
                        {
                            BankId = bank.BankId,
                            BankCode = bank.BankCode,
                            BankName = bank.BankName

                        };
                        db.Banks.Add(entity);
                    }
                    else
                    {
                        Bank item = db.Banks.Find(bank.BankId);
                        item.BankId = bank.BankId;
                        item.BankCode = bank.BankCode;
                        item.BankName = bank.BankName;
                        db.Banks.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult OpenUpdateBankView(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Bank item = db.Banks.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("~/Views/Catalogs/Banks/BankTemplate.cshtml", item);
                }
            }
        }
        [Authorize(Roles = "administrator")]
        public ActionResult DeleteBank(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Bank item = db.Banks.Find(id);
                    db.Banks.Attach(item);
                    db.Banks.Remove(item);
                    db.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
