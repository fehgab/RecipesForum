using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebPPublished.Helpers
{
    public class FileHelper
    {
        public static string GetFileName(string userName, HttpPostedFileBase picture)
        {
            if (picture != null && picture.ContentLength > 0)
            {
                // TODO: Validáció, hogy tényleg kép-e?
                var pictureFileName = Path.GetFileName(picture.FileName);
                return userName + "_" + pictureFileName;
            }
            return null;
        }
    }
}