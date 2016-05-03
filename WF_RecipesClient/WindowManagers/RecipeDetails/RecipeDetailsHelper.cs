using RecipesClient.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebPPublished.Helpers;
using WF_RecipesClient.RecipesModel;

namespace WF_RecipesClient
{
    partial class RecipeDetailsForm
    {
      
        private async void addRecipe()
        {
            using (HttpClient client = new HttpClient())
            {
                var category = allCategories.Where(c => c.DisplayName == cbCategory.Text).First();
                var friendlyUrl = FriendlyUrlHelper.RemoveDiacritics(tbTitle.Text);
                RecipesHeaderData recipeHeader = new RecipesHeaderData()
                {
                    HowToPrepare = tbHowToPrepare.Text,
                    Ingredients = tbIngredients.Text,
                    PrepareTime = tbPrepareTime.Text,
                    Title = tbTitle.Text,
                    Category_ID = category.ID,
                    FriendlyUrl = friendlyUrl,
                    PictureUrl = "default"
                };
                var postResponse = await client.PostAsJsonAsync("https://localhost:44300/api/Recipes", recipeHeader);
                int recipeId = await postResponse.Content.ReadAsAsync<int>();

                string pictureUrl = GetFileName(recipeId.ToString(), tbFilePath.Text);
                if (pictureUrl != null)
                {
                    string webImagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Web", "Upload", "Images", pictureUrl);
                    File.Copy(tbFilePath.Text, webImagePath);
                    RecipesHeaderData recipeHeaderUpdate = new RecipesHeaderData()
                    {
                        ID = recipeId,
                        PictureUrl = pictureUrl,
                        HowToPrepare = tbHowToPrepare.Text,
                        Ingredients = tbIngredients.Text,
                        PrepareTime = tbPrepareTime.Text,
                        Title = tbTitle.Text,
                        Category_ID = category.ID,
                        FriendlyUrl = friendlyUrl
                    };
                    var putResponse = await client.PutAsJsonAsync("https://localhost:44300/api/Recipes", recipeHeaderUpdate);
                    bool returnValue = await putResponse.Content.ReadAsAsync<bool>();
                }

                this.Close();
            }
        }

        private async void updateRecipe()
        {
            using (HttpClient client = new HttpClient())
            {
                var category = allCategories.Where(c => c.DisplayName == cbCategory.Text).First();
                RecipesHeaderData recipeHeader = new RecipesHeaderData()
                {
                    ID = currentRecipe.ID,
                    HowToPrepare = tbHowToPrepare.Text,
                    Ingredients = tbIngredients.Text,
                    PrepareTime = tbPrepareTime.Text,
                    Title = tbTitle.Text,
                    Category_ID = category.ID,
                    FriendlyUrl = currentRecipe.FriendlyUrl,
                    PictureUrl = currentRecipe.PictureUrl,
                    UserId = currentRecipe.UserId
                };
                var response = await client.PutAsJsonAsync("https://localhost:44300/api/Recipes", recipeHeader);
                bool returnValue = await response.Content.ReadAsAsync<bool>();
                this.Close();
            }    
        }


        public string GetFileName(string recipeId, string filePath)
        {
            try
            {
                FileInfo fi = new FileInfo(filePath);
                if (fi != null && fi.Length > 0)
                {
                    using (FileStream fs = File.OpenRead(filePath))
                    {
                        using (Image img = Image.FromStream(fs))
                        {
                            if (img.RawFormat.Equals(ImageFormat.Bmp)
                            || img.RawFormat.Equals(ImageFormat.Gif)
                            || img.RawFormat.Equals(ImageFormat.Jpeg)
                            || img.RawFormat.Equals(ImageFormat.Png))
                            {
                                var pictureFileName = Path.GetFileName(filePath);
                                return recipeId + "_" + pictureFileName;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            { }
            return null;
        }
    }
}
