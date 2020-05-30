using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsInput.Native;

namespace BetterJoyForCemu
{
    public partial class Config3rdPartyForm : Form
    {

        enum controllerType : ushort
        {
            product_l = 0x2006,
            product_r = 0x2007,
            product_pro = 0x2009,
            product_snes = 0x2017
        }

        bool changed = false;

        Selector3rdPartyType selector;
        private Button ControllerBtn;
        private Label serial_label;
        private Panel panel1;
        private RadioButton ProRadio;
        private RadioButton LeftRadio;
        private RadioButton SnesRadio;
        private RadioButton RightRadio;
        private Button ApplyBtn;
        Joycon j;

        Thread th;
        Graphics g;
        Graphics g2;
        PointF point_size = new PointF(60, 60);
        private PictureBox LeftJoystick;
        private Label LeftJoyOutput;
        private Label RightJoyOutput;
        bool drawing = true;

        UInt16[] calib;
        UInt16[] calib2;
        float[] current = new float[2];
        float[] current2 = new float[2];
        private PictureBox RightJoystick;
        RectangleF r;

        private void GetColor()
        {

            switch (j.battery)
            {
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

        public bool getStatus()
        {
            return changed;
        }

        public Config3rdPartyForm(Joycon j)
        {
            InitializeComponent();
            this.j = j;
            selector = new Selector3rdPartyType();
            GetColor();
            init();
        }

        void init() {
            selector.Load();
            serial_label.Text = j.serial_number;

            if (j.isPro)
            {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.pro;
                ProRadio.Checked = true;
                RightJoystick.Enabled = true;
                RightJoystick.BackColor = Color.White;
            }
            else if (j.isSnes) {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.snes;
                SnesRadio.Checked = true;
                RightJoystick.Enabled = false;
                RightJoystick.BackColor = Color.Gray;
            }
            else if (j.isLeft)
            {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_left;
                LeftRadio.Checked = true;
                RightJoystick.Enabled = false;
                RightJoystick.BackColor = Color.Gray;
            }
            else
            {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_right;
                RightRadio.Checked = true;
                RightJoystick.Enabled = false;
                RightJoystick.BackColor = Color.Gray;
            }

        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config3rdPartyForm));
            this.ControllerBtn = new System.Windows.Forms.Button();
            this.serial_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SnesRadio = new System.Windows.Forms.RadioButton();
            this.RightRadio = new System.Windows.Forms.RadioButton();
            this.LeftRadio = new System.Windows.Forms.RadioButton();
            this.ProRadio = new System.Windows.Forms.RadioButton();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.LeftJoystick = new System.Windows.Forms.PictureBox();
            this.LeftJoyOutput = new System.Windows.Forms.Label();
            this.RightJoyOutput = new System.Windows.Forms.Label();
            this.RightJoystick = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftJoystick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightJoystick)).BeginInit();
            this.SuspendLayout();
            // 
            // ControllerBtn
            // 
            this.ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.pro;
            this.ControllerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ControllerBtn.Location = new System.Drawing.Point(8, 13);
            this.ControllerBtn.Name = "ControllerBtn";
            this.ControllerBtn.Size = new System.Drawing.Size(94, 94);
            this.ControllerBtn.TabIndex = 0;
            this.ControllerBtn.UseVisualStyleBackColor = true;
            // 
            // serial_label
            // 
            this.serial_label.AutoSize = true;
            this.serial_label.Location = new System.Drawing.Point(12, 237);
            this.serial_label.Name = "serial_label";
            this.serial_label.Size = new System.Drawing.Size(35, 13);
            this.serial_label.TabIndex = 1;
            this.serial_label.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SnesRadio);
            this.panel1.Controls.Add(this.RightRadio);
            this.panel1.Controls.Add(this.LeftRadio);
            this.panel1.Controls.Add(this.ProRadio);
            this.panel1.Location = new System.Drawing.Point(106, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 94);
            this.panel1.TabIndex = 2;
            // 
            // SnesRadio
            // 
            this.SnesRadio.AutoSize = true;
            this.SnesRadio.Location = new System.Drawing.Point(3, 65);
            this.SnesRadio.Name = "SnesRadio";
            this.SnesRadio.Size = new System.Drawing.Size(49, 17);
            this.SnesRadio.TabIndex = 3;
            this.SnesRadio.TabStop = true;
            this.SnesRadio.Text = "Snes";
            this.SnesRadio.UseVisualStyleBackColor = true;
            this.SnesRadio.CheckedChanged += new System.EventHandler(this.SnesRadio_CheckedChanged);
            // 
            // RightRadio
            // 
            this.RightRadio.AutoSize = true;
            this.RightRadio.Location = new System.Drawing.Point(3, 44);
            this.RightRadio.Name = "RightRadio";
            this.RightRadio.Size = new System.Drawing.Size(69, 17);
            this.RightRadio.TabIndex = 2;
            this.RightRadio.TabStop = true;
            this.RightRadio.Text = "Right Joy";
            this.RightRadio.UseVisualStyleBackColor = true;
            this.RightRadio.CheckedChanged += new System.EventHandler(this.RightRadio_CheckedChanged);
            // 
            // LeftRadio
            // 
            this.LeftRadio.AutoSize = true;
            this.LeftRadio.Location = new System.Drawing.Point(3, 23);
            this.LeftRadio.Name = "LeftRadio";
            this.LeftRadio.Size = new System.Drawing.Size(62, 17);
            this.LeftRadio.TabIndex = 1;
            this.LeftRadio.TabStop = true;
            this.LeftRadio.Text = "Left Joy";
            this.LeftRadio.UseVisualStyleBackColor = true;
            this.LeftRadio.CheckedChanged += new System.EventHandler(this.LeftRadio_CheckedChanged);
            // 
            // ProRadio
            // 
            this.ProRadio.AutoSize = true;
            this.ProRadio.Location = new System.Drawing.Point(3, 3);
            this.ProRadio.Name = "ProRadio";
            this.ProRadio.Size = new System.Drawing.Size(41, 17);
            this.ProRadio.TabIndex = 0;
            this.ProRadio.TabStop = true;
            this.ProRadio.Text = "Pro";
            this.ProRadio.UseVisualStyleBackColor = true;
            this.ProRadio.CheckedChanged += new System.EventHandler(this.ProRadio_CheckedChanged);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Location = new System.Drawing.Point(141, 231);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(54, 24);
            this.ApplyBtn.TabIndex = 3;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // LeftJoystick
            // 
            this.LeftJoystick.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LeftJoystick.BackgroundImage")));
            this.LeftJoystick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeftJoystick.Location = new System.Drawing.Point(8, 112);
            this.LeftJoystick.Name = "LeftJoystick";
            this.LeftJoystick.Size = new System.Drawing.Size(94, 94);
            this.LeftJoystick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LeftJoystick.TabIndex = 6;
            this.LeftJoystick.TabStop = false;
            // 
            // LeftJoyOutput
            // 
            this.LeftJoyOutput.AutoSize = true;
            this.LeftJoyOutput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftJoyOutput.Location = new System.Drawing.Point(27, 208);
            this.LeftJoyOutput.Name = "LeftJoyOutput";
            this.LeftJoyOutput.Size = new System.Drawing.Size(58, 13);
            this.LeftJoyOutput.TabIndex = 7;
            this.LeftJoyOutput.Text = "(0.00,0.00)";
            this.LeftJoyOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RightJoyOutput
            // 
            this.RightJoyOutput.AutoSize = true;
            this.RightJoyOutput.Location = new System.Drawing.Point(124, 207);
            this.RightJoyOutput.Name = "RightJoyOutput";
            this.RightJoyOutput.Size = new System.Drawing.Size(58, 13);
            this.RightJoyOutput.TabIndex = 8;
            this.RightJoyOutput.Text = "(0.00,0.00)";
            this.RightJoyOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RightJoystick
            // 
            this.RightJoystick.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RightJoystick.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RightJoystick.BackgroundImage")));
            this.RightJoystick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RightJoystick.Location = new System.Drawing.Point(106, 112);
            this.RightJoystick.Name = "RightJoystick";
            this.RightJoystick.Size = new System.Drawing.Size(94, 94);
            this.RightJoystick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RightJoystick.TabIndex = 9;
            this.RightJoystick.TabStop = false;
            // 
            // Config3rdPartyForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(207, 259);
            this.Controls.Add(this.RightJoystick);
            this.Controls.Add(this.RightJoyOutput);
            this.Controls.Add(this.LeftJoyOutput);
            this.Controls.Add(this.LeftJoystick);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.serial_label);
            this.Controls.Add(this.ControllerBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config3rdPartyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Config3rdPartyForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftJoystick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightJoystick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ApplyBtn_Click(object sender, EventArgs e) {
            if (LeftRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_l, calib, calib2);
            else if (RightRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_r, calib, calib2);
            else if (ProRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_pro, calib, calib2);
            else if (SnesRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_snes, calib, calib2);
            changed = true;
            selector.Save();
        }

        private void ProRadio_CheckedChanged(object sender, EventArgs e) {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.pro;
            RightJoystick.Enabled = true;
        }

        private void LeftRadio_CheckedChanged(object sender, EventArgs e) {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_left;
            RightJoystick.Enabled = false;
        }

        private void RightRadio_CheckedChanged(object sender, EventArgs e) {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_right;
            RightJoystick.Enabled = false;
        }

        private void SnesRadio_CheckedChanged(object sender, EventArgs e) {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.snes;
            RightJoystick.Enabled = false;
        }

        public void Draw() {

            while (drawing) {
                r = UpdatePoints(j.GetRawStick()[0], j.GetRawStick()[1]);
                g.FillEllipse(Brushes.Red, r);

                try {
                    this.LeftJoyOutput.BeginInvoke((MethodInvoker)delegate () { this.LeftJoyOutput.Text = "(" + String.Format("{0:0.00}", current[0]) + "," + String.Format("{0:0.00}", current[1]) + ")"; ; });
                    this.LeftJoystick.BeginInvoke((MethodInvoker)delegate () { this.LeftJoystick.Refresh(); ; });
                } catch(System.InvalidOperationException) {
                    drawing = false;
                    break;
                }
                if (RightJoystick.Enabled) {
                    r = UpdatePoints2(j.GetRawStick2()[0], j.GetRawStick2()[1]);
                    g2.FillEllipse(Brushes.Red, r);
                    try {
                        this.RightJoyOutput.BeginInvoke((MethodInvoker)delegate () { this.RightJoyOutput.Text = "(" + String.Format("{0:0.00}", current2[0]) + "," + String.Format("{0:0.00}", current2[1]) + ")"; ; });
                        this.RightJoystick.BeginInvoke((MethodInvoker)delegate () { this.RightJoystick.Refresh(); ; });
                    } catch (System.InvalidOperationException) {
                        drawing = false;
                        break;
                    }
                }

                Thread.Sleep(30);

            }

        }

        public RectangleF UpdatePoints(UInt16 x, UInt16 y) {

            if (x > calib[0]) {
                calib[0] = x;  // 2048 -- 0,4095
            } else if (x < calib[1]) {
                calib[1] = x;
            }

            if (y > calib[2]) {
                calib[2] = y; // 2047 -- 0,4094
            } else if (y < calib[3]) {
                calib[3] = y;
            }

            float radius = (768 / 2) - point_size.X / 2;

            float x_f = x - calib[1];
            float y_f = y - calib[3];

            float x_s = calib[0] - calib[1];
            float y_s = calib[2] - calib[3];

            float x_input = x_f / x_s * 2 - 1;
            float y_input = y_f / y_s * 2 - 1;

            current[0] = x_input;
            current[1] = y_input;

            return GetCirclePosition(radius, x_input, y_input);
        }

        public RectangleF UpdatePoints2(UInt16 x, UInt16 y) {

            if (x > calib2[0]) {
                calib2[0] = x;  // 2048 -- 0,4095
            } else if (x < calib2[1]) {
                calib2[1] = x;
            }

            if (y > calib2[2]) {
                calib2[2] = y; // 2047 -- 0,4094
            } else if (y < calib2[3]) {
                calib2[3] = y;
            }

            float radius = (768 / 2) - point_size.X / 2;

            float x_f = x - calib2[1];
            float y_f = y - calib2[3];

            float x_s = calib2[0] - calib2[1];
            float y_s = calib2[2] - calib2[3];

            float x_input = x_f / x_s * 2 - 1;
            float y_input = y_f / y_s * 2 - 1;

            current2[0] = x_input;
            current2[1] = y_input;

            return GetCirclePosition(radius, x_input, y_input);
        }

        RectangleF GetCirclePosition(float r, float x, float y) {
            return new RectangleF(r + (r * x), r + (-r * y), point_size.X, point_size.Y);
        }

        private void Config3rdPartyForm_Load(object sender, EventArgs e) {

            calib = j.GetCustomCalib();
            calib2 = j.GetCustomCalib2();

            g = Graphics.FromImage(LeftJoystick.BackgroundImage);
            g2 = Graphics.FromImage(RightJoystick.BackgroundImage);
            th = new Thread(Draw);
            th.IsBackground = true;
            th.Start();
        }

        private void Config3rdPartyForm_FormClosing(object sender, EventArgs e) {
            drawing = false;
        }

        /*private void center_range_MouseClick(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Right) {
                    //(this.center_range.Image.Size.Width + 10, this.center_range.Image.Size.Height +10);
                this.center_range.Size = new System.Drawing.Size(this.center_range.Size.Width - 10, this.center_range.Size.Height - 10);
            } else {
                this.center_range.Size = new System.Drawing.Size(this.center_range.Size.Width + 10, this.center_range.Size.Height + 10);
            }

        }*/
    }
}
