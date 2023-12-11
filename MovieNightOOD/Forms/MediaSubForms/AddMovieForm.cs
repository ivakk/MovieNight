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

namespace MovieNightOOD.Forms.MediaSubForms
{
    public partial class AddMovieForm : Form
    {
        IMovieManager movieManager;
        ICategoryManager categoryManager;

        private int movieId = 0;
        private int rating;
        private int year;
        public AddMovieForm()
        {
            InitializeComponent();
            movieManager = new MovieManager(new MovieDALManager());
            categoryManager = new CategoryManager(new CategoryDALManager());
            cbCategory.Items.AddRange(categoryManager.GetAll().ToArray());
        }

        public void SetMovieId(int movieId = 0)
        {
            this.movieId = movieId;
            Movie movie = movieManager.GetById(movieId);
            tbTitle.Text = movie.Title;
            tbDescription.Text = movie.Description;
            tbImageLink.Text = movie.ImageLink;
            tbTrailerLink.Text = movie.TrailerLink;
            cbCategory.Text = movie.Category.Name;
            tbCountry.Text = movie.Country;
            numRating.Value = movie.Rating;
            numYear.Value = movie.Year;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            rating = Convert.ToInt32(numRating.Value);
            year = Convert.ToInt32(numYear.Value);
            Category category = categoryManager.GetByName(cbCategory.Text);
            Movie movie = new Movie(movieId, movieId, tbTitle.Text, tbDescription.Text, tbImageLink.Text, tbTrailerLink.Text, category, tbCountry.Text,
                rating, year);
            System.Diagnostics.Debug.WriteLine(movieId);
            if (movieId == 0)
                movieManager.Create(movie);
            else
                movieManager.Update(movie);
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbCountry_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
