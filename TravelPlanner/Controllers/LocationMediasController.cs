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
    public class LocationMediasController : Controller
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

        public LocationMediasController(TravelPlannerContext context)
        {
            db = context;
        }

        [HttpGet("/locationmedias")]
        public IActionResult All()
        {
            List<LocationMedia> locationMedias = db.LocationMedias.ToList();
            return View("All", locationMedias);
        }

        [HttpGet("/locationmedias/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/locationmedias/create")]
        public IActionResult Create(LocationMedia newLocationMedia)
        {
            if (!ModelState.IsValid)
            {
                // Display form errors.
                return View("New");
            }

            newLocationMedia.UserId = (int)uid;
            db.LocationMedias.Add(newLocationMedia);
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
