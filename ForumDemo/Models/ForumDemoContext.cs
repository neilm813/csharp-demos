using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Models
{
    public class ForumDemoContext : DbContext
    {
        public ForumDemoContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLikesPosts> UserLikesPosts { get; set; }
    }

}