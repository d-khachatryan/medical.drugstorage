using System.ComponentModel.DataAnnotations;

namespace Medicaldrugstore.Models
{
    public class Manufacturer
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManufacturerId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [RegularExpression(@"\d*[1-9]\d*", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "CodeMustBeNumber")]
        //[ManufacturerCodeRepetition(ErrorMessage = "The Manufacturer code is repeated")]
        [Display(Name = "Manufacturer_Code", ResourceType = typeof(Resources.Resources))]
        public string ManufacturerCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        //[ManufacturerNameRepetition(ErrorMessage = "The Manufacturer name is repeated")]
        [Display(Name = "Manufacturer_Name", ResourceType = typeof(Resources.Resources))]
        public string ManufacturerName { get; set; }
    }
}