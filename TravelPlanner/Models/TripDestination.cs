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

        /**********************************************************************
        Relationship properties: foreign keys and navigation properties. 
        Navigation properties are null unless .Include is used. 
        "Object reference not set to an instance of an object"
        will be the error if accessed but not included. 
        **********************************************************************/
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int DestinationMediaId { get; set; }
        public DestinationMedia DestinationMedia { get; set; }
    }
}