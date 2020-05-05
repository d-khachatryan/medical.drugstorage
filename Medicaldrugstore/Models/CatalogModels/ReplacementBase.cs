using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class ReplacementBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplacementBaseId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        [Display(Name = "Կոդ")]
        public string ReplacementBaseCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "Հիմք")]
        public string ReplacementBaseName { get; set; }

    }
}