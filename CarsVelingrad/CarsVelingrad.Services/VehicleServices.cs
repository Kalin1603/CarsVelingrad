namespace CarsVelingrad.Services
{
    using CarsVelingrad.Data;
    using CarsVelingrad.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VehicleServices
    {
        private readonly ApplicationDbContext db;

        public VehicleServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        

        }
    }
}
