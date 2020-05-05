using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    public class Organization
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganizationId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "RegionId", ResourceType = typeof(Resources.rsOrganization))]
        public int? RegionId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "GovermentId", ResourceType = typeof(Resources.rsOrganization))]
        public int? GovermentId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////     
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        [Display(Name = "OrganizationCode", ResourceType = typeof(Resources.rsOrganization))]
        public string OrganizationCode { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsOrganization))]
        public string OrganizationName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "OrganizationLocation", ResourceType = typeof(Resources.rsOrganization))]
        public string OrganizationLocation { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "DeliveryLocation", ResourceType = typeof(Resources.rsOrganization))]
        public string DeliveryLocation { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "RegistrationNumber", ResourceType = typeof(Resources.Resources))]
        public string RegistrationNumber { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "BankId", ResourceType = typeof(Resources.Resources))]
        public int? BankId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "BankAccountNumber", ResourceType = typeof(Resources.rsOrganization))]
        public string BankAccountNumber { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "TinNumber", ResourceType = typeof(Resources.Resources))]
        public string TinNumber { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "HeadName", ResourceType = typeof(Resources.rsOrganization))]
        public string HeadName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "AccountantName", ResourceType = typeof(Resources.rsOrganization))]
        public string AccountantName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "ResponsibleName", ResourceType = typeof(Resources.rsOrganization))]
        public string ResponsibleName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "IsOrganization", ResourceType = typeof(Resources.rsOrganization))]
        public bool? IsOrganization { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "IsStorage", ResourceType = typeof(Resources.rsOrganization))]
        public bool? IsStorage { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "IsRegion", ResourceType = typeof(Resources.rsOrganization))]
        public bool? IsRegion { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "IsGoverment", ResourceType = typeof(Resources.rsOrganization))]
        public bool? IsGoverment { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Կազմակերպության կոդ")]
        //public int? ItemId { get; set; }
    }
}