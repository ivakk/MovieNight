using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MovieNightOOD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi503708;User Id=dbi503708;Password=dbi123;");


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(usernameEntry.Text == "" & passwordEntry.Text == "")
            {
                MessageBox.Show("Enter your username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(passwordEntry.Text == "")
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM MovieAdmin WHERE username = @username AND password = @password", connection);
                    cmd.Parameters.AddWithValue("@username", usernameEntry.Text);
                    cmd.Parameters.AddWithValue("@password", passwordEntry.Text);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dTable = new DataTable();
                    sda.Fill(dTable);

                    if (dTable.Rows.Count > 0)
                    {
                        menu form2 = new menu();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Please check your password and account name and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}