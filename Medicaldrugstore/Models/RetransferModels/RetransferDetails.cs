using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    [Table("vwRetransferDetails", Schema = "dbo")]
    public class RetransferDetails
    {
        [Key]

        public int RetransferId { get; set; }

        [Display(Name = "RetransferDate", ResourceType = typeof(Resources.rsReplacement))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RetransferDate { get; set; }

        [UIHint("BaseDocumentId")]
        [Display(Name = "BaseDocumentId", ResourceType = typeof(Resources.rsReplacement))]
        public int? BaseDocumentId { get; set; }

        [Display(Name = "BaseDocumentName", ResourceType = typeof(Resources.rsReplacement))]
        public string BaseDocumentName { get; set; }

        [Display(Name = "SenderOrganizationId", ResourceType = typeof(Resources.rsReplacement))]
        [UIHint("SenderOrganizationId")]
        public int? SenderOrganizationId { get; set; }

        [Display(Name = "SenderOrganizationName", ResourceType = typeof(Resources.rsReplacement))]
        public string SenderOrganizationName { get; set; }

        [Display(Name = "SenderLocation", ResourceType = typeof(Resources.rsReplacement))]
        public string SenderLocation { get; set; }

        [Display(Name = "SenderBankName", ResourceType = typeof(Resources.rsReplacement))]
        public string SenderBankName { get; set; }

        [Display(Name = "SenderTin", ResourceType = typeof(Resources.rsReplacement))]
        public string SenderTin { get; set; }

        [Display(Name = "SenderHeadName", ResourceType = typeof(Resources.rsReplacement))]
        public string SenderHeadName { get; set; }

        [Display(Name = "SenderAccountantName", ResourceType = typeof(Resources.rsReplacement))]
        public string SenderAccountantName { get; set; }

        [Display(Name = "SenderResponsibleName", ResourceType = typeof(Resources.rsReplacement))]
        public string SenderResponsibleName { get; set; }

        [Display(Name = "ReceiverOrganizationId", ResourceType = typeof(Resources.rsReplacement))]
        [UIHint("ReceiverOrganizationId")]
        public int? ReceiverOrganizationId { get; set; }

        [Display(Name = "ReceiverOrganizationName", ResourceType = typeof(Resources.rsReplacement))]
        public string ReceiverOrganizationName { get; set; }

        [Display(Name = "ReceiverLocation", ResourceType = typeof(Resources.rsReplacement))]
        public string ReceiverLocation { get; set; }

        [Display(Name = "ReceiverBankName", ResourceType = typeof(Resources.rsReplacement))]
        public string ReceiverBankName { get; set; }

        [Display(Name = "ReceiverTin", ResourceType = typeof(Resources.rsReplacement))]
        public string ReceiverTin { get; set; }

        [Display(Name = "ReceiverHead", ResourceType = typeof(Resources.rsReplacement))]
        public string ReceiverHead { get; set; }

        [Display(Name = "ReceiverAccountant", ResourceType = typeof(Resources.rsReplacement))]
        public string ReceiverAccountant { get; set; }

        [Display(Name = "ReceiverResponsibleName", ResourceType = typeof(Resources.rsReplacement))]
        public string ReceiverResponsibleName { get; set; }

        [Display(Name = "RetransferTotal", ResourceType = typeof(Resources.rsReplacement))]
        public double? RetransferTotal { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resources.rsReplacement))]
        public string Comment { get; set; }

















        //public int TransferId { get; set; }

        //[UIHint("StoreId")]
        //[Display(Name = "Transfer_Store", ResourceType = typeof(Resources.rsReplacement))]        
        //public int StoreId { get; set; }
        //[Display(Name = "Transfer_StoreName", ResourceType = typeof(Resources.rsReplacement))]
        //public string StoreName { get; set; }
        //[Display(Name = "Transfer_Location", ResourceType = typeof(Resources.rsReplacement))]
        //public string StoreLocation { get; set; }
        //[Display(Name = "Transfer_RegistrationNumber", ResourceType = typeof(Resources.rsReplacement))]
        //public string RegistrationNumber { get; set; }
        //[Display(Name = "Transfer_BankName", ResourceType = typeof(Resources.rsReplacement))]
        //public string BankName { get; set; }
        //[Display(Name = "Transfer_TinNumber", ResourceType = typeof(Resources.rsReplacement))]
        //public string TinNumber { get; set; }

        //[UIHint("OrganizationId")]
        //[Display(Name = "Transfer_Organization", ResourceType = typeof(Resources.rsReplacement))]        
        //public int OrganizationId { get; set; }
        //[Display(Name = "Transfer_Organization", ResourceType = typeof(Resources.rsReplacement))]
        //public string OrganizationName { get; set; }
        //[Display(Name = "Transfer_OrganizationLocation", ResourceType = typeof(Resources.rsReplacement))]
        //public string OrganizationLocation { get; set; }
        //[Display(Name = "Transfer_OrganizationRegistrationNumber", ResourceType = typeof(Resources.rsReplacement))]
        //public string OrganizationRegistrationNumber { get; set; }
        //[Display(Name = "Transfer_OrganizationBankName", ResourceType = typeof(Resources.rsReplacement))]
        //public string OrganizationBankName { get; set; }
        //[Display(Name = "Transfer_OrganizationTinNumber", ResourceType = typeof(Resources.rsReplacement))]
        //public string OrganizationTinNumber { get; set; }

        //[Display(Name = "Transfer_Date", ResourceType = typeof(Resources.rsReplacement))]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime? TransferDate { get; set; }

        //[Display(Name = "Transfer_SenderHead", ResourceType = typeof(Resources.rsReplacement))]
        //public string SenderHeadName { get; set; }

        //[Display(Name = "Transfer_SenderAccountant", ResourceType = typeof(Resources.rsReplacement))]
        //public string SenderAccountantName { get; set; }

        //[Display(Name = "Transfer_SenderResponsible", ResourceType = typeof(Resources.rsReplacement))]
        //public string SenderResponsibleName { get; set; }

        //[Display(Name = "Transfer_ReceiverHead", ResourceType = typeof(Resources.rsReplacement))]
        //public string ReceiverHeadName { get; set; }

        //[Display(Name = "Transfer_ReceiverAccountant", ResourceType = typeof(Resources.rsReplacement))]
        //public string ReceiverAccountantName { get; set; }

        //[Display(Name = "Transfer_ReceiverResponsible", ResourceType = typeof(Resources.rsReplacement))]
        //public string ReceiverResponsibleName { get; set; }

        //[Display(Name = "Transfer_Sum", ResourceType = typeof(Resources.rsReplacement))]
        //public string TransferSum { get; set; }

        //[Display(Name = "Transfer_TextSum", ResourceType = typeof(Resources.rsReplacement))]
        //public string TransferTextSum { get; set; }

        //[Display(Name = "Transfer_Total", ResourceType = typeof(Resources.rsReplacement))]
        //public double? TransferTotal { get; set; }
        //[Display(Name = "Transfer_Comment", ResourceType = typeof(Resources.rsReplacement))]
        //public string Comment { get; set; }

        //[UIHint("BaseDocumentId")]
        //[Display(Name = "Transfer_BaseDoc", ResourceType = typeof(Resources.rsReplacement))]
        //public int? BaseDocumentId { get; set; }
        //[Display(Name = "Transfer_BaseDoc", ResourceType = typeof(Resources.rsReplacement))]
        //public string BaseDocumentName { get; set; }


    }
}