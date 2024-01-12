namespace MovieNightOOD.Forms
{
    partial class MovieForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            cbSort = new ComboBox();
            label3 = new Label();
            cbYear = new ComboBox();
            label2 = new Label();
            btnRefresh = new Button();
            btnAdd = new Button();
            cbCategory = new ComboBox();
            label1 = new Label();
            btnSearch = new Button();
            tbSearch = new TextBox();
            dgvMovies = new DataGridView();
            btnDelete = new Button();
            btnEdit = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(cbSort);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbYear);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(tbSearch);
            groupBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1072, 195);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "SEARCH";
            // 
            // cbSort
            // 
            cbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSort.FormattingEnabled = true;
            cbSort.Items.AddRange(new object[] { "", "Rate ASC", "Rate DESC" });
            cbSort.Location = new Point(770, 130);
            cbSort.Name = "cbSort";
            cbSort.Size = new Size(118, 33);
            cbSort.TabIndex = 16;
            cbSort.SelectedIndexChanged += cbSort_SelectedIndexChanged;
            cbSort.Click += cbSort_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(664, 123);
            label3.Name = "label3";
            label3.Size = new Size(113, 37);
            label3.TabIndex = 15;
            label3.Text = "Sort by:";
            // 
            // cbYear
            // 
            cbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cbYear.FormattingEnabled = true;
            cbYear.Items.AddRange(new object[] { "" });
            cbYear.Location = new Point(535, 130);
            cbYear.Name = "cbYear";
            cbYear.Size = new Size(99, 33);
            cbYear.TabIndex = 14;
            cbYear.SelectedIndexChanged += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(463, 123);
            label2.Name = "label2";
            label2.Size = new Size(77, 37);
            label2.TabIndex = 13;
            label2.Text = "Year:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(117, 54, 112);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefresh.ForeColor = Color.WhiteSmoke;
            btnRefresh.Location = new Point(909, 122);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(137, 43);
            btnRefresh.TabIndex = 12;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += button1_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(117, 54, 112);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.WhiteSmoke;
            btnAdd.Location = new Point(26, 122);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 43);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "" });
            cbCategory.Location = new Point(303, 130);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(143, 33);
            cbCategory.TabIndex = 6;
            cbCategory.SelectedIndexChanged += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(173, 123);
            label1.Name = "label1";
            label1.Size = new Size(136, 37);
            label1.TabIndex = 5;
            label1.Text = "Category:";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(117, 54, 112);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.WhiteSmoke;
            btnSearch.Location = new Point(909, 55);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(137, 43);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            tbSearch.Location = new Point(26, 55);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(877, 43);
            tbSearch.TabIndex = 1;
            // 
            // dgvMovies
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMovies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMovies.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMovies.Location = new Point(38, 227);
            dgvMovies.Name = "dgvMovies";
            dgvMovies.RowTemplate.Height = 35;
            dgvMovies.RowTemplate.ReadOnly = true;
            dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovies.Size = new Size(1011, 412);
            dgvMovies.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(117, 54, 112);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.WhiteSmoke;
            btnDelete.Location = new Point(906, 645);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 43);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(117, 54, 112);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = Color.WhiteSmoke;
            btnEdit.Location = new Point(763, 645);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(137, 43);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // MovieForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1096, 700);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(dgvMovies);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MovieForm";
            Text = "MovieForm";
            Load += MovieForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbSearch;
        private ComboBox cbCategory;
        private Label label1;
        private Button btnSearch;
        public DataGridView dgvMovies;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnRefresh;
        private ComboBox cbYear;
        private Label label2;
        private ComboBox cbSort;
        private Label label3;
    }
}