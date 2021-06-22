using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
    public class TripLocationPlan // Many To Many 'Through' / 'Join' Table
    {
        [Key]
        public int TripLocationPlanId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* 
        Foreign Keys and Navigation Properties for Relationships
        The below navigation properties (not foreign keys) MUST be included with
        .Include, otherwise they will be null.
        */
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int LocationMediaId { get; set; }
        public LocationMedia LocationMedia { get; set; }
    }
}