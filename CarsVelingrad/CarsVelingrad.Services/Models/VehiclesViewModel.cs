namespace CarsVelingrad.Services.Models
{
    using System.Collections.Generic;

    public class VehiclesViewModel :PagingViewModel
    {
        public ICollection<VehicleViewModel> Vehicles { get; set; }
    }
}
