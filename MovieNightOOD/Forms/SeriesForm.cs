using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
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
using MovieNight_InterfacesLL.IServices;
using MovieNight_DataAccess.Controllers;

namespace MovieNightOOD.Forms
{
    public partial class SeriesForm : Form
    {
        public Menu menu;
        AddSeriesForm addSeriesForm;

        ISeriesManager seriesManager;
        ICategoryManager categoryManager;

        public SeriesForm(Menu menu)
        {
            InitializeComponent();
            seriesManager = new SeriesManager(new SeriesDALManager());
            categoryManager = new CategoryManager(new CategoryDALManager());
            addSeriesForm = new MediaSubForms.AddSeriesForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
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
