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
    public class Supplier
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        //[SupplierCodeRepetition(ErrorMessage = "The Supplier code is repeated")]
        [Display(Name = "Supplier_Code", ResourceType = typeof(Resources.Resources))]
        public string SupplierCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        //[SupplierNameRepetition(ErrorMessage = "The Supplier name is repeated")]
        [Display(Name = "Supplier_Name", ResourceType = typeof(Resources.Resources))]
        public string SupplierName { get; set; }
    }
}
