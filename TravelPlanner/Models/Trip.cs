using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(10, ErrorMessage = "must be at least 10 characters")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Foreign Keys and Navigation Properties for Relationships */

        // 1 User to Many Trips created
        public int UserId { get; set; }
        public User CreatedBy { get; set; }
    }
}