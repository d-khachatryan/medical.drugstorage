using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class UserPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserPermissionId { get; set; }

        [Display(Name = "Users_OrgName", ResourceType = typeof(Resources.Resources))]
        public int? OrganizationId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public bool? IsOrganizationUser { get; set; }

        public bool? IsStorageUser { get; set; }

        public bool? IsRegionUser { get; set; }

        public bool? IsGovermentUser { get; set; }

        public bool? IsAdministrator { get; set; }

    }
}