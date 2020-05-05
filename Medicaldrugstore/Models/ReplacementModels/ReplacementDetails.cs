using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    [Table("vwReplacementDetails", Schema = "dbo")]
    public class ReplacementDetails
    {
        [Key]
        public int ReplacementId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReplacementDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        public DateTime? ReplacementDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ConfirmDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        public DateTime? ConfirmDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReadyDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        public DateTime? ReadyDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ProvisionDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        public DateTime? ProvisionDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReceiveDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        public DateTime? ReceiveDate { get; set; }

        [Display(Name = "SourceOrganizationId", ResourceType = typeof(Resources.rsReplacement))]
        public int? SourceOrganizationId { get; set; }

        [Display(Name = "SourceOrganizationCode", ResourceType = typeof(Resources.rsReplacement))]
        public string SourceOrganizationCode { get; set; }

        [Display(Name = "SourceOrganizationName", ResourceType = typeof(Resources.rsReplacement))]
        public string SourceOrganizationName { get; set; }


        [Display(Name = "ConfirmOrganizationId", ResourceType = typeof(Resources.rsReplacement))]
        public int? ConfirmOrganizationId { get; set; }

        [Display(Name = "ConfirmOrganizationCode", ResourceType = typeof(Resources.rsReplacement))]
        public string ConfirmOrganizationCode { get; set; }

        [Display(Name = "ConfirmOrganizationName", ResourceType = typeof(Resources.rsReplacement))]
        public string ConfirmOrganizationName { get; set; }

        [Display(Name = "DestinationOrganizationId", ResourceType = typeof(Resources.rsReplacement))]
        public int? DestinationOrganizationId { get; set; }

        [Display(Name = "DestinationOrganizationCode", ResourceType = typeof(Resources.rsReplacement))]
        public string DestinationOrganizationCode { get; set; }

        [Display(Name = "DestinationOrganizationName", ResourceType = typeof(Resources.rsReplacement))]
        public string DestinationOrganizationName { get; set; }

        [Display(Name = "ReplacementSum", ResourceType = typeof(Resources.rsReplacement))]
        public double? ReplacementSum { get; set; }

        [Display(Name = "ReplacementStatusId", ResourceType = typeof(Resources.rsReplacement))]
        public int? ReplacementStatusId { get; set; }

        [Display(Name = "ReplacementStatusCode", ResourceType = typeof(Resources.rsReplacement))]
        public string ReplacementStatusCode { get; set; }

        [Display(Name = "ReplacementStatusName", ResourceType = typeof(Resources.rsReplacement))]
        public string ReplacementStatusName { get; set; }

        [Display(Name = "IsTransfer", ResourceType = typeof(Resources.rsReplacement))]
        public bool? IsRetransfer { get; set; }

        [Display(Name = "RetransferId", ResourceType = typeof(Resources.rsReplacement))]
        public int? RetransferId { get; set; }

        [Display(Name = "RetransferDate", ResourceType = typeof(Resources.rsReplacement))]
        public DateTime? RetransferDate { get; set; }




        //localization required
        [Display(Name = "ReplacementBaseId", ResourceType = typeof(Resources.rsReplacement))]
        public int? ReplacementBaseId { get; set; }

        [Display(Name = "ReplacementBaseName", ResourceType = typeof(Resources.rsReplacement))]
        public string ReplacementBaseName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReplacementBaseDate", ResourceType = typeof(Resources.rsReplacement))]
        public DateTime? ReplacementBaseDate { get; set; }

        [Display(Name = "ReplacementBaseText", ResourceType = typeof(Resources.rsReplacement))]
        public string ReplacementBaseText { get; set; }
        //localization required
    }
}