using System;

namespace ForumDemo.Models
{
    // The join table for the Many User : Many Post like relationship
    public class UserLikesPosts
    {
        public int UserLikesPostsId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Relationship properties */
        public int UserId { get; set; }
        public User User { get; set; } // The User that liked the related post.
        public int PostId { get; set; }
        public Post Post { get; set; } // The post liked by related user.
    }
}