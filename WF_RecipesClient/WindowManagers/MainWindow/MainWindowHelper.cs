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
                string picturePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Web", "Upload", "Images", recipe.PictureUrl);
                ListViewItem items = new ListViewItem(new[] { picturePath, recipe.Title, recipe.Ingredients, recipe.PrepareTime });
                items.Tag = recipe.ID.ToString();
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

        private void deleteRecipes(ListView.SelectedListViewItemCollection recipes)
        {
            using (var db = new RecipesModel.RecipesModel())
            {
                foreach (ListViewItem recipe in recipes)
                {
                    var selectedRecipe = db.Recipes.Where(r => r.ID.ToString() == (recipe.Tag.ToString())).First();
                    db.Recipes.Remove(selectedRecipe);
                    string picturePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Web", "Upload", "Images", selectedRecipe.PictureUrl);
                    File.Delete(picturePath);
                    db.SaveChanges();
                    var selectedRecipeComments = db.Comments.Where(c => c.RecipesId.ToString() == (recipe.Tag.ToString()));
                    foreach (var selectedRecipeComment in selectedRecipeComments)
                    {
                        db.Comments.Remove(selectedRecipeComment);
                        db.SaveChanges();
                    }
                }
            }
            loadDB();
        }

        private void loadDB()
        {
            using (var db = new RecipesModel.RecipesModel())
            {
                var allRecipes = db.Recipes.ToList();
                fillListView(allRecipes);

                if(cbCategories.Items.Count == 0)
                {
                    var allCategories = db.Categories.ToList();
                    foreach (var category in allCategories)
                    {
                        cbCategories.Items.Add(category.DisplayName);
                    }
                }
            }
        }
    }
}
