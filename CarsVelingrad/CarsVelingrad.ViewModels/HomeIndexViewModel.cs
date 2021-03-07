using System;
using System.Collections.Generic;
using System.Text;

namespace CarsVelingrad.ViewModels
{
    public class HomeIndexViewModel
    {
        public TopVehicleViewModel TopExpensive{ get; set; }

        public TopVehicleViewModel TopCheapest { get; set; }

        public TopVehicleViewModel LastAdded { get; set; }

    }
}
