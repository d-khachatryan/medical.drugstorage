using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    [Table("vwUserOrganization")]
    public class UserOrganizationItem
    {
        [Key]
        [Display(Name = "UserOrganizationId", ResourceType = typeof(Resources.rsUser))]
        public int UserOrganizationId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Resources.rsUser))]
        public string Id { get; set; }

        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsUser))]
        public int? OrganizationId { get; set; }

        [Display(Name = "OrganizationCode", ResourceType = typeof(Resources.rsUser))]
        public string OrganizationCode { get; set; }

        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsUser))]
        public string OrganizationName { get; set; }

        [Display(Name = "Psm01", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm01 { get; set; }

        [Display(Name = "Psm02", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm02 { get; set; }

        [Display(Name = "Psm03", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm03 { get; set; }

        [Display(Name = "Psm04", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm04 { get; set; }

        [Display(Name = "Psm05", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm05 { get; set; }

        [Display(Name = "Psm06", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm06 { get; set; }

        [Display(Name = "Psm07", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm07 { get; set; }

        [Display(Name = "Psm08", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm08 { get; set; }

        [Display(Name = "Psm09", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm09 { get; set; }

        [Display(Name = "Psm10", ResourceType = typeof(Resources.rsUser))]
        public bool? Psm10 { get; set; }
    }
}