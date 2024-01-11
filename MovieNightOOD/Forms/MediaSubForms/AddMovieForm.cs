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

        private int movieId;
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
        }


        public void SetMovieId(int movieid)
        {
            if (movieid == 0)
            {
                movieId = 0;
                tbTitle.Text = "";
                tbDescription.Text = "";
                tbImageLink.Text = "";
                tbTrailerLink.Text = "";
                cbCategory.Text = "";
                cbCountry.Text = "";
                cbRating.Text = "";
                numYear.Text = "";
                numLength.Text = "";
                tbDirector.Text = "";
            }
            else
            {
                Movie curMovie = movieManager.GetById(movieid);
                movieId = curMovie.Id;
                tbTitle.Text = curMovie.Title;
                tbDescription.Text = curMovie.Description;
                tbImageLink.Text = curMovie.ImageLink;
                tbTrailerLink.Text = curMovie.TrailerLink;
                cbCategory.Text = curMovie.Category.Name;
                cbCountry.Text = curMovie.Country;
                cbRating.Text = curMovie.Rating.ToString();
                numYear.Text = curMovie.Year.ToString();
                numLength.Text = curMovie.Length.ToString();
                tbDirector.Text = curMovie.Director;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbRating.Text != "")
            {

            }

            if (tbTitle.Text == "" || tbDescription.Text == "" || tbImageLink.Text == "" || tbTrailerLink.Text == "" || cbCategory.Text == "" ||
                cbCountry.Text == "" || numYear.Text == "" || numLength.Text == "" || cbRating.Text == "" || tbDirector.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                rating = Convert.ToInt32(cbRating.Text);
                length = Convert.ToInt32(numLength.Text);
                year = Convert.ToInt32(numYear.Value);
                Category category = categoryManager.GetByName(cbCategory.Text);
                Movie movie = new Movie(movieId, Convert.ToInt32(numLength.Text), tbDirector.Text, tbTitle.Text, tbDescription.Text,
                    tbImageLink.Text, tbTrailerLink.Text, category, cbCountry.Text,
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
