using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    [Table("vwTransferPlacement", Schema = "dbo")]
    public class TransferPlacement
    {
        [Key]
        [Display(Name = "PlacementId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "PlacementDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? PlacementDate { get; set; }

        [Display(Name = "OrderOrganizationId", ResourceType = typeof(Resources.rsPlacement))]
        public int? OrderOrganizationId { get; set; }

        [Display(Name = "OrderOrganizationCode", ResourceType = typeof(Resources.rsPlacement))]
        public string OrderOrganizationCode { get; set; }

        [Display(Name = "OrderOrganizationName", ResourceType = typeof(Resources.rsPlacement))]
        public string OrderOrganizationName { get; set; }

        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsPlacement))]
        public int? OrganizationId { get; set; }

        [Display(Name = "OrganizationCode", ResourceType = typeof(Resources.rsPlacement))]
        public string OrganizationCode { get; set; }

        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsPlacement))]
        public string OrganizationName { get; set; }

        [Display(Name = "StorageOrganizationId", ResourceType = typeof(Resources.rsPlacement))]
        public int? StorageOrganizationId { get; set; }

        [Display(Name = "StorageOrganizationName", ResourceType = typeof(Resources.rsPlacement))]
        public string StorageOrganizationName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "CorrectionDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? CorrectionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ConfirmDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? ConfirmDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReceiveDate", ResourceType = typeof(Resources.rsPlacement))]
        public DateTime? ReceiveDate { get; set; }

        [Display(Name = "PlacementStatusId", ResourceType = typeof(Resources.rsPlacement))]
        public int? PlacementStatusId { get; set; }

        [Display(Name = "PlacementStatusName", ResourceType = typeof(Resources.rsPlacement))]
        public string PlacementStatusName { get; set; }

        [Display(Name = "TransferId", ResourceType = typeof(Resources.rsPlacement))]
        public int? TransferId { get; set; }

        [Display(Name = "IsTransfer", ResourceType = typeof(Resources.rsPlacement))]
        public bool? IsTransfer { get; set; }

        [Display(Name = "PlacementBaseId", ResourceType = typeof(Resources.rsPlacement))]
        public int? PlacementBaseId { get; set; }

        [Display(Name = "PlacementBaseName", ResourceType = typeof(Resources.rsPlacement))]
        public string PlacementBaseName { get; set; }

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
    }

}