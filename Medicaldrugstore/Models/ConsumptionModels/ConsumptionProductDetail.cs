using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    [Table("vwConsumptionProduct", Schema = "dbo")]
    public class ConsumptionProductDetail
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ConsumptionProductId", ResourceType = typeof(Resources.rsConsumption))]
        public int ConsumptionProductId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////  
        [Display(Name = "ConsumptionId", ResourceType = typeof(Resources.rsConsumption))]
        public int? ConsumptionId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////       
        //[Display(Name = "Consumption_Product", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsConsumption))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? ProductId { get; set; }
        //////////////////////////////////////////////////////////////////////////////// 
        [Display(Name = "ProductName", ResourceType = typeof(Resources.rsConsumption))]
        public string ProductName { get; set; }
        //////////////////////////////////////////////////////////////////////////////// 
        //[Display(Name = "Consumption_Quantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsConsumption))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? Quantity { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Consumption_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsConsumption))]
        public double? ItemQuantity { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Consumption_UnitCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsConsumption))]
        public double? UnitCost { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Consumption_TotalCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsConsumption))]
        public double? TotalCost { get; set; }
    }
}