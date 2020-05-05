using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Medicaldrugstore.Models
{
    [Table("vwJunkProduct", Schema = "dbo")]
    public class JunkProductDetail
    {
        [Key]
        [Display(Name = "JunkProductId", ResourceType = typeof(Resources.rsJunkProduct))]
        public int JunkProductId { get; set; }

        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsJunkProduct))]
        public int? OrganizationId { get; set; }

        [Display(Name = "OrganizationCode", ResourceType = typeof(Resources.rsJunkProduct))]
        public string OrganizationCode { get; set; }

        [Display(Name = "OrganizationName", ResourceType = typeof(Resources.rsJunkProduct))]
        public string OrganizationName { get; set; }

        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsJunkProduct))]
        public int? ProductId { get; set; }
        [Display(Name = "ProductName", ResourceType = typeof(Resources.rsJunkProduct))]
        public string ProductName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "JunkProductDate", ResourceType = typeof(Resources.rsJunkProduct))]
        public DateTime? JunkProductDate { get; set; }

        //[Display(Name = "Ենթապահեստ")]
        [Display(Name = "StorageId", ResourceType = typeof(Resources.rsJunkProduct))]
        public int? StorageId { get; set; }
        [Display(Name = "StorageName", ResourceType = typeof(Resources.rsJunkProduct))]
        public string StorageName { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsJunkProduct))]
        public int Quantity { get; set; }
        
        [Display(Name = "ItemQuantity", ResourceType = typeof(Resources.rsJunkProduct))]
        public double? ItemQuantity { get; set; }

        [Display(Name = "UnitCost", ResourceType = typeof(Resources.rsJunkProduct))]
        public double? UnitCost { get; set; }

        //[Display(Name = "Ընդամենը արժեք")]
        [Display(Name = "TotalCost", ResourceType = typeof(Resources.rsJunkProduct))]
        public double? TotalCost { get; set; }

        [Display(Name = "JunkProductStatusId", ResourceType = typeof(Resources.rsJunkProduct))]
        public int? JunkProductStatusId { get; set; }

        [Display(Name = "JunkProductStatusName", ResourceType = typeof(Resources.rsJunkProduct))]
        public string JunkProductStatusName { get; set; }

        [Display(Name = "JunkBaseId", ResourceType = typeof(Resources.rsJunkProduct))]
        public int? JunkBaseId { get; set; }

        [Display(Name = "JunkBaseName", ResourceType = typeof(Resources.rsJunkProduct))]
        public string JunkBaseName { get; set; }

    }

}