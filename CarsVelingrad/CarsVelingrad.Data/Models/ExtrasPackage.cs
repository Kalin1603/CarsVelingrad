﻿namespace CarsVelingrad.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class ExtrasPackage
    {
        [Key]
        public int Id { get; set; }

        public bool HasDVD { get; set; }

        public bool HasAllWheelDriveSystem { get; set; }

        public bool HasStabilityControl { get; set; }

        public bool HasABS { get; set; }

        public bool HasClimatronic { get; set; }

        public bool HasCruiseControl { get; set; }

        public bool HasParkAssist { get; set; }

        public bool HasRadioBluetooth { get; set; }

        public bool HasCentralLock { get; set; }

        public bool HasElectricWindows { get; set; }


        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
