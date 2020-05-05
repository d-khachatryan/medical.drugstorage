using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    [Table("vwUserPermission", Schema = "dbo")]
    public class UserPermissionDetails
    {
        [Key]
        public int UserPermissionId { get; set; }

        public int OrganizationId { get; set; }

        public System.Guid UserId { get; set; }

        [Display(Name = "Users_User", ResourceType = typeof(Resources.Resources))]
        public string UserName { get; set; }

        [Display(Name = "Users_OrgName", ResourceType = typeof(Resources.Resources))]
        public string OrganizationName { get; set; }

        [Display(Name = "Users_OrgCode", ResourceType = typeof(Resources.Resources))]
        public string OrganizationCode { get; set; }


    }
}

