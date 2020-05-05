using Medicaldrugstore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicaldrugstore.Helpers
{
    public class OrganizationHelper
    {
        public List<SelectListItem> StorageOrganizations(string userId, StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();

            IQueryable<Models.Organization> organizations = from p in db.Organizations
                                join o in db.UserOrganizations on p.OrganizationId equals o.OrganizationId
                                where o.Id == userId || p.IsStorage == true
                                select p;

            lOrganizations = organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            return lOrganizations;
        }

        public List<SelectListItem> UserOrganizations(string userId, StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();

            IQueryable<Models.Organization> organizations = from p in db.Organizations
                                                            join o in db.UserOrganizations on p.OrganizationId equals o.OrganizationId
                                                            where o.Id == userId
                                                            select p;

            lOrganizations = organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            return lOrganizations;
        }
    }
}