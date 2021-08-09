using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPasscodeGenerator.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscodeGenerator.Controllers
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
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[13];
            Random random = new Random();
            if(HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count", 0);
            }
            int count = (int)HttpContext.Session.GetInt32("count");

            if (count == 0)
            {   
                count++;
                HttpContext.Session.SetInt32("count", count);
            }
            else
            {
                count++;
                HttpContext.Session.SetInt32("count", count);
            }
            // else
            // {
            //     tempCount ++;
            //     HttpContext.Session.SetInt32("count", tempCount);
            //     count = HttpContext.Session.GetInt32("count");
            // }

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalPasscode = new String(stringChars);
            RandomPasscode passcode = new RandomPasscode()
            {
                Passcode = finalPasscode,
                Count = (int)count
            };
            return View("Index", passcode);
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
