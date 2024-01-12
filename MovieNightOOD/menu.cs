using Amazon.Runtime.Internal.Transform;
using Microsoft.TeamFoundation.SourceControl.WebApi.Legacy;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNightOOD.Forms;
using MovieNightOOD.UserControls;
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
using Microsoft.Extensions.DependencyInjection;

namespace MovieNightOOD
{
    public partial class Menu : Form
    {

        Login loginForm;
        public User loggedInUser;
        List<MenuButton> menuButtons = new List<MenuButton>();

        //Loading forms for buttons
        private MovieForm movieForm;
        private SeriesForm seriesForm;
        private UsersForm userForm;

        public Dictionary<string, object> accessForms;
        public Menu(User user, Login loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            this.loggedInUser = user;

            //initialising forms 
            userForm = new UsersForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            movieForm = new MovieForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            seriesForm = new SeriesForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            //Setting up form access
            accessForms = new Dictionary<string, object>() {
            { "Users", userForm },
            { "Movies", movieForm },
            { "Series", seriesForm },
            };

            //Loading buttons
            LoadMenuButtonUsers();
            LoadMenuButtonMovies();
            LoadMenuButtonSeries();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            loginForm.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }
        public void LoadMenuButtonUsers()
        {
            menuButtons.Add(new MenuButton("Users", userForm, this));
            flpMenu.Controls.Add(menuButtons[menuButtons.Count - 1]);
        }

        public void LoadMenuButtonMovies()
        {
            menuButtons.Add(new MenuButton("Movies", movieForm, this));
            flpMenu.Controls.Add(menuButtons[menuButtons.Count - 1]);
        }

        public void LoadMenuButtonSeries()
        {
            menuButtons.Add(new MenuButton("Series", seriesForm, this));
            flpMenu.Controls.Add(menuButtons[menuButtons.Count - 1]);
        }

        public void ChangeShownForm(Form form)
        {
            pnlMainForm.Controls.Clear();
            pnlMainForm.Controls.Add(form);
            form.Show();
        }

        private void lbFirstName_Click(object sender, EventArgs e)
        {

        }

        private void lbUserLetter_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void flpMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
