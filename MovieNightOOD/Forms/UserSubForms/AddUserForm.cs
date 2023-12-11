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
            hashing = new PasswordHashingManager(new PasswordHashing());
            this.usersForm = usersForm;
        }

        public AddUserForm(UsersForm usersForm, User user)
        {
            InitializeComponent();
            this.usersForm = usersForm;
            userService = new UserManager(new UserDALManager());
            hashing = new PasswordHashingManager(new PasswordHashing());
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
            if (User == null)
            {
                string passwordSalt = hashing.passSalt(10);
                string passwordHash = hashing.passHash("movienight", passwordSalt);

                User user = new User(0,
                    tbFirstName.Text,
                    tbLastName.Text,
                    dtpbirthday.Value,
                    tbUsername.Text,
                    tbEmail.Text,
                    passwordHash,
                    passwordSalt,
                    "default");

                bool success = userService.CreateUser(user);
                if (success)
                {
                    usersForm.menu.ChangeShownForm(usersForm);
                }
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
                    "default");

                bool success = userService.UpdateUser(user);
                if (success)
                {
                    usersForm.menu.ChangeShownForm(usersForm);
                }
            }
            usersForm.LoadUsers(userService.GetAllUsers());
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
