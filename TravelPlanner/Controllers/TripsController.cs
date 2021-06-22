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
            return View("All");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
