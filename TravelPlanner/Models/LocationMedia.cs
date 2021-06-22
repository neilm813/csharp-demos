using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class LocationMedia
    {
        public int LocationMediaId { get; set; }
        
        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "is required.")]
        public string Src { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Media Type")]
        public string MediaType { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(4, ErrorMessage = "must be between 4-255 characters.")]
        [MaxLength(255, ErrorMessage = "must be between 4-255 characters.")]
        public string ShortDescription { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Foreign Keys and Navigation Properties for Relationships */

        // 1 User to Many LocationMedia created
        public int UserId { get; set; }
        public User CreatedBy { get; set; }
    }
}