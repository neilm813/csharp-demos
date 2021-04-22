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
using WeddingPlannerDemo.Models;

namespace WeddingPlannerDemo.Controllers
{
    public class WeddingsController : Controller
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

        private WeddingPlannerContext db;
        public WeddingsController(WeddingPlannerContext context)
        {
            db = context;
        }

        [HttpGet("/Dashboard")]
        public IActionResult Dashboard()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Wedding> expiredWeddings = db.Weddings
                .Where(w => w.Date < DateTime.Now)
                .ToList();

            db.RemoveRange(expiredWeddings);
            db.SaveChanges();

            List<Wedding> weddings = db.Weddings
                .Include(w => w.RSVPs)
                .ToList();

            return View("Dashboard", weddings);
        }

        [HttpGet("/weddings/new")]
        public IActionResult New()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/weddings/create")]
        public IActionResult Create(Wedding newWedding)
        {
            if (!ModelState.IsValid)
            {
                // To display validation errors.
                return View("New");
            }

            // WILL GET THIS ERROR if FK is not assigned:
            // "foreign key constraint fails"
            newWedding.UserId = (int)uid;
            db.Weddings.Add(newWedding);
            db.SaveChanges();

            /* 
            WHENEVER REDIRECTING to a method that has params, you must pass in
            a 'new' dictionary: new { paramName = valueForParam }
            */
            return RedirectToAction("Details", new { weddingId = newWedding.WeddingId });
        }

        [HttpPost("/weddings/create2")]
        public IActionResult Create2(Wedding newWedding)
        {
            if (!ModelState.IsValid)
            {
                List<Wedding> weddings = db.Weddings
                    .Include(w => w.RSVPs)
                    .ToList();
                // To display validation errors.
                return View("Dashboard", weddings);
            }

            // WILL GET THIS ERROR if FK is not assigned:
            // "foreign key constraint fails"
            newWedding.UserId = (int)uid;
            db.Weddings.Add(newWedding);
            db.SaveChanges();

            /* 
            WHENEVER REDIRECTING to a method that has params, you must pass in
            a 'new' dictionary: new { paramName = valueForParam }
            */
            return RedirectToAction("Details", new { weddingId = newWedding.WeddingId });
        }

        [HttpGet("/weddings/{weddingId}")]
        public IActionResult Details(int weddingId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Wedding wedding = db.Weddings
                .Include(w => w.RSVPs)
                .ThenInclude(rsvp => rsvp.Guest)
                .FirstOrDefault(w => w.WeddingId == weddingId);

            if (wedding == null)
            {
                return RedirectToAction("Dashboard");
            }

            return View("Details", wedding);
        }

        [HttpPost("/weddings/{weddingId}/delete")]
        public IActionResult Delete(int weddingId)
        {
            Wedding wedding = db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);

            if (wedding != null)
            {
                db.Weddings.Remove(wedding);
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        [HttpPost("/weddings/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            UserWeddingRSVP existingRSVP = db.UserWeddingRSVPs
                .FirstOrDefault(rsvp => rsvp.UserId == uid && rsvp.WeddingId == weddingId);

            if (existingRSVP == null)
            {
                UserWeddingRSVP rsvp = new UserWeddingRSVP()
                {
                    WeddingId = weddingId,
                    UserId = (int)uid
                };

                db.UserWeddingRSVPs.Add(rsvp);
            }
            else
            {
                db.UserWeddingRSVPs.Remove(existingRSVP);
            }

            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
