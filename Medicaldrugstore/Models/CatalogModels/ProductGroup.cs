using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Medicaldrugstore.Attribute;
using System.ComponentModel;


namespace Medicaldrugstore.Models
{
    public class ProductGroup
    {
        public int ProductGroupId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        //[SupplierCodeRepetition(ErrorMessage = "The Product group Code is repeated")]
        [Display(Name = "ProductGroup_Code", ResourceType = typeof(Resources.Resources))]
        public string ProductGroupCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        //[SupplierNameRepetition(ErrorMessage = "The product group name is repeated")]
        [Display(Name = "ProductGroup_Name", ResourceType = typeof(Resources.Resources))]
        public string ProductGroupName { get; set; }
    }
}
