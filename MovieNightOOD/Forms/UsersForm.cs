﻿using MovieNight_BusinessLogic.Services;
using MovieNight_DataAccess.Entities;
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

namespace MovieNightOOD.Forms
{
    public partial class UsersForm : Form
    {
        UserManager userService = new UserManager();

        public Menu menu;
        AddUserForm addUserForm;
        public UsersForm(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;

            addUserForm = new AddUserForm(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, FormBorderStyle = FormBorderStyle.None };
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
    }
}
