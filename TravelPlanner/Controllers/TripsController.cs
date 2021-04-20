using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TravelPlanner.Models;

namespace TravelPlanner.Controllers
{
    public class TripsController : Controller
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
        public TripsController(TravelPlannerContext context)
        {
            db = context;
        }


        [HttpGet("/trips")]
        public IActionResult All()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("All");
        }

        [HttpGet("/trips/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/trips/create")]
        public IActionResult Create(Trip newTrip)
        {

            // To get rid of the default error: The value '' is invalid.
            // So that we can add our own.
            if (ModelState.ContainsKey("Date") == true)
            {
                ModelState["Date"].Errors.Clear();
            }


            if (newTrip.Date <= DateTime.Now)
            {
                ModelState.AddModelError("Date", "must be in the future.");
            }

            if (!ModelState.IsValid)
            {
                // To display validation errors.
                return View("New");
            }


            // WILL GET THIS ERROR if FK is not assigned:
            // "foreign key constraint fails"
            newTrip.UserId = (int)uid;
            db.Trips.Add(newTrip);
            db.SaveChanges(); // after this newTrip has it's TripId from DB.

            /* 
            WHENEVER REDIRECTING to a method that has params, you must pass in
            a 'new' dictionary: new { paramName = valueForParam }
            */
            return RedirectToAction("Details", new { tripId = newTrip.TripId });
        }

        [HttpGet("/trips/{tripId}")]
        public IActionResult Details(int tripId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Trip trip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            if (trip == null)
            {
                return RedirectToAction("New");
            }

            return View("Details", trip);
        }
    }
}
