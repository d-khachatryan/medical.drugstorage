using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    [Table("vwStorage", Schema = "dbo")]
    public class StorageDetail
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StorageId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "StorageCode", ResourceType = typeof(Resources.rsOrganization))]
        public string StorageCode { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "StorageName", ResourceType = typeof(Resources.rsOrganization))]
        public string StorageName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsOrganization))]
        public int? OrganizationId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////   
        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsOrganization))]
        public string OrganizationName { get; set; }
    }
}