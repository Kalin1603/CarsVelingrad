namespace CarsVelingrad.Importer
{
    using CarsVelingrad.Data;
    using CarsVelingrad.Data.Models;
    using CarsVelingrad.Services;
    using CarsVelingrad.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    public class Program
    {
        public static void Main()
        {
            var json = File.ReadAllText("carsImporter.json");
            var vehicles = JsonSerializer.Deserialize<IEnumerable<JsonVehicle>>(json);
            var db = new ApplicationDbContext();
            VehicleService service = new VehicleService(db);

            foreach (var vehicle in vehicles)
            {
                try
                {
                    service.Create(new VehicleInputViewModel ()
                    {
                        Brand = vehicle.Brand,
                        Model = vehicle.Model,
                        VehicleType = vehicle.VehicleType,
                        City = vehicle.City,
                        Country = vehicle.Country,
                        Color = vehicle.Color,
                        EngineType = vehicle.EngineType,
                        EngineVolume = vehicle.EngineVolume,
                        Price = vehicle.Price,
                        Run = vehicle.Run,
                        Zipcode = vehicle.Zipcode,
                        HorsePower = vehicle.HorsePower,
                        HasABS = vehicle.HasABS,
                        HasAllWheelDriveSystem = vehicle.HasAllWheelDriveSystem,
                        HasCentralLock = vehicle.HasCentralLock,
                        HasClimatronic = vehicle.HasClimatronic,
                        HasCruiseControl = vehicle.HasCruiseControl,
                        HasDVD = vehicle.HasDVD,
                        HasElectricWindows = vehicle.HasElectricWindows,
                        HasParkAssist = vehicle.HasParkAssist,
                        HasRadioBluetooth = vehicle.HasRadioBluetooth,
                        HasStabilityControl = vehicle.HasStabilityControl
                        
                    });
                    Console.WriteLine("Add...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
