using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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

        private void addRecipe()
        {
            //using (var db = new RecipesModel.RecipesModel())
            //{
            //    currentRecipe = new Recipes();
            //    currentRecipe.Title = tbTitle.Text;
            //    currentRecipe.Ingredients = tbIngredients.Text;
            //    currentRecipe.PrepareTime = tbPrepareTime.Text;
            //    currentRecipe.CategoryID = db.Categories.Where(c => c.DisplayName == cbCategory.SelectedItem.ToString()).First().Id;
            //    currentRecipe.HowToPrepare = tbHowToPrepare.Text;
            //    currentRecipe.UserID = db.AspNetUsers.Where(u => u.UserName == "Admin").First().Id;
            //    currentRecipe.FriendlyUrl = FriendlyUrlHelper.RemoveDiacritics(tbTitle.Text);
            //    currentRecipe.PictureUrl = "";
            //    db.Recipes.Add(currentRecipe);
            //    db.SaveChanges();
            //    string pictureUrl = GetFileName(currentRecipe.ID.ToString(), tbFilePath.Text);
            //    if (pictureUrl != null)
            //    {
            //        currentRecipe.PictureUrl = pictureUrl;
            //        string webImagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Web", "Upload", "Images", pictureUrl);
            //        File.Copy(tbFilePath.Text, webImagePath);
            //        db.Recipes.Attach(currentRecipe);
            //        db.Entry(currentRecipe).Property(r => r.PictureUrl).IsModified = true;
            //        db.SaveChanges();
            //    }
            //}
        }

        private void updateRecipe()
        {
            //using (var db = new RecipesModel.RecipesModel())
            //{
            //    currentRecipe.Title = tbTitle.Text;
            //    db.Recipes.Attach(currentRecipe);
            //    db.Entry(currentRecipe).Property(r => r.Title).IsModified = true;
            //    db.SaveChanges();

            //    currentRecipe.Ingredients = tbIngredients.Text;
            //    db.Recipes.Attach(currentRecipe);
            //    db.Entry(currentRecipe).Property(r => r.Ingredients).IsModified = true;
            //    db.SaveChanges();

            //    currentRecipe.PrepareTime = tbPrepareTime.Text;
            //    db.Recipes.Attach(currentRecipe);
            //    db.Entry(currentRecipe).Property(r => r.PrepareTime).IsModified = true;
            //    db.SaveChanges();

            //    currentRecipe.CategoryID = db.Categories.Where(c => c.DisplayName == cbCategory.SelectedItem.ToString()).First().Id;
            //    db.Recipes.Attach(currentRecipe);
            //    db.Entry(currentRecipe).Property(r => r.CategoryID).IsModified = true;
            //    db.SaveChanges();

            //    currentRecipe.HowToPrepare = tbHowToPrepare.Text;
            //    db.Recipes.Attach(currentRecipe);
            //    db.Entry(currentRecipe).Property(r => r.HowToPrepare).IsModified = true;
            //    db.SaveChanges();
            //}
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
