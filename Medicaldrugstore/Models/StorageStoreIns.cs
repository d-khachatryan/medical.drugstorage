using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class StorageStoreIns
    {
        [Column(Order = 0), Key]
        public int? OrganizationId { get; set; }

        [Column(Order = 1), Key]
        public int ProductId { get; set; }

        public string DrugName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ամսաթիվ")]
        public DateTime? ItemDate { get; set; }
        [Display(Name = "Քանակ")]
        public int? Quantity { get; set; }
        
        public double? ItemQuantity { get; set; }
        [Display(Name = "Արժեք")]
        public double? TotalCost { get; set; }
        [Display(Name = "Տեսակ")]
        public string TypeName { get; set; }
    }
}