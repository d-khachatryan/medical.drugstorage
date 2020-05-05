using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    [Table("vwTransfer", Schema = "dbo")]
    public class TransferDetail
    {
        [Key]
        public int TransferId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "BaseDocumentId", ResourceType = typeof(Resources.rsTransfer))]
        public int? BaseDocumentId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////    

        [Display(Name = "BaseDocumentName", ResourceType = typeof(Resources.rsTransfer))]
        public string BaseDocumentName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "TransferDate", ResourceType = typeof(Resources.rsTransfer))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TransferDate { get; set; }
        ////////////////////////////////////////////////////////////////////////////////    

        [Display(Name = "DealInfo", ResourceType = typeof(Resources.rsTransfer))]
        public string DealInfo { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "Comment", ResourceType = typeof(Resources.rsTransfer))]
        public string Comment { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "SenderOrganizationId", ResourceType = typeof(Resources.rsTransfer))]
        public int? SenderOrganizationId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "SenderTin", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderTin { get; set; }
        ////////////////////////////////////////////////////////////////////////////////  

        [Display(Name = "SenderName", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "SenderLocation", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderLocation { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "SenderBankName", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderBankName { get; set; }
        //////////////////////////////////////////////////////////////////////////////// 

        [Display(Name = "SenderSupplyLocation", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderSupplyLocation { get; set; }
        ////////////////////////////////////////////////////////////////////////////////  

        [Display(Name = "SenderAccountNumber", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderAccountNumber { get; set; }
        ////////////////////////////////////////////////////////////////////////////////  

        [Display(Name = "SenderHeadName", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderHeadName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "SenderAccountantName", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderAccountantName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////  

        [Display(Name = "SenderResponsibleName", ResourceType = typeof(Resources.rsTransfer))]
        public string SenderResponsibleName { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "ReceiverOrganizationId", ResourceType = typeof(Resources.rsTransfer))]
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

        [Display(Name = "ReceiverSupplyLocation", ResourceType = typeof(Resources.rsTransfer))]
        public string ReceiverSupplyLocation { get; set; }

        [Display(Name = "ReceiverAccountNumber", ResourceType = typeof(Resources.rsTransfer))]
        public string ReceiverAccountNumber { get; set; }

        [Display(Name = "ReceiverHeadName", ResourceType = typeof(Resources.rsTransfer))]
        public string ReceiverHeadName { get; set; }

        [Display(Name = "ReceiverAccountantName", ResourceType = typeof(Resources.rsTransfer))]
        public string ReceiverAccountantName { get; set; }

        [Display(Name = "ReceiverResponsibleName", ResourceType = typeof(Resources.rsTransfer))]
        public string ReceiverResponsibleName { get; set; }

        [Display(Name = "TransferSum", ResourceType = typeof(Resources.rsTransfer))]
        public string TransferSum { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "TransferTextSum", ResourceType = typeof(Resources.rsTransfer))]
        public string TransferTextSum { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "TransferTotal", ResourceType = typeof(Resources.rsTransfer))]
        public double? TransferTotal { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        

        [Display(Name = "TransferStatusId", ResourceType = typeof(Resources.rsTransfer))]
        public int? TransferStatusId { get; set; }

        [Display(Name = "TransferStatusName", ResourceType = typeof(Resources.rsTransfer))]
        public string TransferStatusName { get; set; }

    }
}