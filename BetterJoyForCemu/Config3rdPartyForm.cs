using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterJoyForCemu {
    public partial class Config3rdPartyForm : Form {

        enum controllerType : ushort {
            product_l = 0x2006,
            product_r = 0x2007,
            product_pro = 0x2009,
            product_snes = 0x2017
        }

        bool changed = false;

        Selector3rdPartyType selector;
        private Button ControllerBtn;
        private Panel panel1;
        private RadioButton SnesRadio;
        private RadioButton RightRadio;
        private RadioButton LeftRadio;
        private RadioButton ProRadio;
        private Label serial_label;
        private Button ApplyBtn;
        Joycon j;

        private void GetColor() {

            switch (j.battery) {
                case 4:
                    ControllerBtn.BackColor = System.Drawing.Color.FromArgb(0xAA, System.Drawing.Color.Green);
                    break;
                case 3:
                    ControllerBtn.BackColor = System.Drawing.Color.FromArgb(0xAA, System.Drawing.Color.Green);
                    break;
                case 2:
                    ControllerBtn.BackColor = System.Drawing.Color.FromArgb(0xAA, System.Drawing.Color.GreenYellow);
                    break;
                case 1:
                    ControllerBtn.BackColor = System.Drawing.Color.FromArgb(0xAA, System.Drawing.Color.Orange);
                    break;
                default:
                    ControllerBtn.BackColor = System.Drawing.Color.FromArgb(0xAA, System.Drawing.Color.Red);
                    break;
            }
        }

        public bool getStatus() {
            return changed;
        }

        public Config3rdPartyForm(Joycon j) {
            InitializeComponent();
            this.j = j;
            selector = new Selector3rdPartyType();
            GetColor();
            init();
        }

        void init() {
            selector.Load();
            serial_label.Text = j.serial_number;

            if (j.isPro) {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.pro;
                ProRadio.Checked = true;
            } else if (j.isSnes) {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.snes;
                SnesRadio.Checked = true;
            } else if (j.isLeft) {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_left;
                LeftRadio.Checked = true;
            } else {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_right;
                RightRadio.Checked = true;
            }

        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config3rdPartyForm));
            this.ControllerBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SnesRadio = new System.Windows.Forms.RadioButton();
            this.RightRadio = new System.Windows.Forms.RadioButton();
            this.LeftRadio = new System.Windows.Forms.RadioButton();
            this.ProRadio = new System.Windows.Forms.RadioButton();
            this.serial_label = new System.Windows.Forms.Label();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControllerBtn
            // 
            this.ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.pro;
            this.ControllerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ControllerBtn.Location = new System.Drawing.Point(12, 12);
            this.ControllerBtn.Name = "ControllerBtn";
            this.ControllerBtn.Size = new System.Drawing.Size(120, 120);
            this.ControllerBtn.TabIndex = 0;
            this.ControllerBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SnesRadio);
            this.panel1.Controls.Add(this.RightRadio);
            this.panel1.Controls.Add(this.LeftRadio);
            this.panel1.Controls.Add(this.ProRadio);
            this.panel1.Location = new System.Drawing.Point(138, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 120);
            this.panel1.TabIndex = 1;
            // 
            // SnesRadio
            // 
            this.SnesRadio.AutoSize = true;
            this.SnesRadio.Location = new System.Drawing.Point(3, 90);
            this.SnesRadio.Name = "SnesRadio";
            this.SnesRadio.Size = new System.Drawing.Size(61, 21);
            this.SnesRadio.TabIndex = 3;
            this.SnesRadio.TabStop = true;
            this.SnesRadio.Text = "Snes";
            this.SnesRadio.UseVisualStyleBackColor = true;
            this.SnesRadio.CheckedChanged += new System.EventHandler(this.SnesRadio_CheckedChanged_1);
            // 
            // RightRadio
            // 
            this.RightRadio.AutoSize = true;
            this.RightRadio.Location = new System.Drawing.Point(3, 63);
            this.RightRadio.Name = "RightRadio";
            this.RightRadio.Size = new System.Drawing.Size(88, 21);
            this.RightRadio.TabIndex = 2;
            this.RightRadio.TabStop = true;
            this.RightRadio.Text = "Right Joy";
            this.RightRadio.UseVisualStyleBackColor = true;
            this.RightRadio.CheckedChanged += new System.EventHandler(this.RightRadio_CheckedChanged_1);
            // 
            // LeftRadio
            // 
            this.LeftRadio.AutoSize = true;
            this.LeftRadio.Location = new System.Drawing.Point(3, 36);
            this.LeftRadio.Name = "LeftRadio";
            this.LeftRadio.Size = new System.Drawing.Size(79, 21);
            this.LeftRadio.TabIndex = 1;
            this.LeftRadio.TabStop = true;
            this.LeftRadio.Text = "Left Joy";
            this.LeftRadio.UseVisualStyleBackColor = true;
            this.LeftRadio.CheckedChanged += new System.EventHandler(this.LeftRadio_CheckedChanged_1);
            // 
            // ProRadio
            // 
            this.ProRadio.AutoSize = true;
            this.ProRadio.Location = new System.Drawing.Point(3, 9);
            this.ProRadio.Name = "ProRadio";
            this.ProRadio.Size = new System.Drawing.Size(51, 21);
            this.ProRadio.TabIndex = 0;
            this.ProRadio.TabStop = true;
            this.ProRadio.Text = "Pro";
            this.ProRadio.UseVisualStyleBackColor = true;
            this.ProRadio.CheckedChanged += new System.EventHandler(this.ProRadio_CheckedChanged_1);
            // 
            // serial_label
            // 
            this.serial_label.AutoSize = true;
            this.serial_label.Location = new System.Drawing.Point(12, 256);
            this.serial_label.Name = "serial_label";
            this.serial_label.Size = new System.Drawing.Size(0, 17);
            this.serial_label.TabIndex = 2;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Location = new System.Drawing.Point(197, 243);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(63, 30);
            this.ApplyBtn.TabIndex = 3;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click_1);
            // 
            // Config3rdPartyForm
            // 
            this.ClientSize = new System.Drawing.Size(272, 279);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.serial_label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ControllerBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config3rdPartyForm";
            this.Text = "BetterJoy";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ProRadio_CheckedChanged_1(object sender, EventArgs e) {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.pro;
        }

        private void LeftRadio_CheckedChanged_1(object sender, EventArgs e) {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_left;
        }

        private void RightRadio_CheckedChanged_1(object sender, EventArgs e) {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_right;
        }

        private void SnesRadio_CheckedChanged_1(object sender, EventArgs e) {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.snes;
        }

        private void ApplyBtn_Click_1(object sender, EventArgs e) {
            if (LeftRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_l);
            else if (RightRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_r);
            else if (ProRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_pro);
            else if (SnesRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_snes);
            changed = true;
            selector.Save();
        }
    }
}
