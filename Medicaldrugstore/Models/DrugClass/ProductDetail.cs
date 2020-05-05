using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    [Table("vwProduct", Schema = "dbo")]
    public class ProductDetail
    {
        [Key]
        //[Display(Name = "Product_Code", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsDrugClass))]
        public int ProductId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Product_RegistrationDate", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "RegistrationDate", ResourceType = typeof(Resources.rsDrugClass))]
        public DateTime? RegistrationDate { get; set; }

        //[Display(Name = "Product_DrugName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugId { get; set; }

        [DataType(DataType.MultilineText)]
        //[Display(Name = "Drug_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugName { get; set; }

        //[Display(Name = "Product_Storage", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "StorageId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? StorageId { get; set; }

        [Display(Name = "StorageName", ResourceType = typeof(Resources.rsDrugClass))]
        public string StorageName { get; set; }

        //[Display(Name = "Product_Quantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsDrugClass))]
        public int Quantity { get; set; }

        //[Display(Name = "Product_TotalCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsDrugClass))]
        public double? TotalCost { get; set; }

        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsDrugClass))]
        public double? UnitCost { get; set; }

        //[Display(Name = "Product_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsDrugClass))]
        public double? ItemQuantity { get; set; }


    }    
}