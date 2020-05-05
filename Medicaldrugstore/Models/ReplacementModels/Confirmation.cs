using System;
using System.ComponentModel.DataAnnotations;


namespace Medicaldrugstore.Models
{
    public class Confirmation
    {
        [Key]
        [Required]
        public int ReplacementId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ConfirmDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConfirmDate { get; set; }
    }
}