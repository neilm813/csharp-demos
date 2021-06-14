using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionLoginValidations.Models;

namespace SessionLoginValidations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("/login")]
        public IActionResult Login(User newUser)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Model State is valid");
                HttpContext.Session.SetString("Username", newUser.Username);
                return RedirectToAction("StoryTime");
            }

            Console.WriteLine("Model State INVALID");
            // If ModelState is invalid send back to same page to see errors.
            return View("Index");
        }

        [HttpGet("/story")]
        public IActionResult StoryTime()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Index");
            }

            return View("StoryTime");
        }

        [HttpPost("/story/add")]
        public IActionResult AddToStory(StoryFragment storyFragment)
        {
            string updatedStory = HttpContext.Session.GetString("story");

            updatedStory += " " + storyFragment.Word;
            HttpContext.Session.SetString("story", updatedStory);

            return RedirectToAction("StoryTime");
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            // Clears EVERYTHING.
            // HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("/test")]
        public IActionResult Test()
        {
            return View("Test", new Test());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
