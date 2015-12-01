namespace WebPPublished.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using DTO;
    using System.Collections.Generic;
    using System.Globalization;

    internal sealed class Configuration : DbMigrationsConfiguration<WebPPublished.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private int GetCategoryId(string categoryUrl)
        {
            using (var context = new ApplicationDbContext())
            {
                var id = context.Categories
                    .Where(p => p.DisplayName == categoryUrl)
                    .Select(Categories.SelectHeader).First().ID;
                return id;
            }
        }

        private string GetUserId(string UserName)
        {
            using (var context = new ApplicationDbContext())
            {
                var id = context.Users
                    .Where(p => p.UserName == UserName)
                    .Select(ApplicationUsers.SelectHeader).First().Id;
                return id;
            }
        }

        private List<RecipeHeaderData> GetRecipes()
        {
            using (var context = new ApplicationDbContext())
            {
                var recipe = context.Recipes
                    .Select(Recipes.SelectHeader).ToList();
                return recipe;
            }
        }

        protected override void Seed(WebPPublished.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrators"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrators" };
                manager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "fgsboarder@gmail.com",
                    RealName = "Feh�r G�bor",
                    EmailConfirmed = true
                };
                manager.Create(user, "Password1");
                manager.AddToRole(user.Id, "Administrators");
            }

            if (!context.Categories.Any(u => u.DisplayName == "Reggeli"))
            {
                context.Categories.AddOrUpdate(
                    new Categories
                    {
                        DisplayName = "Reggeli",
                        FriendlyUrl = "reggeli"
                    }
                );
            }

            if (!context.Categories.Any(u => u.DisplayName == "El��tel"))
            {
                context.Categories.AddOrUpdate(
                    new Categories
                    {
                        DisplayName = "El��tel",
                        FriendlyUrl = "eloetel"
                    }
                );
            }

            if (!context.Categories.Any(u => u.DisplayName == "F��tel"))
            {
                context.Categories.AddOrUpdate(
                    new Categories
                    {
                        DisplayName = "F��tel",
                        FriendlyUrl = "foetel"
                    }
                );
            }

            if (!context.Categories.Any(u => u.DisplayName == "Desszert"))
            {
                context.Categories.AddOrUpdate(
                    new Categories
                    {
                        DisplayName = "Desszert",
                        FriendlyUrl = "desszert"
                    }
                 );
            }

            context.Recipes.AddOrUpdate(
            new Recipes
            {
                UserID = GetUserId("Admin"),
                CategoryID = GetCategoryId("Desszert"),
                Title = "T�r�s gomb�c",
                Ingredients = "Tej, b�zadara, t�r�, cukor",
                PrepareTime = "30 perc",
                HowToPrepare = "Kavard j�l �ssze, de ne legyen t�l kem�ny.",
                FriendlyUrl = "turos_gomboc",
                PictureUrl = "Finom-t�r�s-gomb�c.jpg",
            },
            new Recipes
            {
                UserID = GetUserId("Admin"),
                CategoryID = GetCategoryId("Reggeli"),
                Title = "R�ntotta",
                Ingredients = "toj�s, kolb�sz, szalonna, s�",
                PrepareTime = "20 perc",
                HowToPrepare = "Kavard j�l �ssze, �s s�sd meg.",
                FriendlyUrl = "rantotta",
                PictureUrl = "rantotta.jpg",
            },
            new Recipes
            {
                UserID = GetUserId("Admin"),
                CategoryID = GetCategoryId("F��tel"),
                Title = "Paprik�s csirke",
                Ingredients = "csirkecomb, paprika, hagyma, paradicsom, s�",
                PrepareTime = "1,5 �ra",
                HowToPrepare = "Kavard j�l �ssze, p�rold meg �s s�sd ki.",
                FriendlyUrl = "paprikas_csirke",
                PictureUrl = "paprikas_csirke.jpg",
            },
            new Recipes
            {
                UserID = GetUserId("Admin"),
                CategoryID = GetCategoryId("El��tel"),
                Title = "H�s leves",
                Ingredients = "F�l csirke, r�pa, krumpli, s�",
                PrepareTime = "2 �ra",
                HowToPrepare = "Kavard j�l �ssze, �s fozd meg.",
                FriendlyUrl = "hus_leves",
                PictureUrl = "husleves.jpg",
            }
            );

            context.SaveChanges();

            List<RecipeHeaderData> recipes = GetRecipes();
            foreach (RecipeHeaderData recipe in recipes)
            {
                context.Comments.AddOrUpdate(
                new Comments
                {
                    CreatedDate = Convert.ToDateTime(DateTime.Now.ToString(new CultureInfo("hu-HU"))),
                    RecipesId = recipe.ID,
                    Text = "Ez az els� kommentem.",
                    UserId = GetUserId("fgsboarder")
                }
                );
                context.Comments.AddOrUpdate(
                new Comments
                {
                    CreatedDate = Convert.ToDateTime(DateTime.Now.ToString(new CultureInfo("hu-HU"))),
                    RecipesId = recipe.ID,
                    Text = "Ez az els� kommentem.",
                    UserId = GetUserId("admin")
                }
                );
            }
        }
    }
}
