namespace MovieNightOOD.Forms
{
    partial class SeriesForm
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
            btnRefresh = new Button();
            btnAdd = new Button();
            cbCategory = new ComboBox();
            label1 = new Label();
            btnSearch = new Button();
            tbSearch = new TextBox();
            dgvSeries = new DataGridView();
            btnDelete = new Button();
            btnEdit = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSeries).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightGray;
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(tbSearch);
            groupBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1410, 195);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "SEARCH";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(117, 54, 112);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefresh.ForeColor = Color.WhiteSmoke;
            btnRefresh.Location = new Point(1258, 122);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(137, 43);
            btnRefresh.TabIndex = 16;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
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
            cbCategory.Location = new Point(299, 130);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(203, 33);
            cbCategory.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(169, 123);
            label1.Name = "label1";
            label1.Size = new Size(136, 37);
            label1.TabIndex = 5;
            label1.Text = "Category:";
            label1.Click += label1_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(117, 54, 112);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.WhiteSmoke;
            btnSearch.Location = new Point(1258, 55);
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
            tbSearch.Size = new Size(1226, 43);
            tbSearch.TabIndex = 1;
            // 
            // dgvSeries
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSeries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSeries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSeries.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSeries.Location = new Point(38, 227);
            dgvSeries.Name = "dgvSeries";
            dgvSeries.RowTemplate.Height = 35;
            dgvSeries.RowTemplate.ReadOnly = true;
            dgvSeries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeries.Size = new Size(1358, 722);
            dgvSeries.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(117, 54, 112);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.WhiteSmoke;
            btnDelete.Location = new Point(1259, 955);
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
            btnEdit.Location = new Point(1116, 955);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(137, 43);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // SeriesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1450, 1000);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(dgvSeries);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SeriesForm";
            Text = "SeriesForm";
            Load += SeriesForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSeries).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbSearch;
        private ComboBox cbCategory;
        private Label label1;
        private Button btnSearch;
        public DataGridView dgvSeries;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnRefresh;
    }
}