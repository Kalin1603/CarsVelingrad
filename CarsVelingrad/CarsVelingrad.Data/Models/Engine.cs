namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Engine
    {
        public Engine()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public double Volume { get; set; }

        [Required]
        public int HorsePower { get; set; }

        [ForeignKey(nameof(EngineType))]
        public int EngineTypeId { get; set; }

        public virtual EngineType EngineType { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}
