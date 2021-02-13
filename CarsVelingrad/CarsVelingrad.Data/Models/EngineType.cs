namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class EngineType
    {
        public EngineType()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public double Type { get; set; }
               
        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}
