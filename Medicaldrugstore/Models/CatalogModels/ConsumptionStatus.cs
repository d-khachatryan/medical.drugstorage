using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class ConsumptionStatus
    {
        public int ConsumptionStatusId { get; set; }

        [Display(Name = "Status_Code", ResourceType = typeof(Resources.Resources))]
        public string ConsumptionStatusCode { get; set; }

        [Display(Name = "Status_Name", ResourceType = typeof(Resources.Resources))]
        public string ConsumptionStatusName { get; set; }

    }
}