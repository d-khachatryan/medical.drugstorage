using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Medicaldrugstore.DAL;
using Medicaldrugstore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity;
using Kendo.Mvc;

namespace Medicaldrugstore.Controllers
{
    public class MessageBoxesController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            return View();
        }

        public ActionResult SentMessages()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            return View();
        }

        public ActionResult ReadMessageBoxes([DataSourceRequest]DataSourceRequest request, string userId)
        {
            using (var db = new StoreContext())
            {
                var recipientUserId = User.Identity.GetUserId();
                IQueryable<MessageBox> messages;
                if (String.IsNullOrEmpty(userId))
                {
                    messages = db.MessageBoxes.Where(p => p.RecipientUserId == recipientUserId).OrderByDescending(p => p.MessageId);
                }
                else
                {
                    var senderUserId = userId;
                    messages = db.MessageBoxes.Where(p => p.RecipientUserId == recipientUserId && p.SenderUserId == senderUserId).OrderByDescending(p => p.MessageId);
                }

                DataSourceResult result = messages.ToDataSourceResult(request);
                return Json(result);
            }

        }

        public ActionResult SentMessageBoxes([DataSourceRequest]DataSourceRequest request, string userId)
        {
            using (var db = new StoreContext())
            {
                var sUserId = User.Identity.GetUserId();
                IQueryable<MessageBox> messages;
                if (String.IsNullOrEmpty(userId))
                {
                    messages = db.MessageBoxes.Where(p => p.SenderUserId == sUserId).OrderByDescending(p => p.MessageId);
                }
                else
                {
                    var rId = userId;
                    messages = db.MessageBoxes.Where(p => p.SenderUserId == sUserId && p.RecipientUserId == rId).OrderByDescending(p => p.MessageId);
                }
                DataSourceResult result = messages.ToDataSourceResult(request);
                return Json(result);
            }
        }


        public ActionResult OpenMessageBoxes()
        {
            using (var db = new StoreContext())
            {
                FillViewBugs(db);
            }
            var item = new MessageBox();
            return View("MainTemplate", item);
        }


        public ActionResult CreateMessageBox([DataSourceRequest]DataSourceRequest request, MessageBox message)
        {
            //products.UserName = User.Identity.Name;
            //products.UserId  = new Guid(User.Identity.GetUserId());
            try
            {
                if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    string recipientUserName = (db.Users.Where(p => p.UserId == message.RecipientUserId)).First().UserName;

                    var entity = new MessageBox
                    {
                        SenderUserId = User.Identity.GetUserId(),
                        SenderUserName = User.Identity.Name,
                        RecipientUserId = message.RecipientUserId,
                        RecipientUserName = recipientUserName,
                        MessageDate = DateTime.Now,
                        MessageContent = message.MessageContent,
                        MessageStatus = 1,
                        MessageTitle = message.MessageTitle,
                    };
                    db.MessageBoxes.Add(entity);
                    db.SaveChanges();
                    message.MessageId = entity.MessageId;
                    message.SenderUserId = entity.SenderUserId;
                    message.SenderUserName = entity.SenderUserName;
                    message.RecipientUserId = entity.RecipientUserId;
                    message.MessageDate = entity.MessageDate;
                    message.RecipientUserName = entity.RecipientUserName;
                    message.MessageStatus = entity.MessageStatus;
                }
            }
                //return Json(new[] { message }.ToDataSourceResult(request, ModelState));
                return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SelectMessageBox(int? mId)
        {
            using (var db = new StoreContext())
            {
                MessageBox message = db.MessageBoxes.Find(Convert.ToInt32(mId));
                message.MessageStatus = 2; //Կարգավիճակ: --Համաձայնեցված--

                db.MessageBoxes.Attach(message);
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                if (message == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return Json("Response from Contains", JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult SelectSentMessageBox(int? mId)
        {
            using (var db = new StoreContext())
            {
                MessageBox message = db.MessageBoxes.Find(Convert.ToInt32(mId));
                //message.MessageStatus = 2; //Կարգավիճակ: --Համաձայնեցված--

                db.MessageBoxes.Attach(message);
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                if (message == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return Json("Response from Contains", JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult DestroyMessageBox([DataSourceRequest]DataSourceRequest request, MessageBox message)
        {
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    var entity = new MessageBox
                    {
                        MessageId = message.MessageId,
                    };
                    db.MessageBoxes.Attach(entity);
                    db.MessageBoxes.Remove(entity);
                    db.SaveChanges();
                }
            }
            return Json(new[] { message }.ToDataSourceResult(request, ModelState));
        }

        private void FillViewBugs(StoreContext db)
        {
            var lUsers = new List<SelectListItem>();
            lUsers = db.Users.Select(x => new SelectListItem { Text = x.UserName, Value = x.UserId.ToString() }).ToList();
            ViewBag.vbUsers = lUsers;
        }
    }


}