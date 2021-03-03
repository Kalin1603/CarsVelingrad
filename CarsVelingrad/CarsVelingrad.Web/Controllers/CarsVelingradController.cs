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

      
        public IActionResult Index()
        {
            VehiclesViewModel model = vehicleService.GetVehicles();
            return View(model);
        }

    }
}
