using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class Drug
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Display(Name = "Drug_ATCCode", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugId", ResourceType = typeof(Resources.rsDrugClass))]
        public int DrugId { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_Seria", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Seria", ResourceType = typeof(Resources.rsDrugClass))]
        public string Seria { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        //[Display(Name = "Drug_Name", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugName", ResourceType = typeof(Resources.rsDrugClass))]
        public string DrugName { get; set; }        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Drug_ExpirationDate", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ExpirationDate", ResourceType = typeof(Resources.rsDrugClass))]
        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_UnitType", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitTypeName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? UnitTypeId { get; set; }


        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_Organization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? OrganizationId { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_StoreOrganization", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "StoreOrganizationName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? StoreOrganizationId { get; set; }

        public int? DrugClassId { get; set; }

        [ForeignKey("DrugClassId")]
        public DrugClass DrugClass { get; set; }

        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        //[Display(Name = "Drug_Source", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugSourceName", ResourceType = typeof(Resources.rsDrugClass))]
        public int? DrugSourceId { get; set; }

        [Display(Name = "SupplierName", ResourceType = typeof(Resources.rsDrugClass))]
        //[Display(Name = "Drug_Supplier", ResourceType = typeof(Resources.Resources))]
        public int? SupplierId { get; set; }

        [Display(Name = "CountryName", ResourceType = typeof(Resources.rsDrugClass))]
        //[Display(Name = "Drug_Country", ResourceType = typeof(Resources.Resources))]
        public int? CountryId { get; set; }

        [Display(Name = "Manufacturer", ResourceType = typeof(Resources.rsDrugClass))]
        //[Display(Name = "Drug_Manufacturer", ResourceType = typeof(Resources.Resources))]
        public string Manufacturer { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsDrugClass))]
        //[Display(Name = "Drug_DrugQuantity", ResourceType = typeof(Resources.Resources))]
        public int Quantity { get; set; }

        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsDrugClass))]
        //[Display(Name = "Drug_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        public double? ItemQuantity { get; set; }

        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsDrugClass))]
        //[Display(Name = "Drug_UnitCost", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceName = "General_FieldIsRequired", ErrorMessageResourceType = typeof(Resources.Resources))]
        public double? UnitCost { get; set; }

        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsDrugClass))]
        //[Display(Name = "Drug_TotalCost", ResourceType = typeof(Resources.Resources))]
        public double? TotalCost { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.rsDrugClass))]
        //[Display(Name = "Drug_Description", ResourceType = typeof(Resources.Resources))]
        public string Description { get; set; }

        [Display(Name = "Բաշխում")]
        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<DrugPicture> Files { get; set; }

    }
}