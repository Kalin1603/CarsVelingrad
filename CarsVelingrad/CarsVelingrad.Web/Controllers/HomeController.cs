using CarsVelingrad.Services;
using CarsVelingrad.ViewModels;
using CarsVelingrad.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarsVelingrad.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVehicleService vehicleService;


        public HomeController(ILogger<HomeController> logger, IVehicleService vehicleService)
        {
            _logger = logger;
            this.vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                TopCheapest = vehicleService.SearchByPrice(),
                TopExpensive = vehicleService.GetTopExpensiveVehicles(),
                LastAdded = vehicleService.GetLastAddedVehicles()
            };

            return View(model);
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

