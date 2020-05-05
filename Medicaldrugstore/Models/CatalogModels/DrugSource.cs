using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class DrugSource
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrugSourceId { get; set; }

        public string DrugSourceName { get; set; }
    }
}