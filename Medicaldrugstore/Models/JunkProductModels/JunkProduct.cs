using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    public class JunkProduct
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Display(Name = "Product_Code", ResourceType = typeof(Resources.Resources))]
        public int JunkProductId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsJunkProduct))]
        public int? OrganizationId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ProductId",ResourceType = typeof(Resources.rsJunkProduct))]
        public int? ProductId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Product_RegistrationDate", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "JunkProductDate", ResourceType = typeof(Resources.rsJunkProduct))]
        public DateTime? JunkProductDate { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "StorageId", ResourceType = typeof(Resources.rsJunkProduct))]
        //[Display(Name = "Product_StorageId", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? StorageId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Required(ErrorMessageResourceName = "Product_Quantity_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsJunkProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int Quantity { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Product_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsJunkProduct))]
        public double? ItemQuantity { get; set; }
        //////////////////////////////////////////////////////////////////////////////// 
        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsJunkProduct))]
        public double? UnitCost { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        //[Display(Name = "Ընդամենը արժեք")]
        //[Display(Name = "Product_TotalCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsJunkProduct))]
        public double? TotalCost { get; set; }
        ////////////////////////////////////////////////////////////////////////////////     
        [Display(Name = "JunkProductStatusId", ResourceType = typeof(Resources.rsJunkProduct))]
        //[Display(Name = "Կարգավիճակ")]
        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? JunkProductStatusId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////  
        [Display(Name = "JunkBaseId", ResourceType = typeof(Resources.rsJunkProduct))]
        //[Display(Name = "Խոտանման հիմք")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? JunkBaseId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
    }

}