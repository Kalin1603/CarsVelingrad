using CarsVelingrad.Data;
using CarsVelingrad.Data.Models;
using CarsVelingrad.Services;
using Microsoft.EntityFrameworkCore;
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
                new Vehicle {Id=1, Price = 15000, Model = new Model() { Name = "BMW"}, City = new City() {Name="Blagoevgrad"}, Run = 10000, Engine = new Engine(){ Volume = 2000}},
                new Vehicle {Id=2, Price = 25000, Model = new Model() {Name = "Audi"}, City = new City() {Name="Pazarjik"}, Run = 11000, Engine = new Engine(){ Volume = 2500} },
                new Vehicle {Id=3, Price = 55000, Model = new Model() {Name = "GF"}, City = new City() {Name="Plovdiv"}, Run = 10400, Engine = new Engine(){ Volume = 2030} },
                new Vehicle {Id=4, Price = 125000,Model = new Model() {Name = "VW"}, City = new City() {Name="Varna"}, Run = 10000, Engine = new Engine(){ Volume = 3000}  },
                new Vehicle {Id=5, Price = 65000, Model = new Model() {Name = "Opel"}, City = new City() {Name="Burgas"}, Run = 10300, Engine = new Engine(){ Volume = 4000} },
            }.AsQueryable();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestDeleteVehicle()
        {
            var mockSet = new Mock<DbSet<Vehicle>>();

            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(p => p.Vehicles).Returns(mockSet.Object);

            var service = new VehicleService(mockContext.Object);
            var isDeleted = service.DeleteVehicle(5);

            Assert.AreEqual(true, isDeleted);
        }
    }
}