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

        private int seriesId;
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

        public void SetSeriesId(int seriesid)
        {
            if (seriesid == 0)
            {
                seriesId = 0;
                tbTitle.Text = "";
                tbDescription.Text = "";
                tbImageLink.Text = "";
                tbTrailerLink.Text = "";
                cbCategory.Text = "";
                cbCountry.Text = "";
                cbRating.Text = "";
                numYear.Text = "";
                numSeason.Text = "";
                numEpisode.Text = "";
            }
            else
            {
                Series curSeries = seriesManager.GetById(seriesid);
                seriesId = curSeries.Id;
                tbTitle.Text = curSeries.Title;
                tbDescription.Text = curSeries.Description;
                tbImageLink.Text = curSeries.ImageLink;
                tbTrailerLink.Text = curSeries.TrailerLink;
                cbCategory.Text = curSeries.Category.Name;
                cbCountry.Text = curSeries.Country;
                cbRating.Text = curSeries.Rating.ToString();
                numYear.Text = curSeries.Year.ToString();
                numSeason.Text = curSeries.Season.ToString();
                numEpisode.Text = curSeries.Episode.ToString();
            }
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
            if (tbTitle.Text == "" || tbDescription.Text == "" || tbImageLink.Text == "" || tbTrailerLink.Text == "" || cbCategory.Text == "" ||
                cbCountry.Text == "" || numYear.Text == "" || numEpisode.Text == "" || numSeason.Text == "")
            {
                MessageBox.Show("All fields marked with * are required!");
            }
            if (seriesId == 0)
                seriesManager.Create(series);
            else
                seriesManager.Update(series);
            this.Hide();
            seriesForm.menu.ChangeShownForm(seriesForm);
            seriesForm.dgvSeries.DataSource = seriesManager.GetBySearch("");
        }
    }
}
