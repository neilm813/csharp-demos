using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(10, ErrorMessage = "must be at least 10 characters")]
        public string Description { get; set; }

        [Display(Name = "Trip Date")]
        [DataType(DataType.Date)] // Just Date, no Time.
        public DateTime? Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Foreign Keys and Navigation Properties for Relationships
        The below navigation properties (not foreign keys) MUST be included with
        .Include, otherwise they will be null.
        */

        // 1 User : Many Trips created
        public int UserId { get; set; }
        public User CreatedBy { get; set; }

        // Many Trip : Many LocationMedia
        public List<TripLocationPlan> TripLocationPlans { get; set; }

        // Many User : Many Trip for Likes
        public List<UserTripLike> UserTripLikes { get; set; }
    }
}