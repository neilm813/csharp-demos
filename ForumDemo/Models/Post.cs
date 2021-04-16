using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class Post
    {
        [Key] // Primary Key
        public int PostId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
        [MaxLength(45, ErrorMessage = "must not be more than 45 characters.")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be more than 2 characters.")]
        public string Body { get; set; }

        [Display(Name = "Image Url")]
        public string ImgUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Relationship Properties */
        // A post can be created by only 1 user
        // 1 User : many Post
        // Foreign Key (FK)
        public int UserId { get; set; }
        // Navigation Prop
        public User Author { get; set; }
    }
}