using CarsVelingrad.Services;
using CarsVelingrad.ViewModels;
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
        private readonly VehicleService vehicleServices;
        private VehiclesViewModel model; 

        public CatalogForm(VehicleService vehicleServices)
        {
            InitializeComponent();
            this.vehicleServices = vehicleServices;
        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
            model = vehicleServices.GetVehicles();
            FillDataGrid();
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }
        private void FillDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var vehicle in model.Vehicles)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone(); 
                row.Cells[0].Value = vehicle.Brand;
                row.Cells[1].Value = vehicle.Model;
                row.Cells[2].Value = vehicle.Price;
                row.Cells[3].Value = vehicle.AdvertDate;
                row.Cells[4].Value = vehicle.Run;
                row.Cells[5].Value = vehicle.City;
                this.dataGridView1.Rows.Add(row);
            }
            labelPageInfo.Text = $"Страница: {model.PageNumber} / {model.PagesCount}\nАвтомобили: {model.ElementsCount}";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (model.HasNextPage)
            {
                model = vehicleServices.GetVehicles(model.NextPageNumber);
                FillDataGrid();
            }        
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (model.HasPreviousPage)
            {
                model = vehicleServices.GetVehicles(model.PreviousPageNumber);
                FillDataGrid();
            }        
        }
    }
}
