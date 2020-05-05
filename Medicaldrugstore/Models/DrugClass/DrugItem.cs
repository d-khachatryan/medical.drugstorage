using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    [Table("vwDrugItem", Schema = "dbo")]
    public class DrugItem
    {
        [Key]
        //[Display(Name = "Drug_ATCCode", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugId", ResourceType = typeof(Resources.rsDrugClass))]
        public int DrugId { get; set; }

        //[Display(Name = "Drug_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugName { get; set; }

        //[Display(Name = "Ազդանյութ")]
        [Display(Name = "GenericName", ResourceType = typeof(Resources.rsDrugClass))]
        public string GenericName { get; set; }

        //[Display(Name = "Product_CategoryName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductCategoryId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductCategoryId { get; set; }

        [Display(Name = "ProductCategoryName", ResourceType = typeof(Resources.rsDrugClass))]
        public string ProductCategoryName { get; set; }

        //[Display(Name = "Product_GroupName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductGroupId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductGroupId { get; set; }

        [Display(Name = "ProductGroupName", ResourceType = typeof(Resources.rsDrugClass))]
        public string ProductGroupName { get; set; }

        //[Display(Name = "Product_TypeName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductTypeId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductTypeId { get; set; }

        [Display(Name = "ProductTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public string ProductTypeName { get; set; }

        //[Display(Name = "Product_UnitType", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitTypeId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? UnitTypeId { get; set; }

        [Display(Name = "UnitTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public string UnitTypeName { get; set; }
        //[Display(Name = "DrugCategory_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugCategoryId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugCategoryId { get; set; }

        
        [Display(Name = "DrugCategoryName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugCategoryName { get; set; }

        [Display(Name = "DrugTypeId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugTypeId { get; set; }

        [Display(Name = "DrugTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugTypeName { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_Source", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugSourceId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugSourceId { get; set; }

        [Display(Name = "DrugSourceName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugSourceName { get; set; }

        [Required(ErrorMessageResourceName = "Product_Seria_Required", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Product_Seria", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Seria", ResourceType = typeof(Resources.rsDrugClass))]
        public string Seria { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Product_ExpirationDate", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ExpirationDate", ResourceType = typeof(Resources.rsDrugClass))]
        public DateTime? ExpirationDate { get; set; }

        //[Display(Name = "Product_SupplierName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "SupplierId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? SupplierId { get; set; }

        [Display(Name = "SupplierName", ResourceType = typeof(Resources.rsDrugClass))]
        public string SupplierName { get; set; }

        //[Display(Name = "Երկիր")]
        //[Display(Name = "Product_CountryId", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "CountryId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? CountryId { get; set; }

        [Display(Name = "CountryName", ResourceType = typeof(Resources.rsDrugClass))]
        public string CountryName { get; set; }

        //[Display(Name = "Արտադրող")]
        //[Display(Name = "Product_Manufacturer", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Manufacturer", ResourceType = typeof(Resources.rsDrugClass))]
        public string Manufacturer { get; set; }

        //[Display(Name = "Product_UnitCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsDrugClass))]
        public double? UnitCost { get; set; }

        //[Display(Name = "Product_Organization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? OrganizationId { get; set; }

        [Display(Name = "OrganizationCode", ResourceType = typeof(Resources.rsDrugClass))]
        public string OrganizationCode { get; set; }

        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsDrugClass))]
        public string OrganizationName { get; set; }

        //[Display(Name = "Product_StoreOrganization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "StoreOrganizationId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? StoreOrganizationId { get; set; }

        [Display(Name = "StoreOrganizationCode", ResourceType = typeof(Resources.rsDrugClass))]
        public string StoreOrganizationCode { get; set; }

        [Display(Name = "StoreOrganizationName", ResourceType = typeof(Resources.rsDrugClass))]
        public string StoreOrganizationName { get; set; }

        //[Display(Name = "Product_Quantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsDrugClass))]
        public int? Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Product_TotalCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsDrugClass))]
        public double? TotalCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsDrugClass))]
        public double? ItemQuantity { get; set; }

        //[DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Drug_Description", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Description", ResourceType = typeof(Resources.rsDrugClass))]
        public string Description { get; set; }

        [Display(Name = "DrugClassId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugClassId { get; set; }

        //[Display(Name = "DrugClass_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugClassName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugClassName { get; set; }

        //[Display(Name = "DrugClass_Status", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugClassStatus", ResourceType = typeof(Resources.rsDrugClass))]
        public bool? DrugClassStatus { get; set; }

    }    
}