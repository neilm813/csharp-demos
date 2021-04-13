using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionStory.Models;

namespace SessionStory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/login")]
        public IActionResult Login(User newUser)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Username", newUser.Username);
                return RedirectToAction("StoryTime");
            }

            // If ModelState is invalid send back to same page to see errors.
            return View("Index");
        }

        [HttpGet("/story")]
        public IActionResult StoryTime()
        {
            string story = HttpContext.Session.GetString("story");

            if (story == null)
            {
                // No story yet, set it to an empty string so it's ready to be
                // concatenated.
                HttpContext.Session.SetString("story", "");
            }
            return View("StoryTime");
        }

        [HttpPost("/story/add")]
        public IActionResult AddToStory(StoryFragment storyFragment)
        {
            string story = HttpContext.Session.GetString("story");
            story += " " + storyFragment.Word;
            HttpContext.Session.SetString("story", story);
            return RedirectToAction("StoryTime");
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("{**path}")]
        public IActionResult Unknown(string path)
        {
            Console.WriteLine($"Unknown URL: {path}");

            // redirect to Index method (action).
            return RedirectToAction("Index");
        }
    }
}
