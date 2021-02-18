namespace CarsVelingrad.ConsoleApp
{
    using CarsVelingrad.Data;
    using CarsVelingrad.Services;
    using System;

    public class Program
    {
        public static void Main()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            VehicleServices vehicleServices = new VehicleServices(applicationDbContext);
            Engine engine = new Engine(vehicleServices);
            engine.Run();
        }
    }
}
