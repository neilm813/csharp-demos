using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TravelGuide.Controllers
{
    public class HomeController : Controller // <- inherit from the base abstract Controller
    {
        [HttpGet("")] // attribute, pattern is: [HttpVerb("url")]
        public ViewResult Index()
        {
            ViewBag.Introduction = "My name is Falconhoof and I will be your guide on your quest.";
            ViewBag.YearCreated = "2021";
            ViewBag.ImgUrl = "https://ih1.redbubble.net/image.230236822.2041/raf,750x1000,075,t,101010:01c5ca27c6.u3.jpg";

            /* 
            If no string passed in, will use look for a .cshtml file named the
            same as this method (action).
            */
            return View("Index");
        }

        [HttpGet("travel/{destination}")]
        public RedirectToActionResult Unknown(string destination)
        {
            List<string> x = new List<string>();
            Console.WriteLine($"URL destination: {destination}");

            // redirect to Index method (action).
            return RedirectToAction("Index");
        }
    }
}