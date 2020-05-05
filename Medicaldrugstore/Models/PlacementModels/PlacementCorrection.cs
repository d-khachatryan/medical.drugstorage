using System;
using System.ComponentModel.DataAnnotations;

namespace Medicaldrugstore.Models
{
    public class PlacementCorrection
    {
        [Key]
        [Required]
        [Display(Name = "PlacementId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementId { get; set; }

        [Display(Name = "PlacementDate", ResourceType = typeof(Resources.rsPlacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PlacementDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "CorrectionDate", ResourceType = typeof(Resources.rsPlacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CorrectionDate { get; set; }

    }
}