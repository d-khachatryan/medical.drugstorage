using System;
using System.ComponentModel.DataAnnotations;


namespace Medicaldrugstore.Models
{
    public class PlacementConfirmation
    {
        [Key]
        [Required]
        [Display(Name = "PlacementId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ConfirmDate", ResourceType = typeof(Resources.rsPlacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConfirmDate { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "CorrectionDate", ResourceType = typeof(Resources.rsPlacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CorrectionDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "PlacementStatusId", ResourceType = typeof(Resources.rsPlacement))]
        [UIHint("PlacementStatusId")]
        public int? PlacementStatusId { get; set; }
    }
}