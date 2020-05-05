using System;
using System.ComponentModel.DataAnnotations;

namespace Medicaldrugstore.Models
{
    public class Provision
    {
        [Key]
        [Required]
        public int ReplacementId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ProvisionDate", ResourceType = typeof(Resources.rsReplacement))]
        public DateTime? ProvisionDate { get; set; }
    }
}