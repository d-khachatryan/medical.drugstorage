using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class ReplacementProductStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplacementProductStorageId { get; set; }
        public int? ReplacementProductId { get; set; }

        [UIHint("StorageId")]
        [Display(Name = "StorageId", ResourceType = typeof(Resources.rsReplacement))]
        public int? StorageId { get; set; }
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsReplacement))]
        public int? ProductId { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsReplacement))]
        public int? Quantity { get; set; }

        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsReplacement))]
        public double? ItemQuantity { get; set; }

        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsReplacement))]
        public double? UnitCost { get; set; }

        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsReplacement))]
        public double? TotalCost { get; set; }
    }
}