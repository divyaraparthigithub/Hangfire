using Hangfire;
using Hangfire_task14_13_12_23.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hangfire_task14_13_12_23.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

      
        public IActionResult EnqueueWelcome()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Hi Divya"),Cron.Minutely());
            // adding to branch c
            Console.WriteLine("hi divya");
            return RedirectToAction("Index");
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}