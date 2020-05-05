using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    public class ConsumptionTemplate
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ConsumptionId", ResourceType = typeof(Resources.rsConsumption))]
        public int ConsumptionId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Consumption_ConsumptionDate", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ConsumptionDate", ResourceType = typeof(Resources.rsConsumption))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public DateTime? ConsumptionDate { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [DataType(DataType.Date)]
        //[Display(Name = "Consumption_TerminationDate", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "TerminationDate", ResourceType = typeof(Resources.rsConsumption))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public DateTime? TerminationDate { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Consumption_Organization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsConsumption))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? OrganizationId { get; set; }

        public virtual ICollection<ConsumptionProduct> ConsumptionProducts { get; set; }
    }
}