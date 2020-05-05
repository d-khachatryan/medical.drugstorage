using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    [Table("vwPlacementItemDetails", Schema = "dbo")]
    public class PlacementItemDetails
    {
        [Key]
        [Display(Name = "PlacementItemId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementItemId { get; set; }

        [Display(Name = "PlacementId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementId { get; set; }

        [Display(Name = "DrugClassId", ResourceType = typeof(Resources.rsPlacement))]
        public int DrugClassId { get; set; }

        [Display(Name = "DrugClassName", ResourceType = typeof(Resources.rsPlacement))]
        public string DrugClassName { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsPlacement))]
        public int? Quantity { get; set; }

        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsPlacement))]
        public double? ItemQuantity { get; set; }

        //[Display(Name = "PlacementItemProductDetails", ResourceType = typeof(Resources.PlacementItemResources))]
        public ICollection<PlacementItemProductDetails> PlacementItemProductDetails { get; set; }

    }
}