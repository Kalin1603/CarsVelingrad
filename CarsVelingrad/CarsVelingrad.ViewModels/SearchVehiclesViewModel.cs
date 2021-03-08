namespace CarsVelingrad.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SearchVehiclesViewModel:PagingViewModel
    {
        public ICollection<VehicleViewModel> Vehicles { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }
    }
}
