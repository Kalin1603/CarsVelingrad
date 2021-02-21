using CarsVelingrad.Services;
using CarsVelingrad.ViewModels;
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
                PrintLine();
                Console.WriteLine($"{"Модел",20} | {"Цена",10} лв. | {"Дата",20} | {"Пробег",10} | {"Местоположение"}");
                PrintLine();
                foreach (var vehicles in model.Vehicles)
                {
                    Console.WriteLine($"{vehicles.Model,20} | {vehicles.Price,10} лв. | {vehicles.AdvertDate,20} | {vehicles.Run,10} | {vehicles.City}");
                }

                PrintLine();
                Console.WriteLine($"Страница: {model.PageNumber} / {model.PagesCount}, Автомобили: {model.ElementsCount}");
                PrintLine();
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
                            model = vehicleServices.GetVehicles(model.NextPageNumber);
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

        private static void PrintLine()
        {
            Console.WriteLine(new string('-', 95));
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
