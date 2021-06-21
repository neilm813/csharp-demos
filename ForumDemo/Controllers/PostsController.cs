using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForumDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Controllers
{
    public class PostsController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

        private ForumDemoContext db;

        public PostsController(ForumDemoContext context)
        {
            db = context;
        }

        [HttpGet("/posts")]
        public IActionResult All()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            /* 
            No .Where means we get all posts.
            .Include always gives you the entity from the table being queried
            for you to select what to include from that model.

            Hover over the parameter to the left of the => to see it's data type if
            you forget when trying to name it.
            */
            List<Post> allPosts = db.Posts
                .Include(post => post.Author)
                .Include(post => post.Likes)
                .ToList();

            return View("All", allPosts);
        }

        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/posts/create")]
        public IActionResult Create(Post newPost)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid == false)
            {
                // Send back to the page with the form to show errors.
                return View("New");
            }
            // ModelState IS valid...
            newPost.UserId = (int)uid;
            db.Posts.Add(newPost);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/posts/{postId}")]
        public IActionResult Details(int postId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Post post = db.Posts
            .Include(post => post.Author)
            .Include(post => post.Likes)
            // .ThenInclude is for including something on the thing that was
            // just previously Included (we just included Likes above).
            .ThenInclude(like => like.User)
            .FirstOrDefault(p => p.PostId == postId);

            if (post == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", post);
        }

        [HttpPost("/posts/{postId}")]
        public IActionResult Delete(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            // If post doesn't exist or not author, redirect away.
            if (post == null || post.UserId != uid)
            {
                return RedirectToAction("All");
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return RedirectToAction("All");
        }

        [HttpGet("/posts/{postId}/edit")]
        public IActionResult Edit(int postId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            // If post doesn't exist or not author, redirect away.
            if (post == null || post.UserId != uid)
            {
                return RedirectToAction("All");
            }

            return View("Edit", post);
        }

        [HttpPost("/posts/{postId}/update")]
        public IActionResult Update(int postId, Post editedPost)
        {
            if (ModelState.IsValid == false)
            {
                editedPost.PostId = postId;
                return View("Edit", editedPost);
            }

            Post dbPost = db.Posts.FirstOrDefault(p => p.PostId == postId);

            if (dbPost == null)
            {
                return RedirectToAction("All");
            }

            dbPost.Topic = editedPost.Topic;
            dbPost.Body = editedPost.Body;
            dbPost.ImgUrl = editedPost.ImgUrl;
            dbPost.UpdatedAt = DateTime.Now;

            db.Posts.Update(dbPost);
            db.SaveChanges();

            // Dict matches Details params     new { paramName = paramValue }
            return RedirectToAction("Details", new { postId = dbPost.PostId });
        }

        [HttpPost("/posts/{postId}/like")]
        public IActionResult Like(int postId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            UserPostLike existingLike = db.UserPostLikes
                .FirstOrDefault(like => like.PostId == postId && (int)uid == like.UserId);

            if (existingLike == null)
            {
                UserPostLike like = new UserPostLike()
                {
                    PostId = postId,
                    UserId = (int)uid
                };

                db.UserPostLikes.Add(like);
            }
            else
            {
                db.UserPostLikes.Remove(existingLike);
            }

            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}
