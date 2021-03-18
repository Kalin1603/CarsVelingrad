using CarsVelingrad.ViewModels;

namespace CarsVelingrad.Services
{
    public interface IVehicleService
    {
        void Create(VehicleInputViewModel inputModel);

        VehiclesViewModel GetVehicles(int pageNumber = 1);

        TopVehicleViewModel GetTopExpensiveVehicles();

        TopVehicleViewModel SearchByPrice();

        TopVehicleViewModel GetLastAddedVehicles();

        SearchVehiclesViewModel SearchByPrice(int minPrice, int maxPrice, int pageNumber);

        bool DeleteVehicle(int id);
    }
}