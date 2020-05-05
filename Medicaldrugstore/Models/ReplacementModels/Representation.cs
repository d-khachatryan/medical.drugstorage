using System;
using System.ComponentModel.DataAnnotations;


namespace Medicaldrugstore.Models
{
    public class Representation
    {
        [Key]
        [Required]
        public int ReplacementId { get; set; }

        [Display(Name = "ReplacementDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReplacementDate { get; set; }
    }
}