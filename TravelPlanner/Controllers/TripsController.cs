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
                .Include(t => t.UserTripLikes)
                .ThenInclude(like => like.User)
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
                .ThenInclude(td => td.DestinationMedia)
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

            // ViewBag.DestinationsToAdd = db.DestinationMedias
            //     .Where(
            //         dest => !dest.TripDestinations
            //             .Any(td => td.TripId == trip.TripId)
            //     )
            //     .OrderBy(d => d.Location, System.StringComparer.CurrentCultureIgnoreCase)
            //     .ToList();

            return View("Details", trip);
        }

        [HttpPost("/trips/{tripId}/add-destination")]
        public IActionResult AddDestination(int tripId, TripDestination newTripDestination)
        {
            newTripDestination.TripId = tripId;

            bool alreadyExists = db.TripDestinations
                .Any(td => td.TripId == newTripDestination.TripId && td.DestinationMediaId == newTripDestination.DestinationMediaId);

            if (!alreadyExists)
            {
                db.TripDestinations.Add(newTripDestination);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { tripId = newTripDestination.TripId });
        }

        [HttpPost("/trips/{tripId}/{destinationMediaId}/remove")]
        public IActionResult RemoveDestination(int tripId, int destinationMediaId)
        {
            TripDestination foundTd = db.TripDestinations.FirstOrDefault(td => td.TripId == tripId && td.DestinationMediaId == destinationMediaId);

            if (foundTd != null)
            {
                db.TripDestinations.Remove(foundTd);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { tripId = tripId });
        }

        [HttpPost("/trips/{tripId}/like")]
        public IActionResult Like(int tripId)
        {
            UserTripLike foundLike = db.UserTripLikes
                .FirstOrDefault(like => like.TripId == tripId && like.UserId == uid);

            if (foundLike == null)
            {
                UserTripLike newLike = new UserTripLike()
                {
                    UserId = (int)uid,
                    TripId = tripId
                };

                db.UserTripLikes.Add(newLike);
            }
            else
            {
                db.UserTripLikes.Remove(foundLike);
            }

            db.SaveChanges();
            return RedirectToAction("All");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
