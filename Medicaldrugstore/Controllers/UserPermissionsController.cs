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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Medicaldrugstore.Controllers
{
    public class UserPermissionsController : Controller
    {

        public ActionResult Index()
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

            var udb = new ApplicationDbContext();
            var lUsers = new List<SelectListItem>();
            lUsers = udb.Users.OrderBy(x => x.UserName).Select(x => new SelectListItem { Text = x.UserName, Value = x.Id }).ToList();
            ViewBag.vbUsers = lUsers;

        }

        public ActionResult ReadUserPermissions([DataSourceRequest]DataSourceRequest request, string userName)
        {
            using (var db = new StoreContext())
            {

                IQueryable<UserPermission> userPermissions = db.UserPermissions;

                if (userName != "")
                {

                    userPermissions = userPermissions.Where(p => p.UserName.StartsWith(userName));
                }

                DataSourceResult result = userPermissions.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult UserPermissionTemplate(int? userPermissionId)
        {
            using (var db = new StoreContext())
            {
                if (userPermissionId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                FillViewBugs(db);

                UserPermission item;

                if (userPermissionId == 0)
                {
                    item = new UserPermission();
                }
                else
                {
                    item = db.UserPermissions.Find(userPermissionId);
                }

                if (item == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("UserPermissionTemplate", item);
                }
            }
        }

        [HttpPost]
        public ActionResult SaveUserPermission(UserPermission userPermission)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.UserPermissions.Where(p => p.UserPermissionId == userPermission.UserPermissionId).Count();
                    
                    if (cnt == 0)
                    {
                        db.UserPermissions.Add(userPermission);
                    }
                    else
                    {
                        db.UserPermissions.Attach(userPermission);
                        db.Entry(userPermission).State = EntityState.Modified;
                    }

                    db.SaveChanges();


                    var context = new ApplicationDbContext();
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    ApplicationUser user = userManager.FindByName(userPermission.UserName);

                    if (userPermission.IsOrganizationUser == null || userPermission.IsOrganizationUser == false)
                    {
                        userManager.RemoveFromRole(user.Id, "lmis_organization");
                    }
                    else
                    {
                        userManager.AddToRole(user.Id, "lmis_organization");
                    }

                    if (userPermission.IsStorageUser == null || userPermission.IsStorageUser == false)
                    {
                        userManager.RemoveFromRole(user.Id, "lmis_storage");
                    }
                    else
                    {
                        userManager.AddToRole(user.Id, "lmis_storage");
                    }

                    if (userPermission.IsRegionUser == null || userPermission.IsRegionUser == false)
                    {
                        userManager.RemoveFromRole(user.Id, "lmis_region");
                    }
                    else
                    {
                        userManager.AddToRole(user.Id, "lmis_region");
                    }

                    if (userPermission.IsGovermentUser == null || userPermission.IsGovermentUser == false)
                    {
                        userManager.RemoveFromRole(user.Id, "lmis_goverment");
                    }
                    else
                    {
                        userManager.AddToRole(user.Id, "lmis_goverment");
                    }

                    if (userPermission.IsAdministrator == null || userPermission.IsAdministrator == false)
                    {
                        userManager.RemoveFromRole(user.Id, "lmis_administrator");
                    }
                    else
                    {
                        userManager.AddToRole(user.Id, "lmis_administrator");
                    }
                    context.SaveChanges();

                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteUserPermission([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new UserPermission()
                        {
                            UserPermissionId = Convert.ToInt32(id),
                        };
                        db.UserPermissions.Attach(item);
                        db.UserPermissions.Remove(item);
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

        //private StoreContext db = new StoreContext();

        //private readonly ApplicationDbContext context = new ApplicationDbContext();

        //// GET: UserPermissions
        //public ActionResult Index()
        //{
        //    return View(db.UserPermissionDetails.ToList());
        //}

        //// GET: UserPermissions/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //UserPermission userPermission = db.UserPermissions.Find(id);
        //    UserPermissionDetails userPermission = db.UserPermissionDetails.Find(id);
        //    if (userPermission == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userPermission);
        //}

        //// GET: UserPermissions/Create
        //public ActionResult Create()
        //{
        //    List<SelectListItem> userList = context.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.Id.ToString(), Text = rr.UserName }).ToList();
        //    ViewBag.vbUserList = userList;
        //    List<SelectListItem> itemList = db.Items.OrderBy(r => r.ItemName).ToList().Select(rr => new SelectListItem { Value = rr.ItemId.ToString(), Text = rr.ItemName }).ToList();
        //    ViewBag.vbItemList = itemList;

        //    return View();
        //}

        //// POST: UserPermissions/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "UserPermissionId,ItemId,UserId,UserName")] UserPermission userPermission)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string strUserId = userPermission.UserId.ToString();
        //        string strUserName = (from p in context.Users where p.Id.Equals(strUserId) select p).First().UserName.ToString();
        //        userPermission.UserName = strUserName;
        //        db.UserPermissions.Add(userPermission);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }



        //    return View(userPermission);
        //}

        //// GET: UserPermissions/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserPermission userPermission = db.UserPermissions.Find(id);
        //    if (userPermission == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    List<SelectListItem> userList = context.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.Id.ToString(), Text = rr.UserName }).ToList();
        //    ViewBag.vbUserList = userList;
        //    List<SelectListItem> itemList = db.Items.OrderBy(r => r.ItemName).ToList().Select(rr => new SelectListItem { Value = rr.ItemId.ToString(), Text = rr.ItemName }).ToList();
        //    ViewBag.vbItemList = itemList;

        //    return View(userPermission);
        //}

        //// POST: UserPermissions/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserPermissionId,ItemId,UserId,UserName")] UserPermission userPermission)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(userPermission).State = EntityState.Modified;

        //        string strUserId = userPermission.UserId.ToString();
        //        string strUserName = (from p in context.Users where p.Id.Equals(strUserId) select p).First().UserName.ToString();
        //        userPermission.UserName = strUserName;

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(userPermission);
        //}

        //// GET: UserPermissions/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserPermissionDetails userPermission = db.UserPermissionDetails.Find(id);
        //    if (userPermission == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userPermission);
        //}

        //// POST: UserPermissions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    UserPermission userPermission = db.UserPermissions.Find(id);
        //    db.UserPermissions.Remove(userPermission);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        /////////////////////////////////////////////////////////////////////////////////////

        //public ActionResult Index()
        //{
        //    using (var db = new StoreContext())
        //    {
        //        FillViewBugs(db);
        //    }
        //    return View();
        //}

        //public ActionResult ReadUserPermitions([DataSourceRequest]DataSourceRequest request, string userName, string itemID)
        //{
        //    using (var db = new StoreContext())
        //    {

        //        IQueryable<vwUserPermission> vwUserPermission = db.vwUserPermissions;
        //        if (!string.IsNullOrEmpty(userName))
        //        {
        //            vwUserPermission = vwUserPermission.Where(p => p.UserName.StartsWith(userName));
        //        }
        //        if (itemID != "")
        //        {
        //            int id = Convert.ToInt32(itemID);
        //            vwUserPermission = vwUserPermission.Where(p => p.ItemId == id);
        //        }
        //        DataSourceResult result = vwUserPermission.ToDataSourceResult(request);
        //        return Json(result);
        //    }
        //}

        //public ActionResult CreateUserPermition([DataSourceRequest]DataSourceRequest request, vwUserPermission userPermission)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new vwUserPermission()
        //            {
        //                UserPermissionId = userPermission.UserPermissionId,
        //                ItemId = userPermission.ItemId,
        //                UserId = userPermission.UserId,
        //                UserName = userPermission.UserName
        //            };
        //            db.vwUserPermissions.Add(entity);
        //            db.SaveChanges();
        //            userPermission.UserPermissionId = entity.UserPermissionId;
        //        }
        //    }
        //    var dbo = new StoreContext();
        //    List<SelectListItem> userList = context.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.Id.ToString(), Text = rr.UserName }).ToList();
        //    ViewBag.vbUserList = userList;
        //    List<SelectListItem> itemList = dbo.vwItems.OrderBy(r => r.ItemName).ToList().Select(rr => new SelectListItem { Value = rr.ItemId.ToString(), Text = rr.ItemName }).ToList();
        //    ViewBag.vbItemList = itemList;
        //    return Json(new[] { userPermission }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult UpdateUserPermition([DataSourceRequest]DataSourceRequest request, UserPermission userPermission)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            db.UserPermissions.Attach(userPermission);
        //            db.Entry(userPermission).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { userPermission }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult DestroyUserPermition([DataSourceRequest]DataSourceRequest request, UserPermission userPermission)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var db = new StoreContext())
        //        {
        //            var entity = new UserPermission
        //            {
        //                UserPermissionId = userPermission.UserPermissionId,
        //            };
        //            db.UserPermissions.Attach(entity);
        //            db.UserPermissions.Remove(entity);
        //            db.SaveChanges();
        //        }
        //    }
        //    return Json(new[] { userPermission }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult UserPermissionDetails(int? id)
        //{
        //    using (var db = new StoreContext())
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        vwUserPermission userPermission = db.vwUserPermissions.Find(id);
        //        if (userPermission == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        else
        //        {
        //            return View(userPermission);
        //        }
        //    }
        //}

        //private void FillViewBugs(StoreContext db)
        //{
        //    var lItems = new List<SelectListItem>();
        //    lItems = db.vwItems.Select(x => new SelectListItem { Text = x.ItemName, Value = x.ItemCode.ToString() }).ToList();
        //    ViewBag.vbItems = lItems;
        //}
    }
}
