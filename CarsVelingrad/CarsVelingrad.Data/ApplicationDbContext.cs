namespace CarsVelingrad.Data
{
    using CarsVelingrad.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext()
        {

        }

        public ApplicationDbContext( DbContextOptions options) 
            : base(options)
        {

        }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Engine> Engines { get; set; }

        public virtual DbSet<EngineType> EngineTypes { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<TagCars> TagCars { get; set; }

        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=CarsVelingradDb; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagCars>(entity =>
            {
                entity.HasKey(x => new { x.VehicleId, x.TagId });
            });
        }
    }
}
