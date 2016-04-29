using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebPPublished.Helpers;
using WF_RecipesClient.RecipesModel;

namespace WF_RecipesClient
{
    public partial class RecipeDetailsForm : Form
    {
        recipeClientForm mainWindow;
        ListView.SelectedListViewItemCollection selectedRecipe;

        Recipes currentRecipe = null;

        public RecipeDetailsForm(recipeClientForm mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();

            using (var db = new RecipesModel.RecipesModel())
            {
                var allCategories = db.Categories.ToList();
                foreach (var category in allCategories)
                {
                    cbCategory.Items.Add(category.DisplayName);
                }
            }
        }

        public RecipeDetailsForm(recipeClientForm mainWindow, ListView.SelectedListViewItemCollection selectedRecipe)
        {
            this.mainWindow = mainWindow;
            this.selectedRecipe = selectedRecipe;
            InitializeComponent();

            foreach (ListViewItem recipe in selectedRecipe)
            {
                string title = recipe.SubItems[1].Text;
                string recipeId = recipe.Tag.ToString();
                tbTitle.Text = title;
                tbFilePath.Text = recipe.SubItems[0].Text;
                tbPrepareTime.Text = recipe.SubItems[3].Text;
                tbIngredients.Text = recipe.SubItems[2].Text;

                using (var db = new RecipesModel.RecipesModel())
                {
                    var allCategories = db.Categories.ToList();
                    foreach (var category in allCategories)
                    {
                        cbCategory.Items.Add(category.DisplayName);
                    }
                    currentRecipe = db.Recipes.Where(r => r.ID.ToString() == recipeId).First();
                    var CurrentCategory = currentRecipe.Categories.DisplayName as string;
                    cbCategory.SelectedItem = CurrentCategory;
                    tbHowToPrepare.Text = currentRecipe.HowToPrepare;
                }
            }
        }

        private void RecipeDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (RecipeValidation())
            {
                if(currentRecipe != null)
                {
                    updateRecipe();
                }
                else
                {
                    addRecipe();
                }
                this.Close();
            }
            else
            {
                this.Size = new Size(900, this.Height);
                this.Enabled = true;
            }
        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Kép kereső";
            fileDialog.Filter = "Képek|*.png; *.jpg; *.bmp; *.gif";
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                tbFilePath.Text = fileDialog.FileName;
            }
        }
    }
}
