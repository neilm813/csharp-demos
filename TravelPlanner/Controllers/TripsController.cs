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

            List<Trip> trips = db.Trips
                .Include(trip => trip.CreatedBy)
                .ToList();

            return View("All", trips);
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

            Trip trip = db.Trips
                .Include(trip => trip.CreatedBy)
                .Include(trip => trip.TripDestinations)
                .ThenInclude(td => td.DestinationMedia)
                .FirstOrDefault(t => t.TripId == tripId);

            if (trip == null)
            {
                return RedirectToAction("New");
            }

            List<DestinationMedia> allDestinations = db.DestinationMedia.ToList();
            List<DestinationMedia> unrelatedDestinations = new List<DestinationMedia>();

            foreach (DestinationMedia dest in allDestinations)
            {
                bool isRelated = trip.TripDestinations
                    .Any(td => td.DestinationMediaId == dest.DestinationMediaId);

                if (!isRelated)
                {
                    unrelatedDestinations.Add(dest);
                }
            }

            ViewBag.UnrelatedDestinations = unrelatedDestinations
                .OrderBy(dest => dest.Location, System.StringComparer.CurrentCultureIgnoreCase);

            return View("Details", trip);
        }

        [HttpGet("/trips/{tripId}/edit")]
        public IActionResult Edit(int tripId)
        {
            Trip trip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            if (trip == null || trip.UserId != uid)
            {
                return RedirectToAction("All");
            }

            return View("Edit", trip);
        }

        [HttpPost("/trips/{tripId}/update")]
        public IActionResult Update(Trip editedTrip, int tripId)
        {
            if (!ModelState.IsValid)
            {
                /* 
                "Object reference not set to an instance of an object" if we
                don't pass the editedTrip back with the TripId because the form
                has asp-route-tripId="@Model.TripId" so it needs the TripId.
                */
                editedTrip.TripId = tripId;
                // Go back to form to display errors.
                return View("Edit", editedTrip);
            }

            Trip dbTrip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            if (dbTrip == null)
            {
                return RedirectToAction("All");
            }

            dbTrip.UpdatedAt = DateTime.Now;
            dbTrip.Name = editedTrip.Name;
            dbTrip.Description = editedTrip.Description;
            dbTrip.Date = editedTrip.Date;

            db.Trips.Update(dbTrip);
            db.SaveChanges();

            /* 
            WHENEVER REDIRECTING to a method that has params, you must pass in
            a 'new' dictionary: new { paramName = valueForParam }
            */
            return RedirectToAction("Details", new { tripId = dbTrip.TripId });
        }

        [HttpPost("/trips/{tripId}/delete")]
        public IActionResult Delete(int tripId)
        {
            Trip trip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            if (trip == null)
            {
                return RedirectToAction("All");
            }

            db.Trips.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpPost("/trips/{tripId}/add-destination")]
        public IActionResult AddDestination(TripDestination newTripDest, int tripId)
        {
            db.TripDestinations.Add(newTripDest);
            db.SaveChanges();
            return RedirectToAction("Details", new { tripId = tripId });
        }
    }
}
