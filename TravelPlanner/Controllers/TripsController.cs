﻿using System;
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
            List<Trip> trips = db.Trips.ToList();
            return View("All", trips);
        }

        [HttpGet("/trips/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/trips/create")]
        public IActionResult Create(Trip newTrip)
        {
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
