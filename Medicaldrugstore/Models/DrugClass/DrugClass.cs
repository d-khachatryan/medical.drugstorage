using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class DrugClass
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrugClassId { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "DrugClass_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugClassName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugClassName { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_GenericName", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "GenericName", ResourceType = typeof(Resources.rsDrugClass))]
        public string GenericName { get; set; }

        //[Display(Name = "Drug_ProductCategory", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductCategoryName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductCategoryId { get; set; }

        //[Display(Name = "Drug_ProductGroup", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductGroupName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductGroupId { get; set; }

        //[Display(Name = "Drug_ProductType", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? ProductTypeId { get; set; }

        //[Display(Name = "Drug_DrugType", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugTypeId { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_DrugCategory", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugCategoryName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugCategoryId { get; set; }

        //[Display(Name = "DrugCategory_UnitItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitItemQuantity", ResourceType = typeof(Resources.rsDrugClass))]
        public int? UnitItemQuantity { get; set; }

        //[Display(Name = "DrugClass_Status", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugClassStatus", ResourceType = typeof(Resources.rsDrugClass))]
        public bool? DrugClassStatus { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_StoreOrganization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "StoreOrganizationName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? StoreOrganizationId { get; set; }

    }
}