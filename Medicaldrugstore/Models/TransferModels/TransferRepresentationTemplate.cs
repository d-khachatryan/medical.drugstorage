using System;
using System.ComponentModel.DataAnnotations;


namespace Medicaldrugstore.Models
{
    public class TransferRepresentationTemplate
    {
        [Key]
        public int TransferId { get; set; }
        
        [Display(Name = "TransferDate", ResourceType = typeof(Resources.rsTransfer))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public DateTime? TransferDate { get; set; }
        
    }

    
}