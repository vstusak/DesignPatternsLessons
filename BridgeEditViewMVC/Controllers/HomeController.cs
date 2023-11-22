using BridgeEditViewMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BridgeEditViewMVC.Entities;

namespace BridgeEditViewMVC.Controllers
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
            var item = new Book() {Author = "Jara", Price = 222, Publisher = "MediaX", Title = "Holoubci"};

            var type = item.GetType();

        //TODO - view model is dynamic;
        // show model properties from type reflection
        // edit - select control based on reflection type (string/integer etc)
        // POST method must also use reflection

            return View();
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