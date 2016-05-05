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
        bool validation = true;

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
            tbUserName.Enabled = false;
            tbPassword.Enabled = false;
            login();
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(tbUserName.TextLength < 1 || tbUserName.TextLength > 100)
            {
                Size = new Size(800, this.Height);
                lUserNameError.Text = "Nem megfelelő hosszúságú név.";
                validation = false;
            }
            else
            {
                lUserNameError.Text = "";
                validation = true;
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.TextLength < 1 || tbPassword.TextLength > 100)
            {
                Size = new Size(800, Height);
                lPasswordError.Text = "Nem megfelelő hosszúságú jelszó.";
                validation = false;
            }
            else {
                lPasswordError.Text = "";
                validation = true;
            }
        }
    }
}
