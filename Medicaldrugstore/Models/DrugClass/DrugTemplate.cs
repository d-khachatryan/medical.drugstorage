using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class DrugTemplate
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "DrugId", ResourceType = typeof(Resources.rsDrugClass))]
        public int DrugId { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        [Display(Name = "Seria", ResourceType = typeof(Resources.rsDrugClass))]
        public string Seria { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "DrugName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugName { get; set; }        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ExpirationDate", ResourceType = typeof(Resources.rsDrugClass))]
        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_UnitType", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? UnitTypeId { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_Organization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? OrganizationId { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_StoreOrganization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "StoreOrganizationId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? StoreOrganizationId { get; set; }

        [Display(Name = "DrugClassId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugClassId { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_Source", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugSourceId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugSourceId { get; set; }

        //[Display(Name = "Drug_Supplier", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "SupplierId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? SupplierId { get; set; }

        //[Display(Name = "Drug_Country", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "CountryId", ResourceType = typeof(Resources.rsDrugClass))]
        public int? CountryId { get; set; }

        //[Display(Name = "Drug_Manufacturer", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Manufacturer", ResourceType = typeof(Resources.rsDrugClass))]
        public string Manufacturer { get; set; }

        //[Display(Name = "Drug_DrugQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsDrugClass))]
        public int Quantity { get; set; }

        //[Display(Name = "Drug_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsDrugClass))]
        public double? ItemQuantity { get; set; }

        //[Display(Name = "Drug_UnitCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsDrugClass))]
        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        public double? UnitCost { get; set; }

        //[Display(Name = "Drug_TotalCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsDrugClass))]
        public double? TotalCost { get; set; }

        //[Display(Name = "Drug_Description", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Description", ResourceType = typeof(Resources.rsDrugClass))]
        public string Description { get; set; }

        [Display(Name = "Բաշխում")]
        //[Display(Name = "", ResourceType = typeof(Resources.rsDrugClass))]
        public virtual ICollection<Product> Products { get; set; }

    }
}