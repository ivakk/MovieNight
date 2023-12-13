using MovieNight_BusinessLogic.Services;
using MovieNight_InterfacesLL.IServices;
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
using MovieNight_DataAccess.Controllers;

namespace MovieNightOOD.Forms.MediaSubForms
{
    public partial class AddSeriesForm : Form
    {
        ISeriesManager seriesManager;
        ICategoryManager categoryManager;
        SeriesForm seriesForm;

        private int seriesId = 0;
        private int season;
        private int episode;
        private int rating;
        private int year;
        public AddSeriesForm(SeriesForm seriesForm)
        {
            InitializeComponent();
            this.seriesForm = seriesForm;
            seriesManager = new SeriesManager(new SeriesDALManager());
            categoryManager = new CategoryManager(new CategoryDALManager());
            cbCategory.Items.AddRange(categoryManager.GetAll().ToArray());
        }

        public void SetSeriesId(int seriesId = 0)
        {
            rating = Convert.ToInt32(cbRating.Text);
            this.seriesId = seriesId;
            Series series = seriesManager.GetById(seriesId);
            numSeason.Value = series.Season;
            numEpisode.Value = series.Episode;
            tbTitle.Text = series.Title;
            tbDescription.Text = series.Description;
            tbImageLink.Text = series.ImageLink;
            tbTrailerLink.Text = series.TrailerLink;
            cbCategory.Text = series.Category.Name;
            cbCountry.Text = series.Country;
            rating = series.Rating;
            numYear.Value = series.Year;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            season = Convert.ToInt32(numSeason.Value);
            episode = Convert.ToInt32(numEpisode.Value);
            rating = Convert.ToInt32(cbRating.Text);
            year = Convert.ToInt32(numYear.Value);
            Category category = categoryManager.GetByName(cbCategory.Text);
            Series series = new Series(seriesId, season, episode, tbTitle.Text, tbDescription.Text, tbImageLink.Text,
                tbTrailerLink.Text, category, cbCountry.Text, rating, year);
            if (tbTitle.Text == null || tbDescription.Text == null || tbImageLink.Text == null || tbTrailerLink.Text == null || cbCategory.Text == null ||
                cbCountry.Text == null || numYear.Text == null || numEpisode.Text == null || numSeason.Text == null)
            {
                MessageBox.Show("All fields marked with * are required!");
            }
            if (series.Id == 0)
                seriesManager.Create(series);
            else
                seriesManager.Update(series);
            this.Hide();
            seriesForm.menu.ChangeShownForm(seriesForm);
            seriesForm.dgvSeries.DataSource = seriesManager.GetBySearch("");
        }
    }
}
