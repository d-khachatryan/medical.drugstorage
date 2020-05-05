using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    public class StoreOrganization
    {
        [Key]
        public int OrganizationId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "Organization_Code", ResourceType = typeof(Resources.Resources))]
        public string OrganizationCode { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "Organization_Name", ResourceType = typeof(Resources.Resources))]
        public string OrganizationName { get; set; }       
    }
}