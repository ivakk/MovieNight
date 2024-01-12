using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNightOOD.Forms.MediaSubForms;
using MovieNightOOD.Forms.UserSubForms;
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
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL;
using MovieNight_DataAccess;
using MovieNight_BusinessLogic;

namespace MovieNightOOD.Forms
{
    public partial class UsersForm : Form
    {
        public Menu menu;
        AddUserForm addUserForm;
        BanUserForm banUserForm;
        UnbanUserForm unbanUserForm;


        IUserManager userService;
        IPasswordHashingManager hashing;
        public UsersForm(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;
            userService = new UserManager(new UserDALManager());
            hashing = new PasswordHashingManager();
            addUserForm = new AddUserForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            banUserForm = new BanUserForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
            unbanUserForm = new UnbanUserForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            menu.pnlMainForm.Controls.Clear();
            this.menu.pnlMainForm.Controls.Add(addUserForm);
            addUserForm.Show();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers(userService.GetAllUsers());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(userService.GetBySearch(tbSearch.Text));
        }

        public void LoadUsers(List<User> users)
        {
            flpUsers.Controls.Clear();
            foreach (User user in users)
            {
                UsersUC userControl = new UsersUC(user, this);
                flpUsers.Controls.Add(userControl);
                userControl.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu.pnlMainForm.Controls.Clear();
            this.menu.pnlMainForm.Controls.Add(banUserForm);
            banUserForm.Show();
        }

        private void btnUnbanLoad_Click(object sender, EventArgs e)
        {
            menu.pnlMainForm.Controls.Clear();
            this.menu.pnlMainForm.Controls.Add(unbanUserForm);
            unbanUserForm.Show();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.flpUsers.Top = -this.vScrollBar1.Value;
        }
    }
}
