using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using web.Models;

namespace web.Controllers
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
            var urlRequest = "https://localhost:7217/api/Home";
            var response = new HttpClient().GetStringAsync(urlRequest).Result;
            List<Compounding> compounding = JsonConvert.DeserializeObject<List<Compounding>>(response);
            return View(compounding);
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
        public IActionResult Bai4()
        {
            var urlRequest = "https://localhost:7217/api/Home/CalculateArea";
            var response = new HttpClient().GetStringAsync(urlRequest).Result;
            List<trigle> tringles = JsonConvert.DeserializeObject<List<trigle>>(response);
            return View(tringles);
        }
       
    }
    public class Compounding
    {
        public int sothang { get; set; }
        public long sotien { get; set; }
        public double tylelai { get; set; }
        public double lai { get; set; }
    }
    public class trigle
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double area { get; set; }
    }
}
