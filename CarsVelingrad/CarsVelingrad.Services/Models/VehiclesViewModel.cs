using System.Collections.Generic;

namespace CarsVelingrad.Services.Models
{
   public class VehiclesViewModel :PagingViewModel
    {
        public ICollection<VehicleViewModel> vehicles { get; set; }
    }
}
