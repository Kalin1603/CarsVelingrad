namespace CarsVelingrad.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VehicleViewModel
    {
        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string AdvertDate { get; set; }

        public int? Run { get; set; }

        public string Model { get; set; }

        public string City { get; set; }

        public string Color { get; set; }

        public int Engine { get; set; }

        public int VehicleTypeId { get; set; }

        public int ExtrasPackageId { get; set; }



    }
}
