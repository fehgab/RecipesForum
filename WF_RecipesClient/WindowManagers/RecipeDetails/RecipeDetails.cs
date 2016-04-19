using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (tbTitle.Text.Length == 0)
            {
                lTitleError.Text = "Kérlek add meg az étel nevét!";
                validation = false;
            }
            if (tbPrepareTime.Text.Length == 0)
            {
                lPrepareTimeError.Text = "Kérlek add meg az elkészítési időt!";
                validation = false;
            }
            if (tbIngredients.Text.Length == 0)
            {
                lIngredientsError.Text = "Kérlek add meg a hozzávalókat!";
                validation = false;
            }
            if (cbCategory.SelectedIndex < 0)
            {
                lCategoryError.Text = "Kérlek add meg a kategóriát!";
                validation = false;
            }
            if (tbHowToPrepare.Text.Length == 0)
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
