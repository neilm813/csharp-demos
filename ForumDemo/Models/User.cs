using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class User
    {
        /* 
        The below prop is the primary key, [Key] is not needed if named with
        pattern: ModelNameId
        */
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}