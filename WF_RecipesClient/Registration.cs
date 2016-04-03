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
    public partial class RegistrationForm : Form
    {
        recipeClientForm mainWindow;
        public RegistrationForm(recipeClientForm mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createUser();
            if(validation)
                this.Close();
            else
            {
                this.Size = new Size(800, this.Height);
            }
        }
    }
}
