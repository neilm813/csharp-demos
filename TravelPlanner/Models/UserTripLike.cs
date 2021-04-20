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

        /**********************************************************************
        Relationship properties: foreign keys and navigation properties. 
        Navigation properties are null unless .Include is used. 
        "Object reference not set to an instance of an object"
        will be the error if accessed but not included. 
        **********************************************************************/
        public int UserId { get; set; }
        public User User { get; set; } // User who liked.
        public int TripId { get; set; }
        public Trip Trip { get; set; } // Trip that the User liked.
    }
}