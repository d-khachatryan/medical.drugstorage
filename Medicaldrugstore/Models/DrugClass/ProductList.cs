using System;
using System.ComponentModel.DataAnnotations;

namespace Medicaldrugstore.Models
{
    public class ProductList
    {
        [Key]
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsDrugClass))]     
        public int ProductId { get; set; }

        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsDrugClass))]
        public string ProductName { get; set; }
    }
}