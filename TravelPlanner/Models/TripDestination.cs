using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class TripDestination // Many Trip : Many DestinationMedia
    {
        [Key] // Primary Key
        public int TripDestinationId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Relationship & Navigation Properties */
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int DestinationMediaId { get; set; }
        public DestinationMedia DestinationMedia { get; set; }
    }
}