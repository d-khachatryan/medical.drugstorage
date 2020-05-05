using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Medicaldrugstore.Models
{
    public class JunkProductTemplate
    {
        //[Display(Name = "Product_Code", ResourceType = typeof(Resources.Resources))]
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "JunkProductId", ResourceType = typeof(Resources.rsJunkProduct))]
        public int JunkProductId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "OrganizationId", ResourceType = typeof(Resources.rsJunkProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? OrganizationId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////        
        [Display(Name = "ProductId", ResourceType = typeof(Resources.rsJunkProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? ProductId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////
        [DataType(DataType.Date)]         
        [Display(Name = "JunkProductDate", ResourceType = typeof(Resources.rsJunkProduct))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public DateTime? JunkProductDate { get; set; }
        ////////////////////////////////////////////////////////////////////////////////
        [Display(Name = "StorageId", ResourceType = typeof(Resources.rsJunkProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? StorageId { get; set; }
        ////////////////////////////////////////////////////////////////////////////////
        [Display(Name = "Quantity", ResourceType = typeof(Resources.rsJunkProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Range(1, int.MaxValue, ErrorMessage = "Պետք է լինի դրական թիվ")]
        public int Quantity { get; set; }
        ////////////////////////////////////////////////////////////////////////////////   
        [Display(Name = "JunkBaseId", ResourceType = typeof(Resources.rsJunkProduct))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public int? JunkBaseId { get; set; }
    }
}