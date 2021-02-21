using System;
using System.Collections.Generic;
using System.Text;

namespace CarsVelingrad.ViewModels
{
    public class VehiclesViewModel : PagingViewModel
    {
        public ICollection<VehicleViewModel> Vehicles { get; set; }
    }
}
