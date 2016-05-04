using RecipesClient.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            using (HttpClient client = new HttpClient())
            {
                foreach (ListViewItem recipe in recipes)
                {
                    var resp = await client.DeleteAsync("https://localhost:44300/api/Recipes/" + recipe.Tag.ToString());
                    bool returnValue = await resp.Content.ReadAsAsync<bool>();
                }
            }
            await loadRecipes();
        }

        private async Task loadCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                var categoryResp = await client.GetAsync("https://localhost:44300/api/Categories/AllCategories");
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

        private void applyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                resources.ApplyResources(ctl, ctl.Name);
                applyResources(resources, ctl.Controls);
            }
        }
    }
}
