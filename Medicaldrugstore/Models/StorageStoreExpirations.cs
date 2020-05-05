using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class StorageStoreExpirations
    {
        [Column(Order = 0), Key]
        [Display(Name = "Ապրանքի կոդ")]
        public int ProductId { get; set; }

        [Column(Order = 1), Key]
        public int OrganizationId { get; set; }
        [Display(Name = "Ապրանքի անվանում")]
        public string DrugName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ժամկետ")]
        public DateTime? ExpirationDate { get; set; }
        [Display(Name = "Սերիա")]
        public string Seria { get; set; }
        [Display(Name = "Քանակ")]
        public int? Quantity { get; set; }

        public double? ItemQuantity { get; set; }
        [Display(Name = "Արժեք")]
        public double? TotalCost { get; set; }
        [Display(Name = "Պահպանման օրերի թիվ")]
        public int? ExpirationDateCount { get; set; }
    }
}