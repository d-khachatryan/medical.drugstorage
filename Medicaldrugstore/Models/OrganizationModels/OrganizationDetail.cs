using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    [Table("vwOrganization", Schema = "dbo")]
    public class OrganizationDetail
    {
        [Key]
        public int OrganizationId { get; set; }
        [Display(Name = "RegionId", ResourceType = typeof(Resources.rsOrganization))]
        public int? RegionId { get; set; }

        [Display(Name = "RegionName", ResourceType = typeof(Resources.rsOrganization))]
        public string RegionName { get; set; }

        [Display(Name = "GovermentId", ResourceType = typeof(Resources.rsOrganization))]
        public int? GovermentId { get; set; }

        [Display(Name = "GovermentName", ResourceType = typeof(Resources.rsOrganization))]
        public string GovermentName { get; set; }

        [Display(Name = "OrganizationCode", ResourceType = typeof(Resources.rsOrganization))]
        public string OrganizationCode { get; set; }

        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsOrganization))]
        public string OrganizationName { get; set; }

        [Display(Name = "OrganizationLocation", ResourceType = typeof(Resources.rsOrganization))]
        public string OrganizationLocation { get; set; }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        [Display(Name = "DeliveryLocation", ResourceType = typeof(Resources.rsOrganization))]
        public string DeliveryLocation { get; set; }

        [Display(Name = "RegistrationNumber", ResourceType = typeof(Resources.rsOrganization))]
        public string RegistrationNumber { get; set; }        

        [Display(Name = "BankName", ResourceType = typeof(Resources.rsOrganization))]
        public string BankName { get; set; }

        [Display(Name = "BankAccountNumber", ResourceType = typeof(Resources.rsOrganization))]
        public string BankAccountNumber { get; set; }

        [Display(Name = "TinNumber", ResourceType = typeof(Resources.rsOrganization))]
        public string TinNumber { get; set; }

        [Display(Name = "HeadName", ResourceType = typeof(Resources.rsOrganization))]
        public string HeadName { get; set; }

        [Display(Name = "AccountantName", ResourceType = typeof(Resources.rsOrganization))]
        public string AccountantName { get; set; }

        [Display(Name = "ResponsibleName", ResourceType = typeof(Resources.rsOrganization))]
        public string ResponsibleName { get; set; }

        [Display(Name = "IsOrganization", ResourceType = typeof(Resources.rsOrganization))]
        public bool? IsOrganization { get; set; }

        [Display(Name = "IsStorage", ResourceType = typeof(Resources.rsOrganization))]
        public bool? IsStorage { get; set; }

        [Display(Name = "IsRegion", ResourceType = typeof(Resources.rsOrganization))]
        public bool? IsRegion { get; set; }

        [Display(Name = "IsGoverment", ResourceType = typeof(Resources.rsOrganization))]
        public bool? IsGoverment { get; set; }
    }
}