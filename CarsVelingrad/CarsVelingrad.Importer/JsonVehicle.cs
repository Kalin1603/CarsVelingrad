namespace CarsVelingrad.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

  public  class JsonVehicle
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string EngineType { get; set; }

        public int HorsePower { get; set; }

        public int EngineVolume { get; set; }

        public string City { get; set; }

        public int Zipcode { get; set; }

        public string Country { get; set; }

        public string Color { get; set; }

        public bool HasStabilityControl { get; set; }

        public bool HasDVD { get; set; }
    }
}
