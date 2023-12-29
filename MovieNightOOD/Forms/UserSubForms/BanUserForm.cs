using MovieNight_BusinessLogic.Services;
using MovieNight_DataAccess;
using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieNight_InterfacesLL.IServices;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL;
using MovieNight_BusinessLogic;

namespace MovieNightOOD.Forms.UserSubForms
{
    public partial class BanUserForm : Form
    {

        IUserManager userService;

        //In case it is in edit mode
        User? user { get; set; }

        UsersForm usersForm;

        public BanUserForm(UsersForm usersForm)
        {
            InitializeComponent();
            userService = new UserManager(new UserDALManager());
            this.usersForm = usersForm;
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == null || tbReason.Text == null)
            {
                MessageBox.Show("All fields are mandatory!");
            }

            if (userService.GetByUsername(tbUsername.Text) == null)
            {
                MessageBox.Show("No user exists with username \"" + tbUsername.Text + "\"!");
            }
            else if (userService.BannedUser(userService.GetByUsername(tbUsername.Text)) == false)
            {
                userService.BanningUser(userService.GetByUsername(tbUsername.Text), tbReason.Text);
                MessageBox.Show("User \"" + tbUsername.Text + "\" has been banned successfully!");
                usersForm.menu.ChangeShownForm(usersForm);
                usersForm.LoadUsers(userService.GetAllUsers());
            }
            else if (userService.BannedUser(userService.GetByUsername(tbUsername.Text)) == true)
            {
                MessageBox.Show("User \"" + tbUsername.Text + "\" is already banned!");
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }
    }
}
