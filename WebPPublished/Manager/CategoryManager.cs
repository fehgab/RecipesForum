using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPPublished.DTO;
using WebPPublished.Models;

namespace WebPPublished.Manager
{
    public class CategoryManager
    {
        public List<CategoryHeaderData> GetAllCategory()
        {
            using (var context = new ApplicationDbContext())
            {
                var allCategory = context.Categories
                    .Select(Categories.SelectHeader).ToList();
                return allCategory;
            }
        }
        public List<RecipeHeaderData> GetRecipesInCategory(string categoryUrl)
        {
            using (var context = new ApplicationDbContext())
            {
                var recipesFromCategory = context.Recipes
                    .Where(p => p.Category.FriendlyUrl == categoryUrl)
                    .Select(Recipes.SelectHeader).Take(8).ToList();
                return recipesFromCategory;
            }
        }
    }
    
}