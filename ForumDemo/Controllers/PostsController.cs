using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        private ForumDemoContext db;
        public PostsController(ForumDemoContext context)
        {
            db = context;
        }

        // handles the GET request to DISPLAY the form used to create a new Post
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
                /* 
                Send back to the page with the form so error messages are
                displayed with the filled in input data.
                */
                return View("New");
            }

            // ModelState IS valid
            db.Posts.Add(newPost);
            // db doesn't update until we run save changes
            // After SaveChanges, our newPost object now has it's PostId from the db.
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}