using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    public class StorageTemplate
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StorageId { get; set; }
        //////////////////////////////////////////////////////////////////////////////// 
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "StorageCode", ResourceType = typeof(Resources.rsOrganization))]
        public string StorageCode { get; set; }
        ////////////////////////////////////////////////////////////////////////////////   
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "StorageName", ResourceType = typeof(Resources.rsOrganization))]
        public string StorageName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsOrganization))]
        public int? OrganizationId { get; set; }
    }
}