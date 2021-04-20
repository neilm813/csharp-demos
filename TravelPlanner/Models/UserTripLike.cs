using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class UserTripLike // Many Trip : Many User
    {
        [Key] // Primary Key
        public int UserTripLikeId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Relationship & Navigation Properties */
        public int UserId { get; set; }
        // Only available if using .Include
        public User User { get; set; } // User who liked.
        public int TripId { get; set; }
        // Only available if using .Include
        public Trip Trip { get; set; } // Trip that the User liked.
    }
}