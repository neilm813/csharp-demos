using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            Dachi sessionPet = HttpContext.Session.GetObjectFromJson<Dachi>("pet");

            if (sessionPet == null)
            {
                sessionPet = new Dachi();
                HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            }

            return View("Index", sessionPet);
        }

        [HttpGet("/feed")]
        public IActionResult Feed()
        {
            Dachi sessionPet = HttpContext.Session.GetObjectFromJson<Dachi>("pet");
            sessionPet.Feed();
            HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            return RedirectToAction("Index");
        }

        [HttpGet("/play")]
        public IActionResult Play()
        {
            Dachi sessionPet = HttpContext.Session.GetObjectFromJson<Dachi>("pet");
            sessionPet.Play();
            HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            return RedirectToAction("Index");
        }

        [HttpGet("/work")]
        public IActionResult Work()
        {
            Dachi sessionPet = HttpContext.Session.GetObjectFromJson<Dachi>("pet");
            sessionPet.Work();
            HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            return RedirectToAction("Index");
        }

        [HttpGet("/sleep")]
        public IActionResult Sleep()
        {
            Dachi sessionPet = HttpContext.Session.GetObjectFromJson<Dachi>("pet");
            sessionPet.Sleep();
            HttpContext.Session.SetObjectAsJson("pet", sessionPet);
            return RedirectToAction("Index");
        }

        [HttpGet("/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
