using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{

    public class OrganizationStore
    {
        [Column(Order = 0), Key]
        [Display(Name = "Ապրանքի կոդ")]
        public int ProductId { get; set; }

        [Column(Order = 1), Key]
        [Display(Name = "StorageStore_OrganizationName", ResourceType = typeof(Resources.Resources))]
        public int OrganizationId { get; set; }
        [Display(Name = "Ապրանքի անվանում")]
        public string DrugName { get; set; }
        [Display(Name = "Սկզբնական մնացորդ (քանակ)")]
        public int? InitialQuantity { get; set; }

        public double? InitialItemQuantity { get; set; }
        [Display(Name = "Սկզբնական մնացորդ (արժեք)")]
        public double? InitialTotalCost { get; set; }
        [Display(Name = "Վերջնական մնացորդ (քանակ)")]
        public int? TerminalQuantity { get; set; }

        public double? TerminalItemQuantity { get; set; }
        [Display(Name = "Վերջնական մնացորդ (արժեք)")]
        public double? TerminalTotalCost { get; set; }
        [Display(Name = "Մուտքեր (քանակ)")]
        public int? InQuantity { get; set; }

        public double? InItemQuantity { get; set; }
        [Display(Name = "Մուտքեր (արժեք)")]
        public double? InTotalCost { get; set; }
        [Display(Name = "Ելքեր (քանակ)")]
        public int? OutQuantity { get; set; }

        public double? OutItemQuantity { get; set; }
        [Display(Name = "Ելքեր (արժեք)")]
        public double? OutTotalCost { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? TerminationDate { get; set; }

    }
}