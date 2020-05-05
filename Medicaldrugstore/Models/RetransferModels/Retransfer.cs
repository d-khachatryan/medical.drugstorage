using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    public class Retransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RetransferId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [UIHint("BaseDocumentId")]
        [Display(Name = "BaseDocumentName", ResourceType = typeof(Resources.rsRetransfer))]
        public int? BaseDocumentId { get; set; }

        [Display(Name = "RetransferDate", ResourceType = typeof(Resources.rsRetransfer))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RetransferDate { get; set; }

        //[Display(Name = "DealInfo")]
        [Display(Name = "DealInfo", ResourceType = typeof(Resources.rsRetransfer))]
        public string DealInfo { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.rsRetransfer))]
        public string Comment { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderOrganizationName", ResourceType = typeof(Resources.rsRetransfer))]
        [UIHint("SenderOrganizationId")]
        public int? SenderOrganizationId { get; set; }

        //[Display(Name = "SenderTin")]
        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderTin", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderTin { get; set; }

        //[Display(Name = "SenderName")]
        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderName", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderName { get; set; }

        //[Display(Name = "SenderLocation")]
        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderLocation", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderLocation { get; set; }

        //[Display(Name = "SenderBankName")]
        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderBankName", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderBankName { get; set; }

        //[Display(Name = "SenderSupplyLocation")]
        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderSupplyLocation", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderSupplyLocation { get; set; }

        //[Display(Name = "SenderAccountNumber")]
        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderAccountNumber", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderAccountNumber { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderHeadName", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderHeadName { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderAccountantName", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderAccountantName { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderResponsibleName", ResourceType = typeof(Resources.rsRetransfer))]
        public string SenderResponsibleName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverOrganizationId", ResourceType = typeof(Resources.rsRetransfer))]
        [UIHint("ReceiverOrganizationId")]
        public int? ReceiverOrganizationId { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverTin", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverTin { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverName", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverName { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverLocation", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverLocation { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverBankName", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverBankName { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverSupplyLocation", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverSupplyLocation { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverAccountNumber", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverAccountNumber { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverHead", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverHeadName { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverAccountant", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverAccountantName { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "ReceiverResponsibleName", ResourceType = typeof(Resources.rsRetransfer))]
        public string ReceiverResponsibleName { get; set; }

        [Display(Name = "RetransferTotal", ResourceType = typeof(Resources.rsRetransfer))]
        public double? RetransferTotal { get; set; }

        [Display(Name = "RetransferStatusId", ResourceType = typeof(Resources.rsRetransfer))]
        [UIHint("RetransferStatusId")]
        public int? RetransferStatusId { get; set; }
    }

    
}