using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    public class TransferTemplate
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransferId { get; set; }
        
        [Display(Name = "BaseDocumentName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? BaseDocumentId { get; set; }
        
        [Display(Name = "TransferDate", ResourceType = typeof(Resources.rsTransfer))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TransferDate { get; set; }

        [Display(Name = "DealInfo", ResourceType = typeof(Resources.rsTransfer))]
        public string DealInfo { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.rsTransfer))]
        public string Comment { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderOrganizationName", ResourceType = typeof(Resources.rsTransfer))]
        public int? SenderOrganizationId { get; set; }

        //[Display(Name = "SenderTin")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderTin", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderTin { get; set; }

        //[Display(Name = "SenderName")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderName", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderName { get; set; }

        //[Display(Name = "SenderLocation")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderLocation", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderLocation { get; set; }

        //[Display(Name = "SenderBankName")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderBankName", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderBankName { get; set; }

        //[Display(Name = "SenderSupplyLocation")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderSupplyLocation", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderSupplyLocation { get; set; }

        //[Display(Name = "SenderAccountNumber")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Display(Name = "SenderAccountNumber", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderAccountNumber { get; set; }

        [Display(Name = "SenderHeadName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string SenderHeadName { get; set; }

        [Display(Name = "SenderAccountantName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string SenderAccountantName { get; set; }

        [Display(Name = "SenderResponsibleName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string SenderResponsibleName { get; set; }

        [Display(Name = "ReceiverOrganizationName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? ReceiverOrganizationId { get; set; }

        //[Display(Name = "ReceiverTin")]
        [Display(Name = "ReceiverTin", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverTin { get; set; }

        //[Display(Name = "ReceiverName")]
        [Display(Name = "ReceiverName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverName { get; set; }

        //[Display(Name = "ReceiverLocation")]
        [Display(Name = "ReceiverLocation", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverLocation { get; set; }

        //[Display(Name = "ReceiverBankName")]
        [Display(Name = "ReceiverBankName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverBankName { get; set; }

        //[Display(Name = "ReceiverSupplyLocation")]
        [Display(Name = "ReceiverSupplyLocation", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverSupplyLocation { get; set; }

        //[Display(Name = "ReceiverAccountNumber")]
        [Display(Name = "ReceiverAccountNumber", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverAccountNumber { get; set; }

        [Display(Name = "ReceiverHeadName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverHeadName { get; set; }

        [Display(Name = "ReceiverAccountantName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverAccountantName { get; set; }

        [Display(Name = "ReceiverResponsibleName", ResourceType = typeof(Resources.rsTransfer))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string ReceiverResponsibleName { get; set; }

        [Display(Name = "TransferSum", ResourceType = typeof(Resources.rsTransfer))]
        public string TransferSum { get; set; }

        [Display(Name = "TransferTextSum", ResourceType = typeof(Resources.rsTransfer))]
        public string TransferTextSum { get; set; }

        [Display(Name = "TransferTotal", ResourceType = typeof(Resources.rsTransfer))]
        public double? TransferTotal { get; set; }

        //[Display(Name = "Կարգավիճակ")]
        [Display(Name = "TransferStatusId", ResourceType = typeof(Resources.rsTransfer))]
        public int? TransferStatusId { get; set; }
    }

    
}