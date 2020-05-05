using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class ReplacementStatus
    {
        public int ReplacementStatusId { get; set; }

        [Display(Name = "Status_Code", ResourceType = typeof(Resources.Resources))]
        public string ReplacementStatusCode { get; set; }

        [Display(Name = "Status_Name", ResourceType = typeof(Resources.Resources))]
        public string ReplacementStatusName { get; set; }

    }
}