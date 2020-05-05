using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class TransferStatus
    {
        public int TransferStatusId { get; set; }
        [Display(Name = "Status_Code", ResourceType = typeof(Resources.Resources))]
        public string TransferStatusCode { get; set; }
        [Display(Name = "Status_Name", ResourceType = typeof(Resources.Resources))]
        public string TransferStatusName { get; set; }

    }
}