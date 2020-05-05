using System;
using System.ComponentModel.DataAnnotations;

namespace Medicaldrugstore.Models
{

    public class UserItem
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(Resources.rsUser))]
        public string Id { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(Resources.rsUser))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string UserName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.rsUser))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "EmailValidation")]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.rsUser))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.rsUser))]
        [Required(ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "RequiredMessage")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.GeneralResources), ErrorMessageResourceName = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(Resources.rsUser))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.rsUser))]
        public string LastName { get; set; }

        [Display(Name = "PositionName", ResourceType = typeof(Resources.rsUser))]
        public string PositionName { get; set; }

    }
}
