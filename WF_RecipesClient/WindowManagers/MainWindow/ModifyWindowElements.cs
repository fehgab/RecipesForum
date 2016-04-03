using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_RecipesClient.RecipesModel;

namespace WF_RecipesClient
{
    partial class recipeClientForm
    {
        private void SetMinColumsWidth()
        {
            if (chPicture.Width < 200)
                chPicture.Width = 200;
            if (chTitle.Width < 100)
                chTitle.Width = 100;
            if (chPrepareTime.Width < 120)
                chPrepareTime.Width = 120;
            if (chIngredients.Width < 110)
                chIngredients.Width = 110;
        }
        private void fillListView(List<Recipes> recipes)
        {
            lwRecipes.Items.Clear();
            foreach (var recipe in recipes)
            {
                string picturePath = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Web", "Upload", "Images", recipe.PictureUrl);
                ListViewItem items = new ListViewItem(new[] { picturePath, recipe.Title, recipe.Ingredients, recipe.PrepareTime });
                lwRecipes.Items.Add(items);
                lwRecipes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                SetMinColumsWidth();
            }
        }
        private void searchRecipes()
        {
            using (var db = new RecipesModel.RecipesModel())
            {
                List<Recipes> searchedRecipes = null;
                if (tbSearch.Text.Length > 0 && !((string)cbCategories.SelectedItem).Equals("Összes"))
                {
                    searchedRecipes = db.Recipes.Where(r => r.Categories.DisplayName.Equals((string)cbCategories.SelectedItem)
                                                 && r.Title.Contains(tbSearch.Text)).ToList();
                }
                else if (tbSearch.Text.Length > 0)
                {
                    searchedRecipes = db.Recipes.Where(r => r.Title.Contains(tbSearch.Text)).ToList();
                }
                else
                {
                    searchedRecipes = db.Recipes.ToList();
                }
                fillListView(searchedRecipes);
            }
        }
    }
}
