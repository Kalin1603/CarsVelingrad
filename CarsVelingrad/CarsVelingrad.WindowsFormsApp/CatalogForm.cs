using CarsVelingrad.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarsVelingrad.WindowsFormsApp
{
    public partial class CatalogForm : Form
    {
        public CatalogForm()
        {
            InitializeComponent();
        }

        public CatalogForm(VehicleService vehicleServices)
        {
        }
    }
}
