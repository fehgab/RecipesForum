using RecipesClient.DTO;
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

        List<RecipesHeaderData> allRecipes = null;
        List<CategoryHeaderData> allCategories = null;

        RecipesHeaderData currentRecipe = null;

        public RecipeDetailsForm(recipeClientForm mainWindow, List<CategoryHeaderData> allCategories)
        {
            this.mainWindow = mainWindow;
            this.allCategories = allCategories;
            InitializeComponent();

            foreach (var category in allCategories)
            {
                cbCategory.Items.Add(category.DisplayName);
            }
        }

        public RecipeDetailsForm(recipeClientForm mainWindow, List<RecipesHeaderData> allRecipes, List<CategoryHeaderData> allCategories, ListView.SelectedListViewItemCollection selectedRecipe)
        {
            this.allRecipes = allRecipes;
            this.allCategories = allCategories;
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

                foreach (var category in allCategories)
                {
                    cbCategory.Items.Add(category.DisplayName);
                }
                currentRecipe = allRecipes.Where(r => r.ID.ToString() == recipeId).First();
                var currentCategory = allCategories.Where(c => c.ID == currentRecipe.Category_ID).First();
                cbCategory.SelectedItem = currentCategory.DisplayName;
                tbHowToPrepare.Text = currentRecipe.HowToPrepare;
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
