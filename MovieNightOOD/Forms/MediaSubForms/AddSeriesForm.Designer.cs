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
            cbRating = new ComboBox();
            cbCountry = new ComboBox();
            tbImageLink = new TextBox();
            label10 = new Label();
            tbTitle = new TextBox();
            label9 = new Label();
            numYear = new NumericUpDown();
            numEpisode = new NumericUpDown();
            numSeason = new NumericUpDown();
            label8 = new Label();
            label2 = new Label();
            tbTrailerLink = new TextBox();
            label7 = new Label();
            label4 = new Label();
            btnAdd = new Button();
            label6 = new Label();
            label5 = new Label();
            tbDescription = new TextBox();
            cbCategory = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEpisode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeason).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(cbRating);
            groupBox1.Controls.Add(cbCountry);
            groupBox1.Controls.Add(tbImageLink);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tbTitle);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(numYear);
            groupBox1.Controls.Add(numEpisode);
            groupBox1.Controls.Add(numSeason);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label2);
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
            // cbRating
            // 
            cbRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRating.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbRating.FormattingEnabled = true;
            cbRating.Items.AddRange(new object[] { "", "1", "2", "3", "4", "5" });
            cbRating.Location = new Point(123, 451);
            cbRating.Name = "cbRating";
            cbRating.Size = new Size(52, 33);
            cbRating.TabIndex = 47;
            // 
            // cbCountry
            // 
            cbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountry.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbCountry.FormattingEnabled = true;
            cbCountry.Items.AddRange(new object[] { "", "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Anguilla", "Antigua &amp; Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia &amp; Herzegovina", "Botswana", "Brazil", "British Virgin Islands", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Cape Verde", "Cayman Islands", "Chad", "Chile", "China", "Colombia", "Congo", "Cook Islands", "Costa Rica", "Cote D Ivoire", "Croatia", "Cruise Ship", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Estonia", "Ethiopia", "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France", "French Polynesia", "French West Indies", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Isle of Man", "Israel", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kuwait", "Kyrgyz Republic", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Mauritania", "Mauritius", "Mexico", "Moldova", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Namibia", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russia", "Rwanda", "Saint Pierre &amp; Miquelon", "Samoa", "San Marino", "Satellite", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "South Africa", "South Korea", "Spain", "Sri Lanka", "St Kitts &amp; Nevis", "St Lucia", "St Vincent", "St. Lucia", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor L'Este", "Togo", "Tonga", "Trinidad &amp; Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks &amp; Caicos", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Uruguay", "Uzbekistan", "Venezuela", "Vietnam", "Virgin Islands (US)", "Yemen", "Zambia", "Zimbabwe" });
            cbCountry.Location = new Point(250, 156);
            cbCountry.Name = "cbCountry";
            cbCountry.Size = new Size(201, 33);
            cbCountry.TabIndex = 46;
            // 
            // tbImageLink
            // 
            tbImageLink.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbImageLink.Location = new Point(173, 269);
            tbImageLink.Multiline = true;
            tbImageLink.Name = "tbImageLink";
            tbImageLink.Size = new Size(278, 33);
            tbImageLink.TabIndex = 16;
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
            label9.Size = new Size(61, 25);
            label9.TabIndex = 31;
            label9.Text = "Title *";
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
            label8.Size = new Size(91, 25);
            label8.TabIndex = 23;
            label8.Text = "Episode *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(51, 192);
            label2.Name = "label2";
            label2.Size = new Size(85, 25);
            label2.TabIndex = 21;
            label2.Text = "Season *";
            // 
            // tbTrailerLink
            // 
            tbTrailerLink.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbTrailerLink.Location = new Point(173, 308);
            tbTrailerLink.Multiline = true;
            tbTrailerLink.Name = "tbTrailerLink";
            tbTrailerLink.Size = new Size(278, 33);
            tbTrailerLink.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(51, 311);
            label7.Name = "label7";
            label7.Size = new Size(116, 25);
            label7.TabIndex = 17;
            label7.Text = "Trailer Link *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(51, 272);
            label4.Name = "label4";
            label4.Size = new Size(116, 25);
            label4.TabIndex = 15;
            label4.Text = "Image Link *";
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
            label6.Size = new Size(61, 25);
            label6.TabIndex = 12;
            label6.Text = "Year *";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(51, 344);
            label5.Name = "label5";
            label5.Size = new Size(121, 25);
            label5.TabIndex = 10;
            label5.Text = "Description *";
            // 
            // tbDescription
            // 
            tbDescription.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbDescription.Location = new Point(51, 372);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(400, 73);
            tbDescription.TabIndex = 9;
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "" });
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
            label3.Size = new Size(101, 25);
            label3.TabIndex = 5;
            label3.Text = "Category *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(250, 128);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 0;
            label1.Text = "Country *";
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
        private TextBox tbTrailerLink;
        private Label label7;
        private Label label2;
        private Label label8;
        private NumericUpDown numYear;
        private NumericUpDown numEpisode;
        private NumericUpDown numSeason;
        private TextBox tbTitle;
        private Label label9;
        private Label label10;
        private ComboBox cbCountry;
        private ComboBox cbRating;
    }
}