using CarsVelingrad.Services;
using CarsVelingrad.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsVelingrad.ConsoleApp
{
    public class Engine
    {
        private readonly VehicleServices vehicleServices;

        public Engine(VehicleServices vehicleServices)
        {
            this.vehicleServices = vehicleServices;
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine(Menu());
                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        ListOperations();
                        break;
                }
            }
        }

        private void ListOperations()
        {
            VehiclesViewModel model = vehicleServices.GetVehicles();
            while (true)
            {
                foreach (var vehicles in model.Vehicles)
                {
                    Console.WriteLine($"{vehicles.VehicleTypeId},{vehicles.AdvertDate},{vehicles.Price},{vehicles.Model},{vehicles.Run},{vehicles.Engine},{vehicles.ExtrasPackageId},{vehicles.Color},{vehicles.City} ");
                }
                Console.WriteLine($"Страница: {model.PageNumber} / {model.PagesCount}, Автомобили: {model.ElementsCount}");

                Console.WriteLine(ListMenu());
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "0":
                        Run();
                        break;
                    case "1":
                        if (model.HasPreviousPage)
                        {
                            model = vehicleServices.GetVehicles(model.PreviousPageNumber);
                        }
                        else
                        {
                            Console.WriteLine("Невалидна Страница");
                        }
                        break;
                    case "2":
                        if (model.HasNextPage)
                        {
                            model =vehicleServices.GetVehicles(model.NextPageNumber)
                        }
                        else
                        {
                            Console.WriteLine("Невалидна Страница");
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private string Menu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1: Списък с превозни средства");
            return sb.ToString().TrimEnd();
        }

        private string ListMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("0: Главно меню");
            sb.AppendLine("1: Предишна страница");
            sb.AppendLine("2: Следваща страница");
            return sb.ToString().TrimEnd();
        }
    }
}
