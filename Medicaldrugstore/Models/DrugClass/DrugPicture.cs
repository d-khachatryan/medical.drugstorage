using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    public class DrugPicture
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity )]
        [Display(Name = "FileId", ResourceType = typeof(Resources.rsDrugClass))]
        public int FileId { get; set; }

        [StringLength(255)]
        [Display(Name = "FileName", ResourceType = typeof(Resources.rsDrugClass))]
        public string FileName { get; set; }

        [StringLength(100)]
        [Display(Name = "ContentType", ResourceType = typeof(Resources.rsDrugClass))]
        public string ContentType { get; set; }

        [Display(Name = "Content", ResourceType = typeof(Resources.rsDrugClass))]
        public byte[] Content { get; set; }

        [Display(Name = "FileType", ResourceType = typeof(Resources.rsDrugClass))]
        public FileType FileType { get; set; }

        [Display(Name = "DrugId", ResourceType = typeof(Resources.rsDrugClass))]
        public int DrugId { get; set; }

        public virtual Drug Drug { get; set; }
    }
}