using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    public class Product
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Display(Name = "Product_Code", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsDrugClass))]
        public int ProductId { get; set; }        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Product_RegistrationDate", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "RegistrationDate", ResourceType = typeof(Resources.rsDrugClass))]
        public DateTime? RegistrationDate { get; set; }
        
        [UIHint("DrugId")]
        //[Display(Name = "Product_DrugName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugName", ResourceType = typeof(Resources.rsDrugClass))]
        [ForeignKey("Drug")]
        public int? DrugId { get; set; }

        public Drug Drug { get; set; }        

        //[Display(Name = "Product_Storage", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "StorageId", ResourceType = typeof(Resources.rsDrugClass))]
        [UIHint("StorageId")]
        public int? StorageId { get; set; }

        [Required(ErrorMessageResourceName = "Product_Quantity_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[DataAnnotationsExtensions.Integer(ErrorMessage = "Please enter a valid number.")]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsDrugClass))]
        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Product_TotalCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsDrugClass))]
        public double? TotalCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsDrugClass))]
        public double? UnitCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Product_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsDrugClass))]
        public double? ItemQuantity { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }
    }

}