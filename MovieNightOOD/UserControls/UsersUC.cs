using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNightOOD.Forms;
using MovieNightOOD.Forms.UserSubForms;
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

namespace MovieNightOOD.UserControls
{
    public partial class UsersUC : UserControl
    {
        private IUserManager userService;
        UsersForm usersForm;
        public User User { get; set; }
        public UsersUC(User user, UsersForm usersForm)
        {
            InitializeComponent();
            this.User = user;
            this.usersForm = usersForm;
            userService = new UserManager(new UserDALManager());
        }

        private void UsersUC_Load(object sender, EventArgs e)
        {
            lbEmail.Text = User.Email;
            lbFirstName.Text = User.FirstName;
            lbLastName.Text = User.LastName;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(usersForm, User) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None }; ;
            usersForm.menu.ChangeShownForm(addUserForm);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (User != null)
            {
                userService.DeleteUser(User.Id);
                usersForm.LoadUsers(userService.GetAllUsers());
                usersForm.menu.ChangeShownForm(usersForm);
            }
        }
    }
}
