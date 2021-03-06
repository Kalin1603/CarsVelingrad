﻿namespace CarsVelingrad.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VehicleViewModel
    {

        public int Id { get; set; }
        public string Brand { get; set; }

        public decimal Price { get; set; }

        public string AdvertDate { get; set; }

        public int? Run { get; set; }

        public string Model { get; set; }

        public string City { get; set; }

        public string Color { get; set; }

        public string Engine { get; set; }

        public int VehicleTypeId { get; set; }

        public int ExtrasPackageId { get; set; }

        public List<string> Tags { get; set; }

    }
}
