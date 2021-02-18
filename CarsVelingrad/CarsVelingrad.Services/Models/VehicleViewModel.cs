namespace CarsVelingrad.Services.Models
{
    using System;
    public class VehicleViewModel
    {

        public decimal Price { get; set; }

        public DateTime AdvertDate { get; set; }

        public int? Run { get; set; }

        public string Model { get; set; }

        public string City { get; set; }

        public string Color { get; set; }

        public int Engine { get; set; }

        public int VehicleTypeId { get; set; }

        public int ExtrasPackageId { get; set; }



    }
    
}
