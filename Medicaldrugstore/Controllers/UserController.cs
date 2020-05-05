using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Medicaldrugstore.Models;
using Medicaldrugstore.DAL;
using System.Data.Entity;

namespace Medicaldrugstore.Controllers
{
    public class UserController : Controller
    {
        private ApplicationUserManager userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        private readonly ApplicationDbContext context = new ApplicationDbContext();

        //[Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ApplicationUser> users = context.Users;
            DataSourceResult result = users.ToDataSourceResult(request);
            return Json(result);
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult CreateUser()
        {
            try
            {
                var item = new UserItem();
                return View("UserTemplate", item);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "User", "CreateUser"));
            }
        }

        //[Authorize(Roles = "administrator")]
        public ActionResult UpdateUser(string id)
        {
            try
            {
                var model = new UserItem();
                IQueryable<ApplicationUser> q = from user in context.Users where user.Id.Equals(id) select user;
                ApplicationUser applicationUser = q.First();
                model.Id = applicationUser.Id;
                model.UserName = applicationUser.UserName;
                model.Email = applicationUser.Email;
                return View("UserTemplate", model);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "User", "UpdateUser"));
            }
        }

        [HttpPost]
        //[Authorize(Roles = "administrator")]
        public ActionResult SaveUser(UserItem user)
        {
            try
            {
                if (String.IsNullOrEmpty(user.Id))
                {
                    var applicationUser = new ApplicationUser
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PositionName = user.PositionName
                    };
                    IdentityResult result = UserManager.Create(applicationUser, user.Password);

                    if (result.Succeeded)
                    {
                        //return Json("1", JsonRequestBehavior.AllowGet);
                        string code = UserManager.GenerateEmailConfirmationToken(applicationUser.Id);
                        string callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = applicationUser.Id, code = code }, protocol: Request.Url.Scheme);
                        UserManager.SendEmail(applicationUser.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    }
                }
                else
                {
                    ApplicationUser applicationUser = UserManager.FindById(user.Id.ToString());
                    if (user != null)
                    {
                        applicationUser.Email = user.Email;
                        applicationUser.UserName = user.UserName;
                        applicationUser.FirstName = user.FirstName;
                        applicationUser.LastName = user.LastName;
                        applicationUser.PositionName = user.PositionName;
                        IdentityResult result = UserManager.Update(applicationUser);
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
        public ActionResult Delete(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    ApplicationUser user = UserManager.FindById(id);
                    ICollection<IdentityUserLogin> logins = user.Logins;
                    foreach (var login in logins.ToList())
                    {
                        UserManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }
                    IList<string> rolesForUser = UserManager.GetRoles(id);
                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            IdentityResult result = UserManager.RemoveFromRole(user.Id, item);
                        }
                    }
                    UserManager.Delete(user);
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        
        public ActionResult ReadUserRoles([DataSourceRequest]DataSourceRequest request, string Id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<UserRoleItem> userRoles = db.UserRoleItems.Where(p => p.UserId == Id);
                DataSourceResult result = userRoles.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult UserRoleTemplate(string id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    var lRoles = new List<SelectListItem>();
                    lRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                    ViewBag.vbRoles = lRoles;


                    var item = new UserRoleItem();
                    item.UserId = id;
                    return View("UserRoleTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SaveUserRole(UserRoleItem userRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    ApplicationUser applicationUser = userManager.FindById(userRole.UserId);
                    IdentityRole role = context.Roles.Where(p => p.Id == userRole.RoleId).First();
                    userManager.AddToRole(applicationUser.Id, role.Name);
                    context.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteUserRole(string userId, string roleName)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                ApplicationUser user = userManager.FindById(userId);
                if (userManager.IsInRole(user.Id, roleName))
                {
                    userManager.RemoveFromRole(user.Id, roleName);
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ReadUserOrganizations([DataSourceRequest]DataSourceRequest request, string id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<UserOrganizationItem> userOrganization = db.UserOrganizationItems.Where(p => p.Id == id);
                DataSourceResult result = userOrganization.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult CreateUserOrganization(string id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    var lOrganizations = new List<SelectListItem>();
                    lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                    ViewBag.vbOrganizations = lOrganizations;

                    var item = new UserOrganization();
                    item.Id = id;
                    return View("UserOrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult UpdateUserOrganization(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    var lOrganizations = new List<SelectListItem>();
                    lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                    ViewBag.vbOrganizations = lOrganizations;


                    UserOrganization item = db.UserOrganizations.Find(id);
                    return View("UserOrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult DeleteUserOrganization([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new UserOrganization()
                        {
                            UserOrganizationId = Convert.ToInt32(id),
                        };
                        db.UserOrganizations.Attach(item);
                        db.UserOrganizations.Remove(item);
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

        [HttpPost]
        public ActionResult SaveUserOrganization(UserOrganization userOrganization)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.UserOrganizations.Where(p => p.UserOrganizationId == userOrganization.UserOrganizationId).Count();

                    if (cnt == 0)
                    {
                        db.UserOrganizations.Add(userOrganization);
                    }
                    else
                    {
                        db.UserOrganizations.Attach(userOrganization);
                        db.Entry(userOrganization).State = EntityState.Modified;
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

    }
}