using MovieNight_BusinessLogic.Services;
using MovieNight_DataAccess.Entities;
using MovieNightOOD.Forms.MediaSubForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieNightOOD.Forms
{
    public partial class SeriesForm : Form
    {
        Menu menu;
        AddSeriesForm addSeriesForm;

        SeriesManager seriesManager = new SeriesManager();
        CategoryManager categoryManager = new CategoryManager();

        public SeriesForm(Menu menu)
        {
            InitializeComponent();
            addSeriesForm = new MediaSubForms.AddSeriesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.menu = menu;

            cbCategory.Items.AddRange(categoryManager.GetAll().ToArray());
        }

        private void SeriesForm_Load(object sender, EventArgs e)
        {
            dgvSeries.DataSource = seriesManager.GetAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSeries.DataSource = seriesManager.GetBySearch(tbSearch.Text + cbCategory.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Series series = (Series)dgvSeries.CurrentRow.DataBoundItem;
            addSeriesForm.SetSeriesId(series.Id);
            menu.pnlMainForm.Controls.Clear();
            this.menu.pnlMainForm.Controls.Add(addSeriesForm);
            addSeriesForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Series series = (Series)dgvSeries.CurrentRow.DataBoundItem;
            seriesManager.Delete(series.Id);
            dgvSeries.DataSource = seriesManager.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            menu.pnlMainForm.Controls.Clear();
            this.menu.pnlMainForm.Controls.Add(addSeriesForm);
            addSeriesForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvSeries.DataSource = seriesManager.GetBySearch("");
        }
    }
}
