using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    [Table("vwJunkConsumption", Schema = "dbo")]
    public class JunkConsumptionDetail
    {
        [Key]
        //[Display(Name = "Product_Code", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "JunkConsumptionId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int JunkConsumptionId { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int? OrganizationId { get; set; }

        [Display(Name = "OrganizationCode", ResourceType = typeof(Resources.rsJunkConsumption))]
        public string OrganizationCode { get; set; }

        [Display(Name = "Organization_Name", ResourceType = typeof(Resources.rsJunkConsumption))]
        public string OrganizationName { get; set; }

        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int? ProductId { get; set; }

        [Display(Name = "ProductName", ResourceType = typeof(Resources.rsJunkConsumption))]
        public string ProductName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "RegistrationDate", ResourceType = typeof(Resources.rsJunkConsumption))]
        //[Display(Name = "Մուտքագրման ա/թ")]
        public DateTime? JunkConsumptionDate { get; set; }
                     
        //[Required(ErrorMessageResourceName = "Product_Quantity_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int Quantity { get; set; }
        
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsJunkConsumption))]
        public double? ItemQuantity { get; set; }

        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsJunkConsumption))]
        public double? UnitCost { get; set; }

        //[Display(Name = "Ընդամենը արժեք")]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsJunkConsumption))]
        public double? TotalCost { get; set; }

        [Display(Name = "JunkConsumptionStatusId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int? JunkConsumptionStatusId { get; set; }

        [Display(Name = "JunkConsumptionStatusName", ResourceType = typeof(Resources.rsJunkConsumption))]
        public string JunkConsumptionStatusName { get; set; }

        [Display(Name = "JunkBaseId", ResourceType = typeof(Resources.rsJunkConsumption))]
        public int? JunkBaseId { get; set; }

        [Display(Name = "JunkBaseName", ResourceType = typeof(Resources.rsJunkConsumption))]
        public string JunkBaseName { get; set; }

    }

}