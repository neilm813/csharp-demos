using System;
using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models
{
    public class UserPostLike // Many To Many 'Through' / 'Join' Table
    {
        [Key]
        public int UserPostLikeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /* Foreign Keys and Navigation Properties for Relationships */
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}