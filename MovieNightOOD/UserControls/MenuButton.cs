using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieNightOOD.UserControls
{
    public partial class MenuButton : UserControl
    {
        public string ButtonText;
        public Form AssosiatedForm;
        private Menu menuRef;

        public MenuButton(string buttonText, Form assosiatedForm, Menu menuRef)
        {
            InitializeComponent();
            ButtonText = buttonText;
            AssosiatedForm = assosiatedForm;
            this.menuRef = menuRef;
            Button.Text = buttonText;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            menuRef.pnlMainForm.Controls.Clear();
            this.menuRef.pnlMainForm.Controls.Add(AssosiatedForm);
            AssosiatedForm.Show();
        }
    }
}
