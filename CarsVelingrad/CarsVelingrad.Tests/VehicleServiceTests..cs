using CarsVelingrad.Data;
using CarsVelingrad.Data.Models;
using CarsVelingrad.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CarsVelingrad.Tests
{
    public class VehicleServiceTests
    {
        IQueryable<Vehicle> data = new List<Vehicle>
            {
                new Vehicle {Id=1, Price = 15000, },
                new Vehicle {Id=2, Price = 25000,  },
                new Vehicle {Id=3, Price = 55000,  },
                new Vehicle {Id=4, Price = 125000,  },
                new Vehicle {Id=5, Price = 65000,  },
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