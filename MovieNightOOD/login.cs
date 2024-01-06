using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MovieNight_Classes;
using MovieNight_BusinessLogic.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MovieNight_InterfacesLL.IServices;
using Microsoft.Extensions.DependencyInjection;
using MovieNight_DataAccess.Controllers;
using System.CodeDom;
using System.Diagnostics;

namespace MovieNightOOD
{
    public partial class Login : Form
    {
        private readonly IUserManager userManager;
        private readonly ICommentManager commentManager;


        public Login(IUserManager userManager)
        {
            InitializeComponent();
            commentManager = new CommentManager(new CommentDALManager());
            this.userManager = userManager;
        }

        private void reveal_MouseDown(object sender, MouseEventArgs e)
        {
            passwordEntry.PasswordChar = '\0';
        }

        private void reveal_MouseUp(object sender, MouseEventArgs e)
        {
            passwordEntry.PasswordChar = '●';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
            if (usernameEntry.Text == "" & passwordEntry.Text == "")
            {
                MessageBox.Show("Enter your username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (passwordEntry.Text == "")
            {
                MessageBox.Show("Enter your password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (usernameEntry.Text == "")
            {
                MessageBox.Show("Enter your username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
            else
            {
                try
                {
                    User user = userManager.CheckUser(usernameEntry.Text, passwordEntry.Text);
                    if (user.Role == "admin")
                    {
                        Menu menu = new Menu(user, this);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You do not have access!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Your login details are incorrect!");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void usernameEntry_TextChanged(object sender, EventArgs e)
        {

        }
    }
}