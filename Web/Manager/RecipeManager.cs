using PagedList;
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
        public IPagedList<RecipeHeaderData> GetAllRecipeHeaderData(int pageNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                var allRecipes = context.Recipes
                    .OrderBy(r => r.Title)
                    .Select(Recipes.SelectHeader)
                    .ToPagedList(pageNumber, 8);
                return allRecipes;
            }
        }
        public IPagedList<RecipeHeaderData> GetAllRecipeHeaderData(string sortBy, int pageNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                IPagedList<RecipeHeaderData> allRecipes;
                switch (sortBy)
                {
                    case "Title":
                        allRecipes = context.Recipes
                        .OrderBy(r => r.Title)
                        .Select(Recipes.SelectHeader)
                        .ToPagedList(pageNumber, 8);
                        break;

                    case "PrepareTime":
                        allRecipes = context.Recipes
                        .OrderBy(r => r.PrepareTime)
                        .Select(Recipes.SelectHeader)
                        .ToPagedList(pageNumber, 8);
                        break;

                    default:
                        allRecipes = context.Recipes
                        .OrderBy(r => r.Title)
                        .Select(Recipes.SelectHeader)
                        .ToPagedList(pageNumber, 8);
                        break;
                }
                return allRecipes;
            }
        }

        public List<RecipeHeaderData> GetAllRecipes()
        {
            using (var context = new ApplicationDbContext())
            {
                var allRecipes = context.Recipes
                    .OrderBy(r => r.Title)
                    .Select(Recipes.SelectHeader)
                    .ToList();
                return allRecipes;
            }
        }

        public List<RecipeHeaderData> WinApiGetAllRecipes()
        {
            using (var context = new ApplicationDbContext())
            {
                var allRecipes = context.Recipes
                    .OrderBy(r => r.Title)
                    .Select(Recipes.WinApiSelectHeader)
                    .ToList();
                return allRecipes;
            }
        }

        public RecipeHeaderData GetRecipeHeaderData(int recipeId)
        {
            using (var context = new ApplicationDbContext())
            {
                var recipe = context.Recipes
                    .Where(r => r.ID == recipeId)
                    .Select(Recipes.SelectHeader).First();
                return recipe;
            }
        }

        public IPagedList<RecipeHeaderData> GetUserRecipes(string UserName, int pageNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                var UserRecipes = context.Recipes
                    .Where(p => p.User.UserName == UserName)
                    .OrderBy(r => r.Title)
                    .Select(Recipes.SelectHeader)
                    .ToPagedList(pageNumber, 8);
                return UserRecipes;
            }
        }

        public IPagedList<RecipeHeaderData> GetUserRecipes(string sortBy, string UserName, int pageNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                IPagedList<RecipeHeaderData> allRecipes;
                switch (sortBy)
                {
                    case "Title":
                        allRecipes = context.Recipes
                        .Where(r => r.User.UserName == UserName)
                        .OrderBy(r => r.Title)
                        .Select(Recipes.SelectHeader)
                        .ToPagedList(pageNumber, 8);
                        break;

                    case "PrepareTime":
                        allRecipes = context.Recipes
                        .Where(r => r.User.UserName == UserName)
                        .OrderBy(r => r.PrepareTime)
                        .Select(Recipes.SelectHeader)
                        .ToPagedList(pageNumber, 8);
                        break;

                    default:
                        allRecipes = context.Recipes
                        .Where(r => r.User.UserName == UserName)
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