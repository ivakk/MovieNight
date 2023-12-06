﻿namespace MovieNightOOD.Forms.MediaSubForms
{
    partial class AddMovieForm
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
            groupBox1 = new GroupBox();
            numRating = new NumericUpDown();
            tbImageLink = new TextBox();
            label2 = new Label();
            tbTitle = new TextBox();
            label9 = new Label();
            numYear = new NumericUpDown();
            tbCountry = new TextBox();
            tbTrailerLink = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label6 = new Label();
            label1 = new Label();
            btnAdd = new Button();
            label5 = new Label();
            tbDescription = new TextBox();
            cbCategory = new ComboBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(numRating);
            groupBox1.Controls.Add(tbImageLink);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbTitle);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(numYear);
            groupBox1.Controls.Add(tbCountry);
            groupBox1.Controls.Add(tbTrailerLink);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbDescription);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(504, 236);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(520, 506);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ADD A MOVIE";
            // 
            // numRating
            // 
            numRating.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            numRating.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numRating.Location = new Point(250, 228);
            numRating.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(201, 32);
            numRating.TabIndex = 44;
            // 
            // tbImageLink
            // 
            tbImageLink.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbImageLink.Location = new Point(151, 266);
            tbImageLink.Multiline = true;
            tbImageLink.Name = "tbImageLink";
            tbImageLink.Size = new Size(300, 34);
            tbImageLink.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(250, 203);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 43;
            label2.Text = "Rating";
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbTitle.Location = new Point(51, 103);
            tbTitle.Multiline = true;
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(400, 33);
            tbTitle.TabIndex = 42;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(51, 75);
            label9.Name = "label9";
            label9.Size = new Size(48, 25);
            label9.TabIndex = 41;
            label9.Text = "Title";
            // 
            // numYear
            // 
            numYear.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            numYear.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numYear.Location = new Point(51, 228);
            numYear.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(193, 32);
            numYear.TabIndex = 40;
            // 
            // tbCountry
            // 
            tbCountry.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbCountry.Location = new Point(250, 167);
            tbCountry.Multiline = true;
            tbCountry.Name = "tbCountry";
            tbCountry.Size = new Size(201, 33);
            tbCountry.TabIndex = 39;
            tbCountry.TextChanged += tbCountry_TextChanged;
            // 
            // tbTrailerLink
            // 
            tbTrailerLink.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbTrailerLink.Location = new Point(151, 309);
            tbTrailerLink.Multiline = true;
            tbTrailerLink.Name = "tbTrailerLink";
            tbTrailerLink.Size = new Size(300, 34);
            tbTrailerLink.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(51, 312);
            label7.Name = "label7";
            label7.Size = new Size(103, 25);
            label7.TabIndex = 37;
            label7.Text = "Trailer Link";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(51, 269);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 35;
            label4.Text = "Image Link";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(51, 203);
            label6.Name = "label6";
            label6.Size = new Size(48, 25);
            label6.TabIndex = 34;
            label6.Text = "Year";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(250, 139);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 33;
            label1.Text = "Country";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(117, 54, 112);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.WhiteSmoke;
            btnAdd.Location = new Point(314, 457);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 43);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(51, 337);
            label5.Name = "label5";
            label5.Size = new Size(108, 25);
            label5.TabIndex = 10;
            label5.Text = "Description";
            // 
            // tbDescription
            // 
            tbDescription.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbDescription.Location = new Point(51, 365);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(400, 86);
            tbDescription.TabIndex = 9;
            // 
            // cbCategory
            // 
            cbCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(51, 167);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(193, 33);
            cbCategory.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(51, 139);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 5;
            label3.Text = "Category";
            // 
            // AddMovieForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1450, 1000);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddMovieForm";
            Text = "AddProductForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbCategory;
        private Label label3;
        private Label label5;
        private TextBox tbDescription;
        private Button btnAdd;
        private NumericUpDown numRating;
        private Label label2;
        private TextBox tbTitle;
        private Label label9;
        private NumericUpDown numYear;
        private TextBox tbCountry;
        private TextBox tbTrailerLink;
        private Label label7;
        private TextBox tbImageLink;
        private Label label4;
        private Label label6;
        private Label label1;
    }
}