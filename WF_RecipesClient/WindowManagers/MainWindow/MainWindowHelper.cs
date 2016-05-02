using RecipesClient.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_RecipesClient.RecipesModel;

namespace WF_RecipesClient
{
    partial class recipeClientForm
    {
        List<CategoryHeaderData> allCategories;
        List<RecipesHeaderData> allRecipes;

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
        private void fillListView(List<RecipesHeaderData> recipes)
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
            if (tbSearch.Text.Length > 0)
            {
                List<RecipesHeaderData> searchedRecipes = null;

                if (!((string)cbCategories.SelectedItem).Equals("Összes"))
                {
                    var category = allCategories.Where(c => c.DisplayName.Equals((string)cbCategories.SelectedItem)).First();
                    searchedRecipes = allRecipes.Where(r => r.Title.Contains(tbSearch.Text) && r.Category_ID == category.ID).ToList();
                }
                else
                {
                    searchedRecipes = allRecipes.Where(r => r.Title.Contains(tbSearch.Text)).ToList();
                }
                fillListView(searchedRecipes);
            }
        }

        private async void deleteRecipes(ListView.SelectedListViewItemCollection recipes)
        {
            using (var db = new RecipesModel.RecipesModel())
            {
                foreach (ListViewItem recipe in recipes)
                {
                    var selectedRecipe = db.Recipes.Where(r => r.ID.ToString() == (recipe.Tag.ToString())).First();
                    db.Recipes.Remove(selectedRecipe);
                    string picturePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Web", "Upload", "Images", selectedRecipe.PictureUrl);
                    FileAttributes attributes = File.GetAttributes(picturePath);
                    attributes = attributes & ~FileAttributes.ReadOnly;
                    File.SetAttributes(picturePath, attributes);
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
            await loadRecipes();
        }

        private async Task loadCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                var categoryResp = await client.GetAsync("https://localhost:44300/api/Categories");
                allCategories = await categoryResp.Content.ReadAsAsync<List<CategoryHeaderData>>();

                foreach (var category in allCategories)
                {
                    cbCategories.Items.Add(category.DisplayName);
                }
            }
        }

        private async Task loadRecipes()
        {
            using (HttpClient client = new HttpClient())
            {
                var recipeResp = await client.GetAsync("https://localhost:44300/api/Recipes");
                allRecipes = await recipeResp.Content.ReadAsAsync<List<RecipesHeaderData>>();
                fillListView(allRecipes);
            }
        }
    }
}
