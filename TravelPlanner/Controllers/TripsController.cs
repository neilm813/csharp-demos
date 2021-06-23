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

            List<Trip> trips = db.Trips.ToList();
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
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                // Display form errors.
                return View("New");
            }

            newTrip.UserId = (int)uid;
            db.Trips.Add(newTrip);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/trips/{tripId}")]
        public IActionResult Details(int tripId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Trip trip = db.Trips
                .Include(t => t.TripDestinations)
                .FirstOrDefault(t => t.TripId == tripId);

            if (trip == null)
            {
                return RedirectToAction("All");
            }

            List<DestinationMedia> allDestinations = db.DestinationMedias.ToList();
            List<DestinationMedia> destinationsToAdd = new List<DestinationMedia>();

            foreach (DestinationMedia destination in allDestinations)
            {
                bool alreadyAdded = trip.TripDestinations.Any(td => td.DestinationMediaId == destination.DestinationMediaId);

                if (!alreadyAdded)
                {
                    destinationsToAdd.Add(destination);
                }
            }

            ViewBag.DestinationsToAdd = destinationsToAdd.OrderBy(dm => dm.Location, System.StringComparer.CurrentCultureIgnoreCase);

            return View("Details", trip);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
