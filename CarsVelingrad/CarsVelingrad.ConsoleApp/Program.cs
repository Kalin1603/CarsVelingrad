namespace CarsVelingrad.ConsoleApp
{
    using CarsVelingrad.Data;
    using CarsVelingrad.Services;
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            VehicleServices vehicleServices = new VehicleServices(applicationDbContext);
            Engine engine = new Engine(vehicleServices);
            engine.Run();
        }
    }
}
