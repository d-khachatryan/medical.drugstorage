using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    [Table("vwAspNetUserRoles")]
    public class UserRoleItem
    {
        [Column(Order = 0), Key]
        [Display(Name = "UserId", ResourceType = typeof(Resources.rsUser))]
        public string UserId { get; set; }

        [Column(Order = 1), Key]
        [Display(Name = "RoleId", ResourceType = typeof(Resources.rsUser))]
        public string RoleId { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.rsUser))]
        public string Name { get; set; }
    }
}