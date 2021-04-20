using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class Trip
    {

        [Key] // Primary Key (PK)
        public int TripId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(10, ErrorMessage = "must be at least 10 characters.")]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Relationship & Navigation Properties */
        // Foreign Key and Navigation Property for 1 User : M DestinationMedia
        // 1 user can create many destination media
        public int UserId { get; set; }
        public User CreatedBy { get; set; }

        // Many User : Many Trip
        public List<UserTripLike> Likes { get; set; }

        // Many Trip : Many DestinationMedia
        public List<TripDestination> TripDestinations { get; set; }
    }
}