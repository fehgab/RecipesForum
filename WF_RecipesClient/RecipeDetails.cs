using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_RecipesClient.RecipesModel;

namespace WF_RecipesClient
{
    public partial class RecipeDetails : Form
    {
        recipeClientForm mainWindow;
        ListView.SelectedListViewItemCollection selectedRecipe;

        public RecipeDetails(recipeClientForm mainWindow, ListView.SelectedListViewItemCollection selectedRecipe)
        {
            this.mainWindow = mainWindow;
            this.selectedRecipe = selectedRecipe;
            InitializeComponent();

            foreach (ListViewItem recipe in selectedRecipe)
            {
                string title = recipe.SubItems[1].Text;
                string userId = recipe.Tag as string;
                tbTitle.Text = title;
                tbPrepareTime.Text = recipe.SubItems[2].Text;
                tbIngredients.Text = recipe.SubItems[3].Text;

                using (var db = new RecipesModel.RecipesModel())
                {
                    var allCategories = db.Categories.ToList();
                    foreach (var category in allCategories)
                    {
                        cbCategory.Items.Add(category.DisplayName);
                    }
                    Recipes currentRecipe = db.Recipes.Where(r => r.UserID == userId && r.Title == title).First();
                    var CurrentCategory = currentRecipe.Categories.DisplayName as string;
                    cbCategory.SelectedItem = CurrentCategory;
                }
            }
        }

        private void RecipeDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.Enabled = true;
        }
    }
}
