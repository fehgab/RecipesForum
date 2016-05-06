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

        bool validation = true;

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
            tbTitle_Validating(sender, new CancelEventArgs());
            cbCategory_Validating(sender, new CancelEventArgs());
            tbHowToPrepare_Validating(sender, new CancelEventArgs());
            tbIngredients_Validating(sender, new CancelEventArgs());
            tbPrepareTime_Validating(sender, new CancelEventArgs());
            tbFilePath_Validating(sender, new CancelEventArgs());
            if (validation)
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

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (tbTitle.Text.Length == 0 || tbTitle.Text.Length > 40)
            {
                lTitleError.Text = "Kérlek add meg az étel nevét! Maximum 40 karakter.";
                validation = false;
            }
            else
            {
                validation = true;
                lTitleError.Text = "";
            }
        }

        private void cbCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cbCategory.SelectedIndex < 0)
            {
                lCategoryError.Text = "Kérlek add meg a kategóriát!";
                validation = false;
            }
            else
            {
                validation = true;
                lCategoryError.Text = "";
            }
        }

        private void tbIngredients_Validating(object sender, CancelEventArgs e)
        {
            if (tbIngredients.Text.Length == 0 || tbIngredients.Text.Length > 100)
            {
                lIngredientsError.Text = "Kérlek add meg a hozzávalókat! Maximum 100 karakter.";
                validation = false;
            }
            else
            {
                validation = true;
                lIngredientsError.Text = "";
            }
        }

        private void tbPrepareTime_Validating(object sender, CancelEventArgs e)
        {
            if (tbPrepareTime.Text.Length == 0 || tbPrepareTime.Text.Length > 10)
            {
                lPrepareTimeError.Text = "Kérlek add meg az elkészítési időt! Maximum 10 karakter.";
                validation = false;
            }
            else
            {
                validation = true;
                lPrepareTimeError.Text = "";
            }
        }

        private void tbHowToPrepare_Validating(object sender, CancelEventArgs e)
        {
            if (tbHowToPrepare.Text.Length == 0 || tbHowToPrepare.Text.Length > 500)
            {
                lHowToPrepareError.Text = "Kérlek add meg az étel elkészítésének módját!";
                validation = false;
            }
            else
            {
                validation = true;
                lHowToPrepareError.Text = "";
            }
        }

        private void tbFilePath_Validating(object sender, CancelEventArgs e)
        {
            if (tbFilePath.Text.Length == 0)
            {
                lFileMissingError.Text = "Kérlek add meg a kép elérési útját!";
                validation = false;
            }
            else
            {
                validation = true;
                lFileMissingError.Text = "";
            }
        }
    }
}
