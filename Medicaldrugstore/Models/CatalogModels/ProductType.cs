using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Medicaldrugstore.Attribute;
using System.ComponentModel;

namespace Medicaldrugstore.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        //[SupplierCodeRepetition(ErrorMessage = "The Product type Code is repeated")]
        [Display(Name = "ProductType_Code", ResourceType = typeof(Resources.Resources))]
        public string ProductTypeCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        //[SupplierNameRepetition(ErrorMessage = "The product type name is repeated")]
        [Display(Name = "ProductType_Name", ResourceType = typeof(Resources.Resources))]
        public string ProductTypeName { get; set; }
    }
}