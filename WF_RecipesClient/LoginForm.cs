using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_RecipesClient
{
    public partial class LoginForm : Form
    {
        recipeClientForm mainWindow;

        public LoginForm(recipeClientForm mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            tbEmail.Enabled = false;
            tbPassword.Enabled = false;
            login();
            if (validation)
            {
                mainWindow.isLoggedIn = true;
                this.Close();
            }
            else
            {
                this.Size = new Size(800, this.Height);
                btnLogin.Enabled = true;
                tbEmail.Enabled = true;
                tbPassword.Enabled = true;
            }
        }
    }
}
