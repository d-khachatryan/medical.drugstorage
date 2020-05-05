using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicaldrugstore.Models
{
    [Table("vwConsumption", Schema = "dbo")]
    public class ConsumptionDetail
    {
        [Key]
        [Display(Name = "ConsumptionId", ResourceType = typeof(Resources.rsConsumption))]
        public int ConsumptionId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ConsumptionDate", ResourceType = typeof(Resources.rsConsumption))]
        public DateTime? ConsumptionDate { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "TerminationDate", ResourceType = typeof(Resources.rsConsumption))]
        public DateTime? TerminationDate { get; set; }
        //////////////////////////////////////////////////////////////////////////////// 
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsConsumption))]
        public int? OrganizationId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////   
        [Display(Name = "OrganizationCode", ResourceType = typeof(Resources.rsConsumption))]
        public string OrganizationCode { get; set; }
        ////////////////////////////////////////////////////////////////////////////////  
        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsConsumption))]
        public string OrganizationName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////   
        [Display(Name = "ConsumptionStatusId", ResourceType = typeof(Resources.rsConsumption))]
        public int? ConsumptionStatusId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////  
        [Display(Name = "ConsumptionStatusName", ResourceType = typeof(Resources.rsConsumption))]
        public string ConsumptionStatusName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
    }
}