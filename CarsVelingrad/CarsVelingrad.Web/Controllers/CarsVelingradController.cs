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

        
        public IActionResult SearchByPrice(int minPrice,int maxPrice,int page=1)
        {
            if (minPrice!=0&&maxPrice!=0)
            {
                SearchVehiclesViewModel model = vehiclesService.SearchByPrice(minPrice, maxPrice, page);
                return View(model);

            }
            else
            {
                return View();
            }


        }
    }
}
