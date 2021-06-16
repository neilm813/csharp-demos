using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForumDemo.Models;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        private ForumDemoContext db;

        public PostsController(ForumDemoContext context)
        {
            db = context;
        }

        [HttpGet("/posts")]
        public IActionResult All()
        {
            // No .Where means we get all of them.
            List<Post> allPosts = db.Posts.ToList();
            return View("All", allPosts);
        }

        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/posts/create")]
        public IActionResult Create(Post newPost)
        {
            if (ModelState.IsValid == false)
            {
                // Send back to the page with the form to show errors.
                return View("New");
            }
            // ModelState IS valid...
            db.Posts.Add(newPost);
            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}
