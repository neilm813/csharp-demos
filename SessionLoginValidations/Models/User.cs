using System.ComponentModel.DataAnnotations;

namespace SessionLoginValidations.Models
{
    public class User
    {
        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [MaxLength(20, ErrorMessage = "must fewer than 20 characters")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(8, ErrorMessage = "must be at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "must match Password")]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }
    }
}