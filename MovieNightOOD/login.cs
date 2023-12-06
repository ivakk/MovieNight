using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MovieNight_DataAccess.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace MovieNightOOD
{
    public partial class Login : Form
    {

        private readonly string tableName = "Users";

        public Login()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi503708;User Id=dbi503708;Password=dbi123;");

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

                    User user = new User(username, password);
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM {tableName} WHERE username = @username AND role = 'admin'", connection);
                    cmd.Parameters.AddWithValue("@username", usernameEntry.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dTable = new DataTable();
                    sda.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        Menu menu = new Menu(user, this);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please check your account information or permissions and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        usernameEntry.Clear();
                        passwordEntry.Clear();

                        usernameEntry.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
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