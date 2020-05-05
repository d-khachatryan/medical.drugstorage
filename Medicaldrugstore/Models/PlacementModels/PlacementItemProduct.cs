using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class PlacementItemProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "PlacementItemProductId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementItemProductId { get; set; }

        [Display(Name = "PlacementItemId", ResourceType = typeof(Resources.rsPlacement))]
        public int? PlacementItemId { get; set; }

        [UIHint("ProductId")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        //[Display(Name = "Placement_Product", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsPlacement))]
        public int? ProductId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        //[Display(Name = "Placement_Quantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsPlacement))]
        public int? Quantity { get; set; }

        //[Display(Name = "Placement_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsPlacement))]
        public double? ItemQuantity { get; set; }

        [UIHint("StorageId")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        //[Display(Name = "Product_StorageId", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "StorageId", ResourceType = typeof(Resources.rsPlacement))]
        public int? StorageId { get; set; }

        //[Display(Name = "Product_UnitCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsPlacement))]
        public double? UnitCost { get; set; }

        //[Display(Name = "Product_TotalCost", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsPlacement))]
        public double? TotalCost { get; set; }
    }
}