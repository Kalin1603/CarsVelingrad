﻿using CarsVelingrad.ViewModels;

namespace CarsVelingrad.Services
{
    public interface IVehicleService
    {
        void Create(VehicleInputViewModel inputModel);

        VehiclesViewModel GetVehicles(int pageNumber = 1);

        TopVehicleViewModel GetTopExpensiveVehicles();

        TopVehicleViewModel GetTopCheapestVehicles();

        TopVehicleViewModel GetLastAddedVehicles();

        bool DeleteVehicle(int id);
    }
}