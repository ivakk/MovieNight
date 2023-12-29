using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
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
using Microsoft.Extensions.Logging;

namespace MovieNightOOD.Forms.MediaSubForms
{
    public partial class AddMovieForm : Form
    {
        IMovieManager movieManager;
        ICategoryManager categoryManager;
        MovieForm movieForm;

        private int movieId = 0;
        private int length;
        private int rating;
        private int year;
        public AddMovieForm(MovieForm movieForm)
        {
            InitializeComponent();
            this.movieForm = movieForm;
            movieManager = new MovieManager(new MovieDALManager());
            categoryManager = new CategoryManager(new CategoryDALManager());
            cbCategory.Items.AddRange(categoryManager.GetAll().ToArray());
            this.movieForm = movieForm;
        }

        public void SetMovieId(int movieId = 0)
        {
            rating = Convert.ToInt32(cbRating.Text);
            length = Convert.ToInt32(numLength.Text);
            year = Convert.ToInt32(numYear.Value);
            this.movieId = movieId;
            Movie movie = movieManager.GetById(movieId);
            tbTitle.Text = movie.Title;
            tbDescription.Text = movie.Description;
            tbImageLink.Text = movie.ImageLink;
            tbTrailerLink.Text = movie.TrailerLink;
            cbCategory.Text = movie.Category.Name;
            cbCountry.Text = movie.Country;
            rating = movie.Rating;
            year = movie.Year;
            length = movie.Length;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbRating.Text != "")
            {
                rating = Convert.ToInt32(cbRating.Text);
            }

            if (tbTitle.Text == null || tbDescription.Text == null || tbImageLink.Text == null || tbTrailerLink.Text == null || cbCategory.Text == null ||
                cbCountry.Text == null || numYear.Text == null || numLength.Text== null)
            {
                MessageBox.Show("All fields marked with * are required!");
            }
            else
            {
                length = Convert.ToInt32(numLength.Value);
                year = Convert.ToInt32(numYear.Value);
                Category category = categoryManager.GetByName(cbCategory.Text);
                Movie movie = new Movie(movieId, length, tbTitle.Text, tbDescription.Text, tbImageLink.Text, tbTrailerLink.Text, category, cbCountry.Text,
                    rating, year);
                if (movieId == 0)
                    movieManager.Create(movie);
                else
                    movieManager.Update(movie);
                this.Hide();
                movieForm.menu.ChangeShownForm(movieForm);
                movieForm.dgvMovies.DataSource = movieManager.GetBySearch("");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbCountry_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
