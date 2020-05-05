using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class Replacement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplacementId { get; set; }

        //[Display(Name = "Լրացման ա/թ")]
        [Display(Name = "ReplacementDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReplacementDate { get; set; }

        //[Display(Name = "Հաստատման ա/թ")]
        [Display(Name = "ConfirmDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ConfirmDate { get; set; }

        //[Display(Name = "Ստացման ա/թ")]
        [Display(Name = "ReceiveDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReceiveDate { get; set; }

        [UIHint("ConfirmOrganizationId")]
        [Display(Name = "ConfirmOrganizationId", ResourceType = typeof(Resources.rsReplacement))]
        public int? ConfirmOrganizationId { get; set; }

        [UIHint("SourceOrganizationId")]
        [Display(Name = "SourceOrganizationId", ResourceType = typeof(Resources.rsReplacement))]
        public int? SourceOrganizationId { get; set; }

        [UIHint("DestinationOrganizationId")]
        [Display(Name = "DestinationOrganizationId", ResourceType = typeof(Resources.rsReplacement))]
        public int? DestinationOrganizationId { get; set; }

        //[Display(Name = "Տրամադրման ա/թ")]
        [Display(Name = "ReadyDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReadyDate { get; set; }

        [Display(Name = "ReplacementSum", ResourceType = typeof(Resources.rsReplacement))]
        public double? ReplacementSum { get; set; }

        [Display(Name = "ReplacementStatusName", ResourceType = typeof(Resources.rsReplacement))]
        [UIHint("ReplacementStatusId")]
        public int? ReplacementStatusId { get; set; }

        //[ForeignKey("Transfer")]
        [Display(Name = "RetransferId", ResourceType = typeof(Resources.rsReplacement))]
        public int? RetransferId { get; set; }
        //public Transfer Transfer { get; set; }

        [UIHint("IsRetransfer")]
        //[Display(Name = "Կցված է")]
        [Display(Name = "IsRetransfer", ResourceType = typeof(Resources.rsReplacement))]
        public bool? IsRetransfer { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [UIHint("ReplacementBaseId")]
        [Display(Name = "ReplacementBaseId", ResourceType = typeof(Resources.rsReplacement))]
        public int? ReplacementBaseId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ReplacementBaseDate", ResourceType = typeof(Resources.rsReplacement))]
        public DateTime? ReplacementBaseDate { get; set; }

        [Display(Name = "ReplacementBaseText", ResourceType = typeof(Resources.rsReplacement))]
        public string ReplacementBaseText { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ProvisionDate", ResourceType = typeof(Resources.rsReplacement))]
        public DateTime? ProvisionDate { get; set; }

        ///////
        [Display(Name = "Ապրանք")]
        public virtual ICollection<ReplacementProduct> ReplacementProduct { get; set; }
    }
}