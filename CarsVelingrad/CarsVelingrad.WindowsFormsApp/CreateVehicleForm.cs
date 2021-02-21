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
    public partial class CreateVehicleForm : Form
    {
        private readonly VehicleService vehicleService;
        private readonly WindowsFormService windowsFormService;

        public CreateVehicleForm(VehicleService vehicleService, WindowsFormService windowsFormService)
        {
            InitializeComponent();
            this.vehicleService = vehicleService;
            this.windowsFormService = windowsFormService;
        }

        private void CreateVehicleForm_Load_1(object sender, EventArgs e)
        {
            UpdateComboBoxItems();
        }

        private void UpdateComboBoxItems()
        {
            this.comboBoxBrand.Items.AddRange(windowsFormService.GetBrands());
            this.comboBoxModel.Items.AddRange(windowsFormService.GetModels());
        }

        private void ClearTextAndComboBoxes(System.Windows.Forms.Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                if (ctrl is ComboBox)
                    ((ComboBox)ctrl).Text = string.Empty;
                ClearTextAndComboBoxes(ctrl.Controls);
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                VehicleInputViewModel model = new VehicleInputViewModel()
                {
                    Brand = comboBoxBrand.Text,
                    Model = comboBoxModel.Text,
                    VehicleType = comboBoxVehicleType.Text,
                    EngineType = comboBoxEngineType.Text,
                    Color = textBoxColor.Text,
                    Price = int.Parse(textBoxPrice.Text),
                    HorsePower = int.Parse(textBoxHorsePower.Text),
                    EngineVolume = int.Parse(textBoxEngineVolume.Text),
                    Run = int.Parse(textBoxRun.Text),
                    City = textBoxCity.Text,
                    Country = textBoxCountry.Text,
                    Zipcode = int.Parse(comboBoxZipCode.Text)
                };

                this.vehicleService.Create(model);
                MessageBox.Show("Автомобилът е успешно добавен в базата от данни!");
                ClearTextAndComboBoxes(Controls);
                UpdateComboBoxItems();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
