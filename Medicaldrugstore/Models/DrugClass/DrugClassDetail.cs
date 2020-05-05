using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medicaldrugstore.Models
{
    [Table("vwDrugClass", Schema = "dbo")]
    public class DrugClassDetail
    {
        [Key]
        //[Display(Name = "Drug_ATCCode", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugName", ResourceType = typeof(Resources.rsDrugClass))]
        public int DrugClassId { get; set; }

        //[Display(Name = "DrugClass_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugClassName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugClassName { get; set; }

        //[Display(Name = "Drug_GenericName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "GenericName", ResourceType = typeof(Resources.rsDrugClass))]
        public string GenericName { get; set; }

        //[Display(Name = "Product_CategoryName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductCategoryId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductCategoryId { get; set; }

        //[Display(Name = "Product_CategoryName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductCategoryName", ResourceType = typeof(Resources.rsDrugClass))]
        public string ProductCategoryName { get; set; }

        //[Display(Name = "Product_GroupName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductGroupId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductGroupId { get; set; }

        //[Display(Name = "Product_GroupName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductGroupName", ResourceType = typeof(Resources.rsDrugClass))]
        public string ProductGroupName { get; set; }

        //[Display(Name = "Product_TypeName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductTypeId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductTypeId { get; set; }

        //[Display(Name = "Product_TypeName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public string ProductTypeName { get; set; }

        //[Display(Name = "DrugType_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugTypeId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugTypeId { get; set; }

        //[Display(Name = "DrugType_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugTypeName { get; set; }

        //[Display(Name = "Drug_DrugCategory", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugCategoryId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugCategoryId { get; set; }

        //[Display(Name = "Drug_DrugCategory", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugCategoryName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugCategoryName { get; set; }

        //[Display(Name = "DrugCategory_UnitItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitItemQuantity", ResourceType = typeof(Resources.rsDrugClass))]
        public int? UnitItemQuantity { get; set; }

        //[Display(Name = "DrugClass_Status", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugClassStatus", ResourceType = typeof(Resources.rsDrugClass))]
        public bool? DrugClassStatus { get; set; }

        //[Display(Name = "Product_StoreOrganization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "StoreOrganizationId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? StoreOrganizationId { get; set; }

        [Display(Name = "StoreOrganizationName", ResourceType = typeof(Resources.rsDrugClass))]
        public string StoreOrganizationCode { get; set; }

        [Display(Name = "StoreOrganizationName", ResourceType = typeof(Resources.rsDrugClass))]
        public string StoreOrganizationName { get; set; }

    }
}