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
            this.Engines = new HashSet<Engine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
               
        public virtual ICollection<Engine> Engines { get; set; }

    }
}
