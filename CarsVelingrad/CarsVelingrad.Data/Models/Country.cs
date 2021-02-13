namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;


    public class Country
    {
        public Country()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
