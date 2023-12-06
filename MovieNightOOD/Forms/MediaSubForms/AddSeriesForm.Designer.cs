namespace MovieNightOOD.Forms.MediaSubForms
{
    partial class AddSeriesForm
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
            label10 = new Label();
            tbTitle = new TextBox();
            label9 = new Label();
            numYear = new NumericUpDown();
            numEpisode = new NumericUpDown();
            numSeason = new NumericUpDown();
            label8 = new Label();
            label2 = new Label();
            tbCountry = new TextBox();
            tbTrailerLink = new TextBox();
            label7 = new Label();
            tbImageLink = new TextBox();
            label4 = new Label();
            btnAdd = new Button();
            label6 = new Label();
            label5 = new Label();
            tbDescription = new TextBox();
            cbCategory = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEpisode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeason).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(numRating);
            groupBox1.Controls.Add(tbImageLink);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tbTitle);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(numYear);
            groupBox1.Controls.Add(numEpisode);
            groupBox1.Controls.Add(numSeason);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbCountry);
            groupBox1.Controls.Add(tbTrailerLink);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbDescription);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(504, 236);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(520, 506);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ADD SERIES";
            // 
            // numRating
            // 
            numRating.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            numRating.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numRating.Location = new Point(115, 451);
            numRating.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(52, 32);
            numRating.TabIndex = 34;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(51, 451);
            label10.Name = "label10";
            label10.Size = new Size(66, 25);
            label10.TabIndex = 33;
            label10.Text = "Rating";
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbTitle.Location = new Point(51, 92);
            tbTitle.Multiline = true;
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(400, 33);
            tbTitle.TabIndex = 32;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(51, 64);
            label9.Name = "label9";
            label9.Size = new Size(48, 25);
            label9.TabIndex = 31;
            label9.Text = "Title";
            // 
            // numYear
            // 
            numYear.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            numYear.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numYear.Location = new Point(314, 220);
            numYear.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(137, 32);
            numYear.TabIndex = 30;
            // 
            // numEpisode
            // 
            numEpisode.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            numEpisode.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numEpisode.Location = new Point(184, 220);
            numEpisode.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numEpisode.Name = "numEpisode";
            numEpisode.Size = new Size(108, 32);
            numEpisode.TabIndex = 29;
            // 
            // numSeason
            // 
            numSeason.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            numSeason.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numSeason.Location = new Point(51, 220);
            numSeason.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            numSeason.Name = "numSeason";
            numSeason.Size = new Size(108, 32);
            numSeason.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(184, 192);
            label8.Name = "label8";
            label8.Size = new Size(78, 25);
            label8.TabIndex = 23;
            label8.Text = "Episode";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(51, 192);
            label2.Name = "label2";
            label2.Size = new Size(72, 25);
            label2.TabIndex = 21;
            label2.Text = "Season";
            // 
            // tbCountry
            // 
            tbCountry.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbCountry.Location = new Point(250, 156);
            tbCountry.Multiline = true;
            tbCountry.Name = "tbCountry";
            tbCountry.Size = new Size(201, 33);
            tbCountry.TabIndex = 19;
            // 
            // tbTrailerLink
            // 
            tbTrailerLink.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbTrailerLink.Location = new Point(151, 297);
            tbTrailerLink.Multiline = true;
            tbTrailerLink.Name = "tbTrailerLink";
            tbTrailerLink.Size = new Size(300, 33);
            tbTrailerLink.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(51, 300);
            label7.Name = "label7";
            label7.Size = new Size(103, 25);
            label7.TabIndex = 17;
            label7.Text = "Trailer Link";
            // 
            // tbImageLink
            // 
            tbImageLink.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbImageLink.Location = new Point(151, 258);
            tbImageLink.Multiline = true;
            tbImageLink.Name = "tbImageLink";
            tbImageLink.Size = new Size(300, 33);
            tbImageLink.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(51, 261);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 15;
            label4.Text = "Image Link";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(314, 192);
            label6.Name = "label6";
            label6.Size = new Size(48, 25);
            label6.TabIndex = 12;
            label6.Text = "Year";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(51, 331);
            label5.Name = "label5";
            label5.Size = new Size(108, 25);
            label5.TabIndex = 10;
            label5.Text = "Description";
            // 
            // tbDescription
            // 
            tbDescription.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbDescription.Location = new Point(51, 359);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(400, 86);
            tbDescription.TabIndex = 9;
            // 
            // cbCategory
            // 
            cbCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(51, 156);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(193, 33);
            cbCategory.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(51, 128);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 5;
            label3.Text = "Category";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(250, 128);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 0;
            label1.Text = "Country";
            // 
            // AddSeriesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1450, 1000);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddSeriesForm";
            Text = "AddProductForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEpisode).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeason).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cbCategory;
        private Label label3;
        private Label label5;
        private TextBox tbDescription;
        private Label label6;
        private Button btnAdd;
        private Label label4;
        private TextBox tbImageLink;
        private TextBox tbCountry;
        private TextBox tbTrailerLink;
        private Label label7;
        private Label label2;
        private Label label8;
        private NumericUpDown numYear;
        private NumericUpDown numEpisode;
        private NumericUpDown numSeason;
        private TextBox tbTitle;
        private Label label9;
        private NumericUpDown numRating;
        private Label label10;
    }
}