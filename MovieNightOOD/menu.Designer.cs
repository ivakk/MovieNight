﻿namespace MovieNightOOD
{
    partial class Menu
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
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            btnLogout = new Button();
            flpMenu = new FlowLayoutPanel();
            lbUserLetter = new Label();
            lbLastName = new Label();
            lbFirstName = new Label();
            btnCloseApp = new Button();
            pnlMainForm = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(flpMenu);
            panel1.Controls.Add(lbUserLetter);
            panel1.Controls.Add(lbLastName);
            panel1.Controls.Add(lbFirstName);
            panel1.Location = new Point(70, 53);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(371, 1333);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Silver;
            pictureBox2.Image = Properties.Resources.logo_movienight;
            pictureBox2.Location = new Point(97, 1256);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(178, 63);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(117, 54, 112);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.WhiteSmoke;
            btnLogout.Location = new Point(23, 1168);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(323, 80);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // flpMenu
            // 
            flpMenu.Location = new Point(23, 257);
            flpMenu.Margin = new Padding(3, 4, 3, 4);
            flpMenu.Name = "flpMenu";
            flpMenu.Size = new Size(331, 903);
            flpMenu.TabIndex = 4;
            flpMenu.Paint += flpMenu_Paint;
            // 
            // lbUserLetter
            // 
            lbUserLetter.AutoSize = true;
            lbUserLetter.BackColor = Color.FromArgb(117, 54, 112);
            lbUserLetter.Font = new Font("Segoe UI", 45F, FontStyle.Regular, GraphicsUnit.Point);
            lbUserLetter.ForeColor = SystemColors.ControlLightLight;
            lbUserLetter.Location = new Point(71, 80);
            lbUserLetter.Name = "lbUserLetter";
            lbUserLetter.Size = new Size(91, 81);
            lbUserLetter.TabIndex = 0;
            lbUserLetter.Text = "W";
            lbUserLetter.TextAlign = ContentAlignment.TopCenter;
            lbUserLetter.Click += lbUserLetter_Click;
            // 
            // lbLastName
            // 
            lbLastName.AutoSize = true;
            lbLastName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbLastName.Location = new Point(168, 121);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(77, 32);
            lbLastName.TabIndex = 2;
            lbLastName.Text = "White";
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbFirstName.Location = new Point(168, 89);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(82, 32);
            lbFirstName.TabIndex = 1;
            lbFirstName.Text = "Walter";
            lbFirstName.Click += lbFirstName_Click;
            // 
            // btnCloseApp
            // 
            btnCloseApp.BackColor = Color.FromArgb(255, 128, 128);
            btnCloseApp.FlatStyle = FlatStyle.Popup;
            btnCloseApp.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            btnCloseApp.Location = new Point(2154, 0);
            btnCloseApp.Margin = new Padding(3, 4, 3, 4);
            btnCloseApp.Name = "btnCloseApp";
            btnCloseApp.Size = new Size(51, 60);
            btnCloseApp.TabIndex = 1;
            btnCloseApp.Text = "X";
            btnCloseApp.UseVisualStyleBackColor = false;
            btnCloseApp.Click += btnCloseApp_Click;
            // 
            // pnlMainForm
            // 
            pnlMainForm.Location = new Point(474, 53);
            pnlMainForm.Margin = new Padding(3, 4, 3, 4);
            pnlMainForm.Name = "pnlMainForm";
            pnlMainForm.Size = new Size(1657, 1333);
            pnlMainForm.TabIndex = 2;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1924, 1061);
            Controls.Add(pnlMainForm);
            Controls.Add(btnCloseApp);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimizeBox = false;
            Name = "Menu";
            Text = "menu";
            WindowState = FormWindowState.Maximized;
            Load += menu_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbFirstName;
        private Label lbLastName;
        private Label lbUserLetter;
        private Button btnLogout;
        private FlowLayoutPanel flpMenu;
        private Button btnCloseApp;
        private PictureBox pictureBox2;
        public Panel pnlMainForm;
    }
}