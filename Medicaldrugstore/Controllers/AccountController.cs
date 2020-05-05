using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Medicaldrugstore.Models;
using Medicaldrugstore.DAL;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;
using System.Data.Entity;

namespace Medicaldrugstore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //string code = await UserManager.GeneratePasswordResetTokenAsync("1637ad62-90c4-41b8-a4a4-ceccd772ab4f");
            //var result1 = await UserManager.ResetPasswordAsync("1637ad62-90c4-41b8-a4a4-ceccd772ab4f", code, "Temp`123");
            
            // Require the user to have a confirmed email before they can log on.
            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                //if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                //{
                //    ViewBag.errorMessage = "You must have a confirmed email to log on.";
                //    return View("Error");
                //}
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync (model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                string callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("ChangePasswordConfirmation");
            }
            AddErrors(result);
            return View(model);
        }

        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ChangePasswordConfirmation()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion























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
                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
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
                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
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
                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
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
                return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
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
                    return Json(new { success = true, responseText = string.Empty }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}