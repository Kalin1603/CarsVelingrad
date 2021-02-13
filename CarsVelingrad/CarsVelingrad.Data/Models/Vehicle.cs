namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Vehicle
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int? AdvertDate { get; set; }

        [Required]
        public int? Run { get; set; }

        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }

        public virtual Model Model { get; set; }
               
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [ForeignKey(nameof(VehicleType))]
        public int VehicleTypeId { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        [ForeignKey(nameof(Engine))]
        public int EngineId { get; set; }

        public virtual Engine Engine { get; set; }

        [ForeignKey(nameof(EngineType))]
        public int EngineTypeId { get; set; }

        public virtual EngineType EngineType { get; set; }
    }
}
