using CarsVelingrad.Data;
using CarsVelingrad.Services;
using CarsVelingrad.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarsVelingrad.Web.Controllers
{
    public class CarsVelingradController : Controller
    {
       private static ApplicationDbContext dbContext = new ApplicationDbContext();
       private readonly VehicleService vehicleService = new VehicleService(dbContext);
        private IVehicleService vehiclesService;

        public CarsVelingradController(IVehicleService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }

        public IActionResult Index(int page = 1)
        {
            VehiclesViewModel model = vehicleService.GetVehicles(page);
            return View(model);
        }

    }
}
