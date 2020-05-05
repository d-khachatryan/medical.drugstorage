using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicaldrugstore.Models
{
    [Table("vwUsers", Schema = "dbo")]
    public class User
    {
        [Key]
        [Display(Name = "UserId", ResourceType = typeof(Resources.rsUser))]
        public string UserId { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(Resources.rsUser))]
        public string UserName { get; set; }
        
    }
}