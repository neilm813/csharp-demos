using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("/posts")]
        public IActionResult All()
        {
            List<Post> allPosts = db.Posts.ToList();
            return View("All", allPosts);
        }

        // Params from the URL get turned into method params.
        [HttpGet("/posts/{postId}")]
        public IActionResult Details(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            if (post == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", post);
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

            /* 
            This Add method auto generates SQL code:
            INSERT INTO posts (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
            VALUES ("topic data", "body data", "img url data", NOW(), NOW());
            */
            db.Posts.Add(newPost);
            // db doesn't update until we run save changes
            // After SaveChanges, our newPost object now has it's PostId from the db.
            db.SaveChanges();

            return RedirectToAction("All");
        }

        [HttpPost("/posts/{postId}/delete")]
        public IActionResult Delete(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            if (post != null)
            {
                db.Posts.Remove(post);
                db.SaveChanges();
            }
            return RedirectToAction("All");
        }

        [HttpGet("/posts/{postId}/edit")]
        public IActionResult Edit(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            // It could be null if user types invalid id directly into address bar.
            if (post == null)
            {
                return RedirectToAction("All");
            }

            return View("Edit", post);
        }

        [HttpPost("/posts/{postId}/update")]
        public IActionResult Update(Post editedPost, int postId)
        {
            if (ModelState.IsValid == false)
            {
                editedPost.PostId = postId;
                /* 
                Send back to the page with the form so error messages are
                displayed with the filled in input data.

                The Edit pages @model is a Post so we have to send it as the
                ViewModel and add the id to it since the Edit page needs access
                to the id.
                */
                return View("Edit", editedPost);
            }

            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            post.Topic = editedPost.Topic;
            post.Body = editedPost.Body;
            post.ImgUrl = editedPost.ImgUrl;
            post.UpdatedAt = DateTime.Now;

            db.Posts.Update(post);
            db.SaveChanges();

            /* 
            new {} means new dict of key value pairs, key = value where key
            matches param name of the method we are redirecting to.
            */
            return RedirectToAction("Details", new { postId = postId });
            // return Redirect($"/posts/{postId}");
        }
    }


}