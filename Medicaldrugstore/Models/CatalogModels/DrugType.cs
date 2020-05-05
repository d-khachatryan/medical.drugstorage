using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class DrugType
    {
        public int DrugTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        [Display(Name = "DrugType_Code", ResourceType = typeof(Resources.Resources))]
        public string DrugTypeCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "DrugType_Name", ResourceType = typeof(Resources.Resources))]
        public string DrugTypeName { get; set; }
    }
}