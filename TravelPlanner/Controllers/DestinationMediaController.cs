using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelPlanner.Models;

namespace TravelPlanner.Controllers
{
    public class DestinationMediaController : Controller
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

        private TravelPlannerContext db;
        public DestinationMediaController(TravelPlannerContext context)
        {
            db = context;
        }


        [HttpGet("/destinations/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/destination/create")]
        public IActionResult Create(DestinationMedia newDestinationMedia)
        {
            if (!ModelState.IsValid)
            {
                // To display validation errors.
                return View("New");
            }


            // WILL GET THIS ERROR if FK is not assigned:
            // "foreign key constraint fails"
            newDestinationMedia.UserId = (int)uid;
            db.DestinationMedia.Add(newDestinationMedia);
            db.SaveChanges();

            /* 
            WHENEVER REDIRECTING to a method that has params, you must pass in
            a 'new' dictionary: new { paramName = valueForParam }
            */

            return RedirectToAction("Details", new { destinationMediaId = newDestinationMedia.DestinationMediaId });
        }

        [HttpGet("/destinations/{destinationMediaId}")]
        public IActionResult Details(int destinationMediaId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            DestinationMedia destinationMedia = db.DestinationMedia
                .FirstOrDefault(dest => dest.DestinationMediaId == destinationMediaId);

            if (destinationMedia == null)
            {
                return RedirectToAction("New");
            }

            return View("Details", destinationMedia);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
