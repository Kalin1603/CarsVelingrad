namespace CarsVelingrad.Services
{
    using CarsVelingrad.Data;
    using CarsVelingrad.Data.Models;
    using CarsVelingrad.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext db;

        public VehicleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool DeleteVehicle(int id)
        {
            Vehicle vehicle = this.db.Vehicles.FirstOrDefault(x => x.Id == id);
            if (vehicle == null)
            {
                return false;
            }
            ExtrasPackage extras = this.db.Extras.FirstOrDefault(x => x.VehicleId == id);
            this.db.Extras.Remove(extras);
            this.db.Vehicles.Remove(vehicle);
            this.db.SaveChanges();
            return true;
        }

        public VehiclesViewModel GetVehicles(int pageNumber = 1)
        {
            VehiclesViewModel model = new VehiclesViewModel();

            model.ElementsCount = db.Vehicles.Count();
            model.PageNumber = pageNumber;

            model.Vehicles = db.Vehicles.Select(x => new VehicleViewModel()
            {
                Id = x.Id,
                VehicleTypeId = x.VehicleTypeId,
                AdvertDate = x.AdvertDate.ToString("MMMM dd, yyyy"),
                City = x.City.Name,
                Color = x.Color.Name,
                Engine = x.Engine.EngineType.Name,
                ExtrasPackageId = x.ExtrasPackageId,
                Model = x.Model.Name,
                Price = x.Price,
                Run = x.Run,
                Brand = x.Model.Brand.Name,
                Tags = x.Tags.Select(t => t.Tag.Name).ToList()

            }).Skip(model.ItemsPerPage * (model.PageNumber - 1))
            .Take(model.ItemsPerPage)
            .ToList();

            return model;
        }
        

        private Tag GetOrCreateTag(string tagName)
        {
            Tag tag = this.db.Tags.FirstOrDefault(x => x.Name == tagName);

            if (tag == null)
            {
                tag = new Tag() { Name = tagName };
            }
            return tag;
        }

        public void Create(VehicleInputViewModel inputModel)
        {
            bool isInvalid = string.IsNullOrWhiteSpace(inputModel.Brand) || string.IsNullOrWhiteSpace(inputModel.Model)
                || string.IsNullOrWhiteSpace(inputModel.City) || string.IsNullOrWhiteSpace(inputModel.Country);

            if (isInvalid)
            {
                throw new ArgumentException("Invalid vehicle data!");
            }

            Brand brand = this.db.Brands.FirstOrDefault(b => b.Name == inputModel.Brand);

            if (brand == null)
            {
                brand = new Brand() { Name = inputModel.Brand };
            }

            Model model = this.db.Models.FirstOrDefault(m => m.Name == inputModel.Model && m.Brand.Name == inputModel.Brand);

            if (model == null)
            {
                model = new Model() { Name = inputModel.Model, Brand = brand };
            }

            EngineType engineType = this.db.EngineTypes.FirstOrDefault(et => et.Name == inputModel.EngineType);

            if (engineType == null)
            {
                engineType = new EngineType() { Name = inputModel.EngineType };
            }

            Engine engine = this.db.Engines.FirstOrDefault(e => e.HorsePower == inputModel.HorsePower && e.Volume == inputModel.EngineVolume && e.EngineType.Name == inputModel.EngineType);

            if (engine == null)
            {
                engine = new Engine() { HorsePower = inputModel.HorsePower, Volume = inputModel.EngineVolume, EngineType = engineType };
            }

            Country country = this.db.Countries.FirstOrDefault(c => c.Name == inputModel.Country);

            if (country == null)
            {
                country = new Country() { Name = inputModel.Country };
            }

            City city = this.db.Cities.FirstOrDefault(c => c.Name == inputModel.City && c.Country.Name == inputModel.Country);

            if (city == null)
            {
                city = new City() { Name = inputModel.City, Country = country, ZipCode = inputModel.Zipcode };
            }

            Color color = this.db.Colors.FirstOrDefault(c => c.Name == inputModel.Color);

            if (color == null)
            {
                color = new Color() { Name = inputModel.Color };
            }

            ExtrasPackage extrasPackage = new ExtrasPackage()
            {
                HasABS = inputModel.HasABS,
                HasAllWheelDriveSystem = inputModel.HasAllWheelDriveSystem,
                HasCentralLock = inputModel.HasCentralLock,
                HasClimatronic = inputModel.HasClimatronic,
                HasCruiseControl = inputModel.HasCruiseControl,
                HasDVD = inputModel.HasDVD,
                HasElectricWindows = inputModel.HasElectricWindows,
                HasParkAssist = inputModel.HasParkAssist,
                HasRadioBluetooth = inputModel.HasRadioBluetooth,
                HasStabilityControl = inputModel.HasStabilityControl
            };

            VehicleType vehicleType = this.db.VehicleTypes.FirstOrDefault(v => v.Name == inputModel.VehicleType);

            if (vehicleType == null)
            {
                vehicleType = new VehicleType() { Name = inputModel.VehicleType };
            }

            Vehicle vehicle = new Vehicle() { Price = inputModel.Price, Run = inputModel.Run, Engine = engine, City = city, Model = model, Color = color, ExtrasPackage = extrasPackage, VehicleType = vehicleType };

            this.db.Vehicles.Add(vehicle);
            this.db.SaveChanges();
            this.UpdateTags(vehicle.Id);
        }

        private void UpdateTags(int vehicleId)
        {
            Vehicle vehicle = this.db.Vehicles.FirstOrDefault(x => x.Id == vehicleId);

            if (vehicle == null)
            {
                return;
            }

            vehicle.Tags.Clear();

            if (vehicle.Price > 150000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("ВисокКласАвтомобил")
                    });
            }

            else if (vehicle.Price < 150000 && vehicle.Price >= 10000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("СреденКласАвтомобил")
                    });
            }

            else
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("НисъкКласАвтомобил")
                    });
            }

            if (vehicle.Engine.HorsePower > 1700)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("МногоБързАвтомобил")
                    });
            }

            else if (vehicle.Engine.HorsePower < 1700 && vehicle.Engine.HorsePower >= 1000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("БързАвтомобил")
                    });
            }

            else if (vehicle.Engine.HorsePower < 1000 && vehicle.Engine.HorsePower >= 500)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("СредноБързАвтомобил")
                    });
            }

            else
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("БавенАвтомобил")
                    });
            }

            if (vehicle.Engine.Volume > 3000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("МногоГолямДвигател")
                    });
            }

            else if (vehicle.Engine.Volume < 3000 && vehicle.Engine.Volume >= 2000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("ГолямДвигател")
                    });
            }

            else if (vehicle.Engine.Volume < 2000 && vehicle.Engine.Volume >= 1000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("СредноГолямДвигател")
                    });
            }

            else
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("МалъкДвигател")
                    });
            }

            if (vehicle.Run > 50000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("ГолямПробег")
                    });
            }

            else if (vehicle.Run < 50000 && vehicle.Run >= 20000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("СреденПробег")
                    });
            }

            else
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("МалъкПробег")
                    });
            }

            db.SaveChanges();



        }

        public TopVehicleViewModel GetTopExpensiveVehicles()
        {
            TopVehicleViewModel model = new TopVehicleViewModel();

            model.vehicleViewModels = this.db.Vehicles
                .OrderByDescending(x => x.Price)
                .Take(6)
                .Select(x => new VehicleViewModel()
                {
                    AdvertDate = x.AdvertDate.ToString("MMMM dd, yyyy"),
                    City = x.City.Name,
                    Color = x.Color.Name,
                    Engine = x.Engine.EngineType.Name,
                    Model = x.Model.Name,
                    Price = x.Price,
                    Run = x.Run,
                    Brand = x.Model.Brand.Name,
                })
                .ToList();

            return model;
        }

        public TopVehicleViewModel SearchByPrice()
        {
            TopVehicleViewModel model = new TopVehicleViewModel();

            model.vehicleViewModels = this.db.Vehicles
                .Where(x => x.Price > 0)
                .OrderBy(x => x.Price)
                .Take(6)
                .Select(x => new VehicleViewModel()
                {
                    AdvertDate = x.AdvertDate.ToString("MMMM dd, yyyy"),
                    City = x.City.Name,
                    Color = x.Color.Name,
                    Engine = x.Engine.EngineType.Name,
                    Model = x.Model.Name,
                    Price = x.Price,
                    Run = x.Run,
                    Brand = x.Model.Brand.Name,
                })
                .ToList();

            return model;
        }

        public TopVehicleViewModel GetLastAddedVehicles()
        {
            TopVehicleViewModel model = new TopVehicleViewModel();

            model.vehicleViewModels = this.db.Vehicles
                .OrderByDescending(x => x.AdvertDate)
                .Take(6)
                .Select(x => new VehicleViewModel()
                {
                    AdvertDate = x.AdvertDate.ToString("MMMM dd, yyyy"),
                    City = x.City.Name,
                    Color = x.Color.Name,
                    Engine = x.Engine.EngineType.Name,
                    Model = x.Model.Name,
                    Price = x.Price,
                    Run = x.Run,
                    Brand = x.Model.Brand.Name,
                })
                .ToList();

            return model;

        }



        public SearchVehiclesViewModel SearchByPrice(int minPrice, int maxPrice, int pageNumber = 1)
        {
            SearchVehiclesViewModel model = new SearchVehiclesViewModel();

            model.ElementsCount = db.Vehicles.Count();
            model.PageNumber = pageNumber;
            model.MinPrice = minPrice;
            model.MaxPrice = maxPrice;


            model.Vehicles = db.Vehicles
                .OrderBy(x => x.Price)
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Select(x => new VehicleViewModel()
                {

                    Id = x.Id,
                    VehicleTypeId = x.VehicleTypeId,
                    AdvertDate = x.AdvertDate.ToString("MMMM dd, yyyy"),
                    City = x.City.Name,
                    Color = x.Color.Name,
                    Engine = x.Engine.EngineType.Name,
                    ExtrasPackageId = x.ExtrasPackageId,
                    Model = x.Model.Name,
                    Price = x.Price,
                    Run = x.Run,
                    Brand = x.Model.Brand.Name,
                    Tags = x.Tags.Select(t => t.Tag.Name).ToList()

                }).Skip(model.ItemsPerPage * (model.PageNumber - 1))
            .Take(model.ItemsPerPage)
            .ToList();

            return model;
        }
    }

}   
