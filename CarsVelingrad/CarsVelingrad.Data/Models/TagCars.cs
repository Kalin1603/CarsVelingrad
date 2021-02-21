namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class TagCars
    {
        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
