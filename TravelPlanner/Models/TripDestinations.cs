using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class TripDestination // Many To Many 'Through' / 'Join' Table
    {
        [Key]
        public int TripDestinationId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Foreign Keys and Navigation Properties for Relationships
        The below navigation properties (not foreign keys) MUST be included with
        .Include, otherwise they will be null.
        */
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int DestinationMediaId { get; set; }
        public DestinationMedia LocationMedia { get; set; }
    }
}