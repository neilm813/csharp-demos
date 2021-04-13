using System.ComponentModel.DataAnnotations;

namespace SessionStory.Models
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
        public string Password { get; set; }
    }

}