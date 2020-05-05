using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class ReplacementProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplacementProductId { get; set; }
        [ForeignKey("Replacement")]
        public int? ReplacementId { get; set; }
        public Replacement Replacement { get; set; }

        [UIHint("ProductId")]
        //[Required(ErrorMessage = "Դաշտը լրացված չէ")]
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsReplacement))]
        public int? ProductId { get; set; }

        //[Required(ErrorMessage = "Դաշտը լրացված չէ")]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsReplacement))]
        public int? Quantity { get; set; }

        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsReplacement))]
        public double? ItemQuantity { get; set; }

        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsReplacement))]
        public double? UnitCost { get; set; }

        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsReplacement))]
        public double? TotalCost { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }
    }
}