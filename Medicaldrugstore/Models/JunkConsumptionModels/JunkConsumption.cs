using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    public class JunkConsumption
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "JunkConsumptionId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int JunkConsumptionId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int? OrganizationId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int? ProductId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Product_RegistrationDate", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "JunkConsumptionDate", ResourceType = typeof(Resources.rsJunkConsumption))]
        public DateTime? JunkConsumptionDate { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Required(ErrorMessageResourceName = "Product_Quantity_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int Quantity { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsJunkConsumption))]
        public double? ItemQuantity { get; set; }
        //////////////////////////////////////////////////////////////////////////////// 
        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsJunkConsumption))]
        public double? UnitCost { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Ընդամենը արժեք")]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsJunkConsumption))]
        public double? TotalCost { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "JunkConsumptionStatusId", ResourceType = typeof(Resources.rsJunkConsumption))]     
        public int? JunkConsumptionStatusId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "JunkBaseId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int? JunkBaseId { get; set; }

    }

}