using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

using dotnet_mvc.Models;
using dotnet_mvc.Database;

namespace dotnet_mvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDBContext database;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext database)
        {
            _logger = logger;
            this.database = database;
        }

        public IActionResult Index()
        {
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

        public IActionResult Test()
        {
            // Category c1 = new Category();
            // c1.Name = "Logistics";

            // Category c2 = new Category();
            // c2.Name = "Data Science";

            // Category c3 = new Category();
            // c3.Name = "Logistics";

            // List<Category> categories = new List<Category>();
            // categories.Add(c1);
            // categories.Add(c2);
            // categories.Add(c3);

            // this.database.AddRange(categories);
            // this.database.SaveChanges();

            Console.WriteLine("Categories --- Init");
            var categories = database.Categories.Where(item => item.Name.Equals("Logistics")).ToList();

            categories.ForEach(item =>
            {
                Console.WriteLine(item.ToString());
            });

            Console.WriteLine("Categories --- Finish");

            return Content("Dados salvos");
        }
    }
}
