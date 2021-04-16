using System.Collections.Generic;

namespace ForumDemo.Models
{
    public class AllPage
    {
        public List<Post> Posts { get; set; }
        public Post NewPost { get; set; } = new Post();
    }
}