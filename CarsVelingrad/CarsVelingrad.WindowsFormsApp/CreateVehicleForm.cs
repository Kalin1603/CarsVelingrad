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

        private void CreateVehicleForm_Load(object sender, EventArgs e)
        {
            UpdateComboBoxItems();
        }

        private void UpdateComboBoxItems()
        {
            this.comboBoxBrand.Items.AddRange(windowsFormService.GetBrands());
            this.comboBoxModel.Items.AddRange(windowsFormService.GetModels());
            this.comboBoxVehicleType.Items.AddRange(windowsFormService.GetVehicleTypes());
            this.comboBoxEngineType.Items.AddRange(windowsFormService.GetEngineTypes());
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
                    Zipcode = int.Parse(textBoxZipcode.Text)
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

        private void checkBoxHasStabilityControl_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasStabilityControl.Checked = true;
        }

        private void checkBoxHasDVD_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasDVD.Checked = true;
        }

        private void checkBoxHasAllWheelDriveSystem_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasAllWheelDriveSystem.Checked = true;
        }

        private void checkBoxHasABS_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasABS.Checked = true;
        }

        private void checkBoxHasClimatronic_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasClimatronic.Checked = true;
        }

        private void checkBoxHasCruiseControl_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasCruiseControl.Checked = true;
        }

        private void checkBoxHasParkAssist_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasParkAssist.Checked = true;
        }

        private void checkBoxHasRadioBluetooth_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasRadioBluetooth.Checked = true;
        }

        private void checkBoxHasCentralLock_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasCentralLock.Checked = true;
        }

        private void checkBoxHasElectricWindows_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxHasElectricWindows.Checked = true;
        }
    }
}
