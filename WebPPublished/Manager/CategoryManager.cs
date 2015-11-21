using PagedList;
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
        public IPagedList<RecipeHeaderData> GetRecipesInCategory(string categoryUrl, int pageNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                var recipesFromCategory = context.Recipes
                    .Where(r => r.Category.FriendlyUrl == categoryUrl)
                    .OrderBy(r => r.Title)
                    .Select(Recipes.SelectHeader)
                    .ToPagedList(pageNumber, 8);
                return recipesFromCategory;
            }
        }

        public IPagedList<RecipeHeaderData> GetRecipesInCategory(string categoryUrl, string sortBy, int pageNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                IPagedList<RecipeHeaderData> allRecipes;
                switch (sortBy)
                {
                    case "Title":
                        allRecipes = context.Recipes
                        .Where(r => r.Category.FriendlyUrl == categoryUrl)
                        .OrderBy(r => r.Title)
                        .Select(Recipes.SelectHeader)
                        .ToPagedList(pageNumber, 8);
                        break;

                    case "PrepareTime":
                        allRecipes = context.Recipes
                        .Where(r => r.Category.FriendlyUrl == categoryUrl)
                        .OrderBy(r => r.PrepareTime)
                        .Select(Recipes.SelectHeader)
                        .ToPagedList(pageNumber, 8);
                        break;

                    default:
                        allRecipes = context.Recipes
                        .Where(r => r.Category.FriendlyUrl == categoryUrl)
                        .OrderBy(r => r.Title)
                        .Select(Recipes.SelectHeader)
                        .ToPagedList(pageNumber, 8);
                        break;
                }
                return allRecipes;
            }
        }
    }
    
}