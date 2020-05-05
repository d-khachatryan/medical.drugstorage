using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Medicaldrugstore.Models
{
    public class PlacementItem
    {

        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Display(Name = "General_NN", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "PlacementItemId", ResourceType = typeof(Resources.rsPlacement))]
        public int PlacementItemId { get; set; }

        [ForeignKey("Placement")]
        [Display(Name = "PlacementId", ResourceType = typeof(Resources.rsPlacement))]
        public int? PlacementId { get; set; }
        public Placement Placement { get; set; }

        [UIHint("DrugClassId")]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        // [Display(Name = "Placement_DrugId", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "DrugClassId", ResourceType = typeof(Resources.rsPlacement))]
        public int? DrugClassId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        // [Display(Name = "Placement_Quantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsPlacement))]
        public int? Quantity { get; set; }

        //[Display(Name = "Placement_ItemQuantity", ResourceType = typeof(Resources.Resources))]
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsPlacement))]
        public double? ItemQuantity { get; set; }

        [NotMapped]
        public int? RecordStatus { get; set; }

    }
}