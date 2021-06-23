using Microsoft.EntityFrameworkCore;

namespace TravelPlanner.Models
{
    public class TravelPlannerContext : DbContext
    {
        public TravelPlannerContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<DestinationMedia> DestinationMedias { get; set; }
        public DbSet<TripDestination> TripDestinations { get; set; }
        public DbSet<UserTripLike> UserTripLikes { get; set; }
    }

}