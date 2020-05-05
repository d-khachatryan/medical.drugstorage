using System.ComponentModel.DataAnnotations;


namespace Medicaldrugstore.Models
{
    public class RetransferStatus
    {
        public int RetransferStatusId { get; set; }
        [Display(Name = "Status_Code", ResourceType = typeof(Resources.Resources))]
        public string RetransferStatusCode { get; set; }
        [Display(Name = "Status_Name", ResourceType = typeof(Resources.Resources))]
        public string RetransferStatusName { get; set; }

    }
}