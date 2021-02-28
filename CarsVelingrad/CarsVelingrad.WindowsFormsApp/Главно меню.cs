using CarsVelingrad.Data;
using CarsVelingrad.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarsVelingrad.WindowsFormsApp
{
    public partial class Main : Form
    {
        private readonly ApplicationDbContext dbContext;
        private readonly VehicleService vehicleServices;
        private readonly WindowsFormService windowsFormService;

        public Main()
        {
            InitializeComponent();
            this.dbContext = new ApplicationDbContext();
            this.vehicleServices = new VehicleService(this.dbContext);
            this.windowsFormService = new WindowsFormService(this.dbContext);
        }

        private void CreateVehicle_Click(object sender, EventArgs e)
        {
            CreateVehicleForm createForm = new CreateVehicleForm(this.vehicleServices,this.windowsFormService);
            createForm.Show();
        }

        private void buttonCatalog_Click(object sender, EventArgs e)
        {
            Каталог form = new Каталог(this.vehicleServices);
            form.Show();
        }

        
    }
}
