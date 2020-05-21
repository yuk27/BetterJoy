namespace BetterJoyForCemu
{
    partial class Config3rdPartyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config3rdPartyForm));
            this.ControllerBtn = new System.Windows.Forms.Button();
            this.serial_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SnesRadio = new System.Windows.Forms.RadioButton();
            this.RightRadio = new System.Windows.Forms.RadioButton();
            this.LeftRadio = new System.Windows.Forms.RadioButton();
            this.ProRadio = new System.Windows.Forms.RadioButton();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControllerBtn
            // 
            this.ControllerBtn.BackgroundImage = global::BetterJoyForCemu.Properties.Resources.pro;
            this.ControllerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ControllerBtn.Location = new System.Drawing.Point(10, 10);
            this.ControllerBtn.Name = "ControllerBtn";
            this.ControllerBtn.Size = new System.Drawing.Size(123, 123);
            this.ControllerBtn.TabIndex = 2;
            this.ControllerBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ControllerBtn.UseVisualStyleBackColor = true;
            this.ControllerBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // serial_label
            // 
            this.serial_label.AutoSize = true;
            this.serial_label.Location = new System.Drawing.Point(22, 143);
            this.serial_label.Name = "serial_label";
            this.serial_label.Size = new System.Drawing.Size(80, 17);
            this.serial_label.TabIndex = 3;
            this.serial_label.Text = "serial_label";
            this.serial_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.serial_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SnesRadio);
            this.panel1.Controls.Add(this.RightRadio);
            this.panel1.Controls.Add(this.LeftRadio);
            this.panel1.Controls.Add(this.ProRadio);
            this.panel1.Location = new System.Drawing.Point(138, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 120);
            this.panel1.TabIndex = 4;
            // 
            // SnesRadio
            // 
            this.SnesRadio.AutoSize = true;
            this.SnesRadio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SnesRadio.Location = new System.Drawing.Point(7, 90);
            this.SnesRadio.Name = "SnesRadio";
            this.SnesRadio.Size = new System.Drawing.Size(65, 21);
            this.SnesRadio.TabIndex = 3;
            this.SnesRadio.TabStop = true;
            this.SnesRadio.Text = "Snes ";
            this.SnesRadio.UseVisualStyleBackColor = true;
            this.SnesRadio.CheckedChanged += new System.EventHandler(this.SnesRadio_CheckedChanged);
            // 
            // RightRadio
            // 
            this.RightRadio.AutoSize = true;
            this.RightRadio.Location = new System.Drawing.Point(7, 63);
            this.RightRadio.Name = "RightRadio";
            this.RightRadio.Size = new System.Drawing.Size(111, 21);
            this.RightRadio.TabIndex = 2;
            this.RightRadio.TabStop = true;
            this.RightRadio.Text = "Right Joycon";
            this.RightRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RightRadio.UseVisualStyleBackColor = true;
            this.RightRadio.CheckedChanged += new System.EventHandler(this.RightRadio_CheckedChanged);
            // 
            // LeftRadio
            // 
            this.LeftRadio.AutoSize = true;
            this.LeftRadio.Location = new System.Drawing.Point(7, 36);
            this.LeftRadio.Name = "LeftRadio";
            this.LeftRadio.Size = new System.Drawing.Size(102, 21);
            this.LeftRadio.TabIndex = 1;
            this.LeftRadio.TabStop = true;
            this.LeftRadio.Text = "Left Joycon";
            this.LeftRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LeftRadio.UseVisualStyleBackColor = true;
            this.LeftRadio.CheckedChanged += new System.EventHandler(this.LeftRadio_CheckedChanged);
            // 
            // ProRadio
            // 
            this.ProRadio.AutoSize = true;
            this.ProRadio.Location = new System.Drawing.Point(7, 9);
            this.ProRadio.Name = "ProRadio";
            this.ProRadio.Size = new System.Drawing.Size(116, 21);
            this.ProRadio.TabIndex = 0;
            this.ProRadio.TabStop = true;
            this.ProRadio.Text = "Pro Controller";
            this.ProRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProRadio.UseVisualStyleBackColor = true;
            this.ProRadio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Location = new System.Drawing.Point(193, 138);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(70, 29);
            this.ApplyBtn.TabIndex = 5;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // Config3rdPartyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 176);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.serial_label);
            this.Controls.Add(this.ControllerBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config3rdPartyForm";
            this.Text = "Config";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ControllerBtn;
        private System.Windows.Forms.Label serial_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton SnesRadio;
        private System.Windows.Forms.RadioButton RightRadio;
        private System.Windows.Forms.RadioButton LeftRadio;
        private System.Windows.Forms.RadioButton ProRadio;
        private System.Windows.Forms.Button ApplyBtn;
    }
}