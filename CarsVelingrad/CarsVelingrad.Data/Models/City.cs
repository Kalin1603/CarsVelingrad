namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    public class City
    {
        public City()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ZipCode { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
