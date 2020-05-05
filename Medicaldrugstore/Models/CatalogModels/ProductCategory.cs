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
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        //[SupplierCodeRepetition(ErrorMessage = "The Product Category Code is repeated")]
        [Display(Name = "ProductCategory_Code", ResourceType = typeof(Resources.Resources))]
        public string ProductCategoryCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        //[SupplierNameRepetition(ErrorMessage = "The product category name is repeated")]
        [Display(Name = "ProductCategory_Name", ResourceType = typeof(Resources.Resources))]
        public string ProductCategoryName { get; set; }
    }
}