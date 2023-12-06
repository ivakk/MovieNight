using MovieNight_BusinessLogic.Services;
using MovieNight_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieNightOOD.Forms.MediaSubForms
{
    public partial class AddSeriesForm : Form
    {
        SeriesManager seriesManager = new SeriesManager();
        CategoryManager categoryManager = new CategoryManager();

        private int seriesId = 0;
        private int season;
        private int episode;
        private int rating;
        private int year;
        public AddSeriesForm()
        {
            InitializeComponent();

            cbCategory.Items.AddRange(categoryManager.GetAll().ToArray());
        }

        public void SetSeriesId(int seriesId = 0)
        {
            this.seriesId = seriesId;
            Series series = seriesManager.GetById(seriesId);
            numSeason.Value = series.Season;
            numEpisode.Value = series.Episode;
            tbTitle.Text = series.Title;
            tbDescription.Text = series.Description;
            tbImageLink.Text = series.ImageLink;
            tbTrailerLink.Text = series.TrailerLink;
            cbCategory.Text = series.Category.Name;
            tbCountry.Text = series.Country;
            numRating.Value = series.Rating;
            numYear.Value = series.Year;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            season = Convert.ToInt32(numSeason.Value);
            episode = Convert.ToInt32(numEpisode.Value);
            rating = Convert.ToInt32(numRating.Value);
            year = Convert.ToInt32(numYear.Value);
            Category category = categoryManager.GetByName(cbCategory.Text);
            Series series = new Series(seriesId, season, episode, tbTitle.Text, tbDescription.Text, tbImageLink.Text,
                tbTrailerLink.Text, category, tbCountry.Text, rating, year);
            if (series.Id == 0)
                seriesManager.Create(series);
            else
                seriesManager.Update(series);
            this.Hide();
        }
    }
}
