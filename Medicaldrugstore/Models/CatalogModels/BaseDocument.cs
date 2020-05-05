using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class BaseDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BaseDocumentId { get; set; }

        public string BaseDocumentCode { get; set; }

        public string BaseDocumentName { get; set; }

    }
}