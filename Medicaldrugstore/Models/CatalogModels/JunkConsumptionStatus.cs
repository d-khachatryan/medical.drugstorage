using System.ComponentModel.DataAnnotations;

namespace Medicaldrugstore.Models
{
    public class JunkConsumptionStatus
    {
        public int JunkConsumptionStatusId { get; set; }
        [Display(Name = "Status_Code", ResourceType = typeof(Resources.Resources))]
        public string JunkConsumptionStatusCode { get; set; }
        [Display(Name = "Status_Name", ResourceType = typeof(Resources.Resources))]
        public string JunkConsumptionStatusName { get; set; }

    }
}