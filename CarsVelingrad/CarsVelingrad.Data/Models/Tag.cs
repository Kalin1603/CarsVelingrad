namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Tag
    {
        public Tag()
        {
            this.Tags = new HashSet<TagCars>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Discription { get; set; }

        public virtual ICollection<TagCars> Tags { get; set; }
    }
}
