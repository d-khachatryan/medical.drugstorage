using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    public class Placement
    {        
        [Key]
        [Display(Name = "PlacementId", ResourceType = typeof(Resources.rsPlacement))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlacementId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "PlacementDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? PlacementDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "OrderOrganizationId", ResourceType = typeof(Resources.rsPlacement))]
        public int? OrderOrganizationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsPlacement))]        
        [UIHint("OrganizationId")]
        public int? OrganizationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "StorageOrganizationId", ResourceType = typeof(Resources.rsPlacement))]
        public int? StorageOrganizationId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "CorrectionDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? CorrectionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ConfirmDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? ConfirmDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReceiveDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? ReceiveDate { get; set; }
        
        [Display(Name = "PlacementStatusId", ResourceType = typeof(Resources.rsPlacement))]
        [UIHint("PlacementStatusId")]
        public int? PlacementStatusId { get; set; }

        [Display(Name = "TransferId", ResourceType = typeof(Resources.rsPlacement))]
        public int? TransferId { get; set; }

        [UIHint("IsTransfer")]
        [Display(Name = "IsTransfer", ResourceType = typeof(Resources.rsPlacement))]
        public bool? IsTransfer { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [UIHint("PlacementBaseId")]
        [Display(Name = "PlacementBaseId", ResourceType = typeof(Resources.rsPlacement))]
        public int? PlacementBaseId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "PlacementBaseDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? PlacementBaseDate { get; set; }

        [Display(Name = "PlacementBaseText", ResourceType = typeof(Resources.rsPlacement))]
        public string PlacementBaseText { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReadyDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? ReadyDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Ապրանք")]
        public virtual ICollection<PlacementItem> PlacementItems { get; set; }

    }    
}