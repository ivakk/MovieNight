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
    public partial class MovieForm : Form
    {
        Menu menu;
        AddMovieForm addMovieForm;

        IMovieManager movieManager;
        ICategoryManager categoryManager;

        public MovieForm(Menu menu)
        {
            InitializeComponent();
            movieManager = new MovieManager(new MovieDALManager());
            categoryManager = new CategoryManager(new CategoryDALManager());
            addMovieForm = new MediaSubForms.AddMovieForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            this.menu = menu;

            cbCategory.Items.AddRange(categoryManager.GetAll().ToArray());
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            dgvMovies.DataSource = movieManager.GetAll();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMovies.DataSource = movieManager.GetBySearch(tbSearch.Text + cbCategory.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Movie movie = (Movie)dgvMovies.CurrentRow.DataBoundItem;
            addMovieForm.SetMovieId(movie.Id);
            menu.pnlMainForm.Controls.Clear();
            this.menu.pnlMainForm.Controls.Add(addMovieForm);
            addMovieForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Movie movie = (Movie)dgvMovies.CurrentRow.DataBoundItem;
            movieManager.Delete(movie.Id);
            dgvMovies.DataSource = movieManager.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            menu.pnlMainForm.Controls.Clear();
            this.menu.pnlMainForm.Controls.Add(addMovieForm);
            addMovieForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvMovies.DataSource = movieManager.GetBySearch("");
        }
    }
}
