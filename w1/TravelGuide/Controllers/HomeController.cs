using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Models;

namespace TravelGuide.Controllers
{
    public class HomeController : Controller // <- inherit from the base abstract Controller
    {
        [HttpGet("")] // attribute, pattern is: [HttpVerb("url")]
        public ViewResult Index()
        {
            ViewBag.Introduction = "My name is Falconhoof and I will be your guide on your quest.";
            ViewBag.YearCreated = "2021";
            ViewBag.ImgUrl = "https://thumbs.gfycat.com/EnviousZealousCanadagoose-small.gif";

            /* 
            If no string passed in, will use look for a .cshtml file named the
            same as this method (action).
            */
            return View("Index");
        }

        [HttpPost("/guide")]
        public ViewResult Guide(Traveler newTravel)
        {
            /* 
            Problem: pass two different kinds of data to a page.

            Solution: Use ViewBag + ViewModel
            Solution: Create a new class that contains all the data inside it
            and pass that to the view as a ViewModel.
            */
            ViewBag.Locations = TravelDestinations.Destinations;
            /* 
            The data passed to this page must match the data type of the
            @model in the .cshtml file.
            */
            return View("Guide", newTravel);
        }


        [HttpGet("/travel/{chosenDestination}")]
        public ViewResult Destination(string chosenDestination)
        {
            Console.WriteLine($"URL destination: {chosenDestination}");

            Destination fullDestination = new Destination();

            foreach (Destination dest in TravelDestinations.Destinations)
            {
                if (dest.Name == chosenDestination)
                {
                    fullDestination = dest;
                }
            }

            return View("Destination", fullDestination);
        }

        [HttpGet("{path}")]
        public RedirectToActionResult Unknown(string path)
        {
            Console.WriteLine($"Unknown URL: {path}");

            // redirect to Index method (action).
            return RedirectToAction("Index");
        }
    }
}