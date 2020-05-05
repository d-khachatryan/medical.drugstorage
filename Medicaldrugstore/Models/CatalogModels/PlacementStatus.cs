using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class PlacementStatus
    {
        public int PlacementStatusId { get; set; }
        [Display(Name = "Status_Code", ResourceType = typeof(Resources.Resources))]
        public string PlacementStatusCode { get; set; }
        [Display(Name = "Status_Name", ResourceType = typeof(Resources.Resources))]
        public string PlacementStatusName { get; set; }

    }
}