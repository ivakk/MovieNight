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
using Microsoft.VisualStudio.Services.Account;

namespace MovieNightOOD.Forms.UserSubForms
{
    public partial class AddUserForm : Form
    {

        IUserManager userService;
        IPasswordHashingManager hashing;

        //In case it is in edit mode
        User? User { get; set; }

        UsersForm usersForm;

        public AddUserForm(UsersForm usersForm)
        {
            InitializeComponent();
            userService = new UserManager(new UserDALManager());
            hashing = new PasswordHashingManager();
            this.usersForm = usersForm;
        }

        public AddUserForm(UsersForm usersForm, User user)
        {
            InitializeComponent();
            this.usersForm = usersForm;
            userService = new UserManager(new UserDALManager());
            hashing = new PasswordHashingManager();
            this.User = user;
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

            if (User != null)
            {
                tbUsername.Text = User.Username;
                tbFirstName.Text = User.FirstName;
                tbLastName.Text = User.LastName;
                tbEmail.Text = User.Email;
                User.Role = "default";
                dtpbirthday.Value = User.Birthday;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbFirstName.Text == null || tbLastName.Text == null || tbUsername.Text == null || tbEmail.Text == null || dtpbirthday.Text == null)
            {
                MessageBox.Show("All fields are mandatory!");
            }
            else
            {
                if (!userService.EmailCheck(tbEmail.Text))
                {
                    MessageBox.Show("Enter a valid email address!");
                }
                else if (User == null)
                {
                    string passwordSalt = hashing.PassSalt(10);
                    string passwordHash = hashing.PassHash("movienight", passwordSalt);


                    if (userService.UsernameExists(tbUsername.Text) == true)
                    {
                        MessageBox.Show("The username \"" + tbUsername.Text + "\" is already in use by another user!");
                    }
                    else if (userService.EmailExists(tbEmail.Text) == true)
                    {
                        MessageBox.Show("The email address \"" + tbEmail.Text + "\" is already in use by another user!");
                    }
                    else if (userService.UsernameExists(tbUsername.Text) == false)
                    {
                        User user = new User(0,
                        tbFirstName.Text,
                        tbLastName.Text,
                        dtpbirthday.Value,
                        tbUsername.Text,
                        tbEmail.Text,
                        passwordHash,
                        passwordSalt,
                        "admin");
                        bool success = userService.CreateUser(user);
                        if (success)
                        {
                            usersForm.menu.ChangeShownForm(usersForm);
                        }
                    }
                }
                else if (User != null)
                {
                    if (userService.UsernameExists(tbUsername.Text) == true && tbUsername.Text != User.Username)
                    {
                        MessageBox.Show("The username \"" + tbUsername.Text + "\" is already in use by another user!");
                    }
                    else if (userService.EmailExists(tbEmail.Text) == true && tbEmail.Text != User.Email)
                    {
                        MessageBox.Show("The email address \"" + tbEmail.Text + "\" is already in use by another user!");
                    }
                    else
                    {
                        User user = new User(User.Id,
                        tbFirstName.Text,
                        tbLastName.Text,
                        dtpbirthday.Value,
                        tbUsername.Text,
                        tbEmail.Text,
                        User.PasswordHash,
                        User.PasswordSalt,
                        User.Role);

                        bool success = userService.UpdateUser(user);
                        if (success)
                        {
                            usersForm.menu.ChangeShownForm(usersForm);
                        }
                    }
                }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void dtpbirthday_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
