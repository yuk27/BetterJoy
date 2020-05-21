using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        Joycon j;

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
            }
            else if (j.isSnes) {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.snes;
                SnesRadio.Checked = true;
            }
            else if (j.isLeft)
            {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_left;
                LeftRadio.Checked = true;
            }
            else
            {
                ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_right;
                RightRadio.Checked = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.pro;
        }

        private void LeftRadio_CheckedChanged(object sender, EventArgs e)
        {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_left;
        }

        private void RightRadio_CheckedChanged(object sender, EventArgs e)
        {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.jc_right;
        }

        private void SnesRadio_CheckedChanged(object sender, EventArgs e)
        {
            ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.snes;
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            if (LeftRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_l);
            else if (RightRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_r);
            else if (ProRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_pro);
            else if (SnesRadio.Checked) selector.Add(j.serial_number, (ushort)controllerType.product_snes);
            changed = true;
            selector.Save();
        }

    }
}
