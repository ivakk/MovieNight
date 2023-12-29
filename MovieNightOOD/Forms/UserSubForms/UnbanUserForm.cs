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
    public partial class UnbanUserForm : Form
    {

        IUserManager userService;

        UsersForm usersForm;

        public UnbanUserForm(UsersForm usersForm)
        {
            InitializeComponent();
            userService = new UserManager(new UserDALManager());
            this.usersForm = usersForm;
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            User user = userService.GetByUsername(tbUsername.Text);
            if (tbUsername.Text == null)
            {
                MessageBox.Show("Username field is mandatory!");
            }

            if (userService.GetByUsername(tbUsername.Text) == null)
            {
                MessageBox.Show("No user exists with username " + tbUsername.Text + "!");
            }
            else if (userService.BannedUser(userService.GetByUsername(tbUsername.Text)) == false)
            {
                MessageBox.Show("User \"" + tbUsername.Text + "\" is not currently banned!");
                MessageBox.Show(user.Id.ToString());
            }
            else if (userService.BannedUser(userService.GetByUsername(tbUsername.Text)) == true)
            {
                userService.UnbanningUser(userService.GetByUsername(tbUsername.Text));
                MessageBox.Show("User \"" + tbUsername.Text + "\" has been unbanned successfully!");
                MessageBox.Show(user.Id.ToString());
                usersForm.LoadUsers(userService.GetAllUsers());
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
    }
}
