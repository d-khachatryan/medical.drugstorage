using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    public class MessageBox
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string SenderUserId { get; set; }

        [Display(Name = "MessageBox_Sender", ResourceType = typeof(Resources.Resources))]
        public string SenderUserName { get; set; }

        [UIHint("RecipientUserId")]
        [Display(Name = "MessageBox_Recipient", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string RecipientUserId { get; set; }

        [Display(Name = "MessageBox_Recipient", ResourceType = typeof(Resources.Resources))]
        public string RecipientUserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "MessageBox_Date", ResourceType = typeof(Resources.Resources))]
        public DateTime? MessageDate { get; set; }

        [Display(Name = "MessageBox_MessageTitle", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string MessageTitle { get; set; }

        //[DataType(DataType.MultilineText)]
        [DataType(DataType.Html)]
        [Display(Name = "MessageBox_MessageContent", ResourceType = typeof(Resources.Resources))]
        public string MessageContent { get; set; }

        public int? MessageStatus { get; set; }
    }
}