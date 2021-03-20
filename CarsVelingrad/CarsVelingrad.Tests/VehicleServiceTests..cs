using CarsVelingrad.Data;
using CarsVelingrad.Data.Models;
using CarsVelingrad.Services;
using Microsoft.EntityFrameworkCore;
using CarsVelingrad.ViewModels;
using Moq;
using NUnit.Framework;
namespace CarsVelingrad.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    public class VehicleServiceTests
    {
        IQueryable<Vehicle> data = new List<Vehicle>
            {
                new Vehicle {Id=1, Price = 10000, Model = new Model() { Name = "BMW"}, City = new City() {Name="Blagoevgrad"}, Run = 10000, Engine = new Engine(){ Volume = 2000}},
                new Vehicle {Id=2, Price = 20000, Model = new Model() {Name = "Audi"}, City = new City() {Name="Pazarjik"}, Run = 11000, Engine = new Engine(){ Volume = 2500} },
                new Vehicle {Id=3, Price = 30000, Model = new Model() {Name = "GF"}, City = new City() {Name="Plovdiv"}, Run = 10400, Engine = new Engine(){ Volume = 2030} },
                new Vehicle {Id=4, Price = 40000,Model = new Model() {Name = "VW"}, City = new City() {Name="Varna"}, Run = 10000, Engine = new Engine(){ Volume = 3000}  },
                new Vehicle {Id=5, Price = 50000, Model = new Model() {Name = "Opel"}, City = new City() {Name="Burgas"}, Run = 10300, Engine = new Engine(){ Volume = 4000} },
                new Vehicle {Id=6, Price = 60000, Model = new Model() { Name = "BMW"}, City = new City() {Name="Velingrad"}, Run = 10000, Engine = new Engine(){ Volume = 2000}},
                new Vehicle {Id=7, Price = 70000, Model = new Model() {Name = "Audi"}, City = new City() {Name="Sofia"}, Run = 11000, Engine = new Engine(){ Volume = 2500} },
                new Vehicle {Id=8, Price = 80000, Model = new Model() {Name = "GF"}, City = new City() {Name="Veliko Tyrnovo"}, Run = 10400, Engine = new Engine(){ Volume = 2030} },
                new Vehicle {Id=9, Price = 90000,Model = new Model() {Name = "VW"}, City = new City() {Name="Pamporovo"}, Run = 10000, Engine = new Engine(){ Volume = 3000}  },
                new Vehicle {Id=10, Price = 100000, Model = new Model() {Name = "Opel"}, City = new City() {Name="Ahtopol"}, Run = 10300, Engine = new Engine(){ Volume = 4000} },
                new Vehicle {Id=11, Price = 110000,Model = new Model() {Name = "VW"}, City = new City() {Name="Dobrich"}, Run = 10000, Engine = new Engine(){ Volume = 3000}  },
                new Vehicle {Id=12, Price = 120000, Model = new Model() {Name = "Opel"}, City = new City() {Name="Ilinden"}, Run = 10300, Engine = new Engine(){ Volume = 4000} },
            }.AsQueryable();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestGetVehiclesFirstPage()
        {
            var data = new List<Vehicle>()
            {
                new Vehicle { Price = 10000, Model = new Model() { Name = "BMW" }, City = new City() { Name = "Blagoevgrad" }, Run = 10000, Engine = new Engine() { Volume = 2000 } },
                new Vehicle { Price = 20000, Model = new Model() { Name = "Audi" }, City = new City() { Name = "Pazarjik" }, Run = 11000, Engine = new Engine() { Volume = 2500 } },
                new Vehicle { Price = 30000, Model = new Model() { Name = "GF" }, City = new City() { Name = "Plovdiv" }, Run = 10400, Engine = new Engine() { Volume = 2030 } },

            }.AsQueryable();


            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();       
            mockContext.Setup(v => v.Vehicles).Returns(mockSet.Object);

            var service = new VehicleService(mockContext.Object);
            var vehicles = service.GetVehicles();

            Assert.AreEqual(10, vehicles.Vehicles.Count);
            Assert.AreEqual(1, vehicles.Vehicles.First().Id);
            Assert.AreEqual(2, vehicles.Vehicles.Skip(1).First().Id);
            Assert.AreEqual(3, vehicles.Vehicles.Skip(2).First().Id);
            Assert.AreEqual(10, vehicles.Vehicles.Last().Id);


        }
        [Test]
        public void TestGetTopExpensiveVehicles()
        {
       
               

           var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(v => v.Vehicles).Returns(mockSet.Object);

            var service = new VehicleService(mockContext.Object);
            var vehicles = service.GetTopExpensiveVehicles();

            Assert.AreEqual(6, vehicles.vehicleViewModels.Count);
            Assert.AreEqual(60000, vehicles.vehicleViewModels.Count);
            Assert.AreEqual(120000, vehicles.vehicleViewModels.First().Price);

        }
        [Test]
        public void TestGetLastAddedVehicles()
        {

            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(v => v.Vehicles).Returns(mockSet.Object);

            var service = new VehicleService(mockContext.Object);
            var vehicles = service.GetLastAddedVehicles();

            Assert.AreEqual(6, vehicles.vehicleViewModels.Count);
            Assert.AreEqual("Last Added", vehicles.vehicleViewModels.First().Model);
        }

        [Test]
        public void TestGetTopCheapestVehicles()
        {

            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(v => v.Vehicles).Returns(mockSet.Object);

            var service = new VehicleService(mockContext.Object);
            var vehicles = service.SearchByPrice();

            Assert.AreEqual(6, vehicles.vehicleViewModels.Count);
            Assert.AreEqual(10000, vehicles.vehicleViewModels.First().Price);
        }

        [Test]
        public void TestSearchByPrice()
        {


            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(v => v.Vehicles).Returns(mockSet.Object);

            var service = new VehicleService(mockContext.Object);
            var vehicles = service.SearchByPrice();

            Assert.AreEqual(12, vehicles.vehicleViewModels.Count);
            Assert.AreEqual(10000, vehicles.vehicleViewModels.First().Price);
            Assert.AreEqual(120000, vehicles.vehicleViewModels.Last().Price);
        }

        [Test]
        public void TestDelete()
        {
            var data = new List<Vehicle>
            {
                new Vehicle {Id=1 },
                new Vehicle {Id=2 },
                new Vehicle {Id=3 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Vehicle>>();
            var mockSetVehicle = new Mock<DbSet<ExtrasPackage>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(v => v.Vehicles).Returns(mockSet.Object);
            mockContext.Setup(v => v.Extras).Returns(mockSetVehicle.Object);


            var service = new VehicleService(mockContext.Object);
            var isDeleted = service.DeleteVehicle(5);

            Assert.AreEqual(false, isDeleted);

        }

        [Test]
        public void TestGetVehiclesSecondPage()
        {

            var mockSet = new Mock<DbSet<Vehicle>>();
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(v => v.Vehicles).Returns(mockSet.Object);

            var service = new VehicleService(mockContext.Object);
            var vehicles = service.GetVehicles(2);

            Assert.AreEqual(2, vehicles.Vehicles.Count);
            Assert.AreEqual(11, vehicles.Vehicles.First().Id);
            Assert.AreEqual(12, vehicles.Vehicles.Skip(1).First().Id);
  
        }



    }
}