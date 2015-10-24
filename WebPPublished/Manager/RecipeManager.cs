using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPPublished.DTO;
using WebPPublished.Models;

namespace WebPPublished.Manager
{
    public class RecipeManager
    {
        public List<RecipeHeaderData> GetAllRecipeHeaderData()
        {
            using (var context = new ApplicationDbContext())
            {
                var topProducts = context.Recipes
                    .Select(Recipes.SelectHeader).Take(8).ToList();
                return topProducts;
            }
        }
    }
}