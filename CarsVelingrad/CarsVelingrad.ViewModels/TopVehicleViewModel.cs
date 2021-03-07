using System;
using System.Collections.Generic;
using System.Text;

namespace CarsVelingrad.ViewModels
{
    public class TopVehicleViewModel
    { 
        public ICollection<VehicleViewModel> vehicleViewModels { get; set; }
    }
}
