using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class CurrentStoreStatus
    {
        [Key]
        public int Id { get; set; }

        public int CurrentStoreCount { get; set; }

        public int CurrentRequestCount { get; set; }
    }
}