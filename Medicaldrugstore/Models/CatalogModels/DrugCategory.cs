using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class DrugCategory
    {
        public int DrugCategoryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        [Display(Name = "DrugCategory_Code", ResourceType = typeof(Resources.Resources))]
        public string DrugCategoryCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "DrugCategory_Name", ResourceType = typeof(Resources.Resources))]
        public string DrugCategoryName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "DrugCategory_UnitItemQuantity", ResourceType = typeof(Resources.Resources))]
        public int? UnitItemQuantity { get; set; }
    }
}