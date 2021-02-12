namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Vehicle
    {
        public Vehicle()
        {
            this.Locations = new HashSet<Location>();
        }

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

        public virtual Model District { get; set; }
               
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public virtual Brand PropertyType { get; set; }

        [ForeignKey(nameof(VehicleType))]
        public int VehicleTypeId { get; set; }

        public virtual VehicleType BuildingType { get; set; }
            
        public virtual ICollection<Location> Locations { get; set; }
    }
}
