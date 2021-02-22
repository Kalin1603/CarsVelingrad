namespace CarsVelingrad.Services
{
    using CarsVelingrad.Data;
    using CarsVelingrad.Data.Models;
    using CarsVelingrad.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VehicleService
    {
        private readonly ApplicationDbContext db;

        public VehicleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public VehiclesViewModel GetVehicles(int pageNumber = 1)
        {
            VehiclesViewModel model = new VehiclesViewModel();

            model.ElementsCount = db.Vehicles.Count();
            model.PageNumber = pageNumber;

            model.Vehicles = db.Vehicles.Select(x => new VehicleViewModel()
            {
                VehicleTypeId = x.VehicleTypeId,
                AdvertDate = x.AdvertDate.ToString("MMMM dd, yyyy"),
                City = x.City.Name,
                Color = x.Color.Name,
                Engine = x.EngineId,
                ExtrasPackageId = x.ExtrasPackageId,
                Model = x.Model.Name,
                Price = x.Price,
                Run = x.Run,
                Brand = x.Model.Brand.Name

            }).Skip(model.ItemsPerPage * model.PageNumber - 1)
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

            Vehicle vehicle = new Vehicle() { Price = inputModel.Price,Run = inputModel.Run, Engine = engine, City = city, Model = model, Color = color, ExtrasPackage = extrasPackage, VehicleType = vehicleType };

            this.db.Vehicles.Add(vehicle);
            this.db.SaveChanges();
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
                        Tag = this.GetOrCreateTag("HighClassVehicle")
                    });
            }

            else if (vehicle.Price < 150000 && vehicle.Price >= 10000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("MiddleClassVehicle")
                    });
            }

            else
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("LowClassVehicle")
                    });
            }

            if (vehicle.Engine.HorsePower > 1700)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("ExtremelyFast")
                    });
            }

            else if (vehicle.Engine.HorsePower < 1700 && vehicle.Engine.HorsePower >= 1000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("Fast")
                    });
            }

            else if (vehicle.Engine.HorsePower < 1000 && vehicle.Engine.HorsePower >= 500)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("MediumFast")
                    });
            }

            else
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("Slow")
                    });
            }

            if (vehicle.Engine.Volume > 3000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("ExtremelyLoud")
                    });
            }

            else if (vehicle.Engine.Volume < 3000 && vehicle.Engine.Volume >= 2000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("Loud")
                    });
            }

            else if (vehicle.Engine.Volume < 2000 && vehicle.Engine.Volume >= 1000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("MediumLoud")
                    });
            }

            else
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("Quiet")
                    });
            }

            if (vehicle.Run > 50000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("HugeRun")
                    });
            }

            else if (vehicle.Run < 50000 && vehicle.Run >= 20000)
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("MediumRun")
                    });
            }

            else
            {
                vehicle.Tags.Add(
                    new TagCars
                    {
                        Tag = this.GetOrCreateTag("SmallRun")
                    });
            }

            db.SaveChanges();
        }
    }
}
