using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace WebPPublished.Helpers
{
    public class FileHelper
    {
        public static string GetFileName(string recipeId, HttpPostedFileBase picture)
        {
            try
            {
                if (picture != null && picture.ContentLength > 0)
                {
                    using (Image img = Image.FromStream(picture.InputStream))
                    {
                        if (img.RawFormat.Equals(ImageFormat.Bmp)
                        || img.RawFormat.Equals(ImageFormat.Gif)
                        || img.RawFormat.Equals(ImageFormat.Jpeg)
                        || img.RawFormat.Equals(ImageFormat.Png))
                        {
                            var pictureFileName = Path.GetFileName(picture.FileName);
                            return recipeId + "_" + pictureFileName;
                        }
                    }
                }
            }
            catch (Exception)
            {}
            return null;
        }
    }

}