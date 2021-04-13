using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DojoDachi.Models;
using Microsoft.AspNetCore.Http;

namespace DojoDachi.Controllers
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
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet");

            if (sessionPet == null)
            {
                Pet newPet = new Pet();
                HttpContext.Session.SetObjectAsJson("Pet", newPet);
                return View("Index", newPet);
            }

            return View("Index", sessionPet);
        }

        [HttpGet("/pet/feed")]
        public IActionResult Feed()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet");

            string gameStatus = sessionPet.Feed();
            // Running .Feed updated our Pet so we need to add the new data to session.
            HttpContext.Session.SetObjectAsJson("Pet", sessionPet);

            HttpContext.Session.SetString("GameStatus", gameStatus);

            return RedirectToAction("Index");
            // return View("Index", sessionPet);
        }

        [HttpPost("/pet/play")]
        public IActionResult Play()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet");

            string gameStatus = sessionPet.Play();

            HttpContext.Session.SetObjectAsJson("Pet", sessionPet);

            HttpContext.Session.SetString("GameStatus", gameStatus);

            return RedirectToAction("Index");
        }

        [HttpGet("/pet/sleep")]
        public IActionResult Sleep()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet");

            string gameStatus = sessionPet.Sleep();

            HttpContext.Session.SetObjectAsJson("Pet", sessionPet);

            HttpContext.Session.SetString("GameStatus", gameStatus);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
