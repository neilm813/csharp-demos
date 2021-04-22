using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlannerDemo.Models;

namespace WeddingPlannerDemo.Controllers
{
    public class HomeController : Controller
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
        public HomeController(WeddingPlannerContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                bool existingUser = db.Users.Any(u => u.Email == newUser.Email);

                if (existingUser)
                {
                    // Normally you don't want to reveal info like this b/c hackers can use it.
                    // But for testing purposes, we will make our errors descriptive.
                    ModelState.AddModelError("Email", "is taken.");
                }
            }

            /* 
            We could potentially have multiple conditions that invalidate the
            model state above so we have a catch-all check so we can display
            all error messages at once.
            */
            if (ModelState.IsValid == false)
            {
                // So error messages will be displayed.
                return View("Index");
            }

            // hash the password
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("FullName", newUser.FullName());
            return RedirectToAction("Dashboard", "Weddings");
        }

        [HttpPost("/login")]
        public IActionResult Login(LoginUser loginUser)
        {
            /* 
            For security, don't reveal what was invalid.
            You can make your error messages more specific to help with testing
            but on a live site it should be ambiguous.
            */
            string genericErrMsg = "Invalid Email or Password";

            if (ModelState.IsValid == false)
            {
                // So error messages will be displayed.
                return View("Index");
            }

            User dbUser = db.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

            if (dbUser == null)
            {
                ModelState.AddModelError("LoginEmail", genericErrMsg);
                Console.WriteLine(new String('*', 30) + "Login: Email not found");
                // So error messages will be displayed.
                return View("Index");
            }

            // User found b/c the above didn't return.
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

            if (pwCompareResult == 0)
            {
                ModelState.AddModelError("LoginEmail", genericErrMsg);
                Console.WriteLine(new String('*', 30) + "Login: Password incorrect.");
                return View("Index");
            }

            // Password matched.
            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            HttpContext.Session.SetString("FullName", dbUser.FullName());
            return RedirectToAction("Dashboard", "Weddings");
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
