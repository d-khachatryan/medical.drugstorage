using System;
using System.ComponentModel.DataAnnotations;

namespace Medicaldrugstore.Models
{
    public class PlacementReception
    {
        [Key]
        [Required]
        [Display(Name = "PlacementId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiveDate", ResourceType = typeof(Resources.rsPlacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReceiveDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Resources.rsPlacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

    }
}