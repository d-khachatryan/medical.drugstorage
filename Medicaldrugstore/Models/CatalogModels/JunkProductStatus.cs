using System.ComponentModel.DataAnnotations;

namespace Medicaldrugstore.Models
{
    public class JunkProductStatus
    {
        public int JunkProductStatusId { get; set; }
        [Display(Name = "Status_Code", ResourceType = typeof(Resources.Resources))]
        public string JunkProductStatusCode { get; set; }
        [Display(Name = "Status_Name", ResourceType = typeof(Resources.Resources))]
        public string JunkProductStatusName { get; set; }

    }
}