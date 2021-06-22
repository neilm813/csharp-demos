using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class UserTripLike // Many : Many 'Through' / 'Join' Table
    {
        [Key]
        public int UserTripLikeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Foreign Keys and Navigation Properties for Relationships
        The below navigation properties (not foreign keys) MUST be included with
        .Include, otherwise they will be null.
        */
        public int UserId { get; set; }
        public User User { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}