namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using System.ComponentModel.DataAnnotations;




    public class Location
    {
        public Location()
        {
            this.Locations = new HashSet<Location>();
        }

        [Key]
        public string CityId { get; set; }

        [Key]
        public string CountryId { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
