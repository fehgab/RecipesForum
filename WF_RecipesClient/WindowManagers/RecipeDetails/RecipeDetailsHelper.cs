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
        private bool RecipeValidation()
        {
            bool validation = true;
            lTitleError.Text = "";
            lPrepareTimeError.Text = "";
            lIngredientsError.Text = "";
            lCategoryError.Text = "";
            lHowToPrepareError.Text = "";
            lFileMissingError.Text = "";

            if (tbTitle.Text.Length == 0 || tbTitle.Text.Length > 40)
            {
                lTitleError.Text = "Kérlek add meg az étel nevét! Maximum 40 karakter.";
                validation = false;
            }
            if (tbPrepareTime.Text.Length == 0 || tbPrepareTime.Text.Length > 10)
            {
                lPrepareTimeError.Text = "Kérlek add meg az elkészítési időt! Maximum 10 karakter.";
                validation = false;
            }
            if (tbIngredients.Text.Length == 0 || tbIngredients.Text.Length > 100)
            {
                lIngredientsError.Text = "Kérlek add meg a hozzávalókat! Maximum 100 karakter.";
                validation = false;
            }
            if (cbCategory.SelectedIndex < 0)
            {
                lCategoryError.Text = "Kérlek add meg a kategóriát!";
                validation = false;
            }
            if (tbHowToPrepare.Text.Length == 0 || tbHowToPrepare.Text.Length > 500)
            {
                lHowToPrepareError.Text = "Kérlek add meg az étel elkészítésének módját!";
                validation = false;
            }
            if (tbFilePath.Text.Length == 0)
            {
                lFileMissingError.Text = "Kérlek add meg a kép elérési útját!";
                validation = false;
            }
            return validation;
        }

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
