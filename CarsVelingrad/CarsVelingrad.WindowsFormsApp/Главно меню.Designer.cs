
namespace CarsVelingrad.WindowsFormsApp
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.CreateVehicle = new System.Windows.Forms.Button();
            this.buttonCatalog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(321, 28);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Cars Velingrad";
            // 
            // CreateVehicle
            // 
            this.CreateVehicle.Location = new System.Drawing.Point(12, 101);
            this.CreateVehicle.Name = "CreateVehicle";
            this.CreateVehicle.Size = new System.Drawing.Size(174, 115);
            this.CreateVehicle.TabIndex = 1;
            this.CreateVehicle.Text = "Добави автомобил в автокъщата";
            this.CreateVehicle.UseVisualStyleBackColor = true;
            this.CreateVehicle.Click += new System.EventHandler(this.CreateVehicle_Click);
            // 
            // buttonCatalog
            // 
            this.buttonCatalog.Location = new System.Drawing.Point(226, 101);
            this.buttonCatalog.Name = "buttonCatalog";
            this.buttonCatalog.Size = new System.Drawing.Size(168, 115);
            this.buttonCatalog.TabIndex = 2;
            this.buttonCatalog.Text = "Каталог за автомобили";
            this.buttonCatalog.UseVisualStyleBackColor = true;
            this.buttonCatalog.Click += new System.EventHandler(this.buttonCatalog_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 585);
            this.Controls.Add(this.buttonCatalog);
            this.Controls.Add(this.CreateVehicle);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Main";
            this.Text = "Главно меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button CreateVehicle;
        private System.Windows.Forms.Button buttonCatalog;
    }
}

