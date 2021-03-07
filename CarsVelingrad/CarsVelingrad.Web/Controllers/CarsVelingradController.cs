using CarsVelingrad.Data;
using CarsVelingrad.Services;
using CarsVelingrad.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarsVelingrad.Web.Controllers
{
    public class CarsVelingradController : Controller
    {
        private IVehicleService vehiclesService;

        public CarsVelingradController(IVehicleService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }

        public IActionResult Index(int page = 1)
        {
            VehiclesViewModel model = vehiclesService.GetVehicles(page);
            return View(model);
        }

    }
}
