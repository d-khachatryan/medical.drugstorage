using Medicaldrugstore.Models;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Text;
using System;

namespace Medicaldrugstore.DAL
{
    public class UserPermission
    {
        public string PermissionPattern = "0000000000000000";

        public UserPermission()
        {
            var db = new ApplicationDbContext();
            ApplicationUserManager userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (user != null)
            {
                foreach (var item in db.Roles)
                {
                    if (userManager.IsInRole(user.Id, item.Name))
                    {
                        var sb = new StringBuilder(PermissionPattern);
                        sb[Convert.ToInt32(item.Id)] = '1';
                        PermissionPattern = sb.ToString();
                    }
                }
            }
        }
    }
}