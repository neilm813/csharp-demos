using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static TravelPlanner.CustomValidators;

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

        [Display(Name = "Trip Date")]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /**********************************************************************
        Relationship properties: foreign keys and navigation properties. 
        Navigation properties are null unless .Include is used. 
        "Object reference not set to an instance of an object"
        will be the error if accessed but not included. 
        **********************************************************************/
        // 1 user can create many destination media
        public int UserId { get; set; }
        public User CreatedBy { get; set; }

        // Many User : Many Trip
        public List<UserTripLike> Likes { get; set; }

        // Many Trip : Many DestinationMedia
        public List<TripDestination> TripDestinations { get; set; }
    }
}