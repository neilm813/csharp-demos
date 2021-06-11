using System;
using System.Collections.Generic;
using ASPIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPIntro.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")] // Attribute shorthand for [HttpGet] and [Route("")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet("/videos")]
        public ViewResult Videos()
        {
            List<string> youtubeVideoIds = new List<string>()
            {
            "5qap5aO4i9A", "EHtsQ9thkIY", "0rBG9BAiiC4", "cCwiZdFz63w", "fb9-OzVuV6g", "-y8aKyi6-OQ", "kVaiWk7H7n0",
            "UDA6Kd6uYqs", "eg9_ymCEAF8", "Q8vnqwtOf8E"
            };

            // This data has been moved into a ViewModel
            // ViewBag.YoutubeVideoIds = youtubeVideoIds;
            // ViewBag.RandomNumber = new System.Random().Next();

            VideosView videosViewModel = new VideosView()
            {
                YoutubeVideoIds = youtubeVideoIds,
                RandomNumber = new Random().Next()
            };

            return View("Videos", videosViewModel);
        }

        // Display registration form.
        [HttpGet("/users/register")]
        public ViewResult Register()
        {
            return View("Register");
        }

        [HttpPost("/users/process-registration")]
        public ViewResult ProcessRegistration(User newUser)
        {
            return View("Guest", newUser);
        }

        [HttpGet("{**path}")]
        public RedirectToActionResult Unknown(string path)
        {
            Console.WriteLine($"Unknown path: {path}");
            return RedirectToAction("Index");
        }
    }
}