using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Medicaldrugstore.Models
{
    [Table("vwPlacementItemProductDetails", Schema = "dbo")]
    public class PlacementItemProductDetails
    {
        [Key]
        [Display(Name = "PlacementItemProductId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementItemProductId { get; set; }

        [Display(Name = "PlacementItemId", ResourceType = typeof(Resources.rsPlacement))]
        public int? PlacementItemId { get; set; }

        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsPlacement))]
        public int? ProductId { get; set; }

        [Display(Name = "ProductName", ResourceType = typeof(Resources.rsPlacement))]
        public string ProductName { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsPlacement))]
        public int Quantity { get; set; }

        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsPlacement))]
        public double? ItemQuantity { get; set; }

        [Display(Name = "StorageId", ResourceType = typeof(Resources.rsPlacement))]
        public int? StorageId { get; set; }

        [Display(Name = "StorageOrganizationName", ResourceType = typeof(Resources.rsPlacement))]
        public string StorageName { get; set; }

        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsPlacement))]
        public double? UnitCost { get; set; }

        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsPlacement))]
        public double? TotalCost { get; set; }
    }
}