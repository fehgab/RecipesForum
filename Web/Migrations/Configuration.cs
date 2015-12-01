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
                    RealName = "Fehér Gábor",
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

            if (!context.Categories.Any(u => u.DisplayName == "Elõétel"))
            {
                context.Categories.AddOrUpdate(
                    new Categories
                    {
                        DisplayName = "Elõétel",
                        FriendlyUrl = "eloetel"
                    }
                );
            }

            if (!context.Categories.Any(u => u.DisplayName == "Fõétel"))
            {
                context.Categories.AddOrUpdate(
                    new Categories
                    {
                        DisplayName = "Fõétel",
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
                Title = "Túrós gombóc",
                Ingredients = "Tej, búzadara, túró, cukor",
                PrepareTime = "30 perc",
                HowToPrepare = "Kavard jól össze, de ne legyen túl kemény.",
                FriendlyUrl = "turos_gomboc",
                PictureUrl = "Finom-túrós-gombóc.jpg",
            },
            new Recipes
            {
                UserID = GetUserId("Admin"),
                CategoryID = GetCategoryId("Reggeli"),
                Title = "Rántotta",
                Ingredients = "tojás, kolbász, szalonna, só",
                PrepareTime = "20 perc",
                HowToPrepare = "Kavard jól össze, és süsd meg.",
                FriendlyUrl = "rantotta",
                PictureUrl = "rantotta.jpg",
            },
            new Recipes
            {
                UserID = GetUserId("Admin"),
                CategoryID = GetCategoryId("Fõétel"),
                Title = "Paprikás csirke",
                Ingredients = "csirkecomb, paprika, hagyma, paradicsom, só",
                PrepareTime = "1,5 óra",
                HowToPrepare = "Kavard jól össze, párold meg és süsd ki.",
                FriendlyUrl = "paprikas_csirke",
                PictureUrl = "paprikas_csirke.jpg",
            },
            new Recipes
            {
                UserID = GetUserId("Admin"),
                CategoryID = GetCategoryId("Elõétel"),
                Title = "Hús leves",
                Ingredients = "Fél csirke, répa, krumpli, só",
                PrepareTime = "2 óra",
                HowToPrepare = "Kavard jól össze, és fozd meg.",
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
                    Text = "Ez az elsõ kommentem.",
                    UserId = GetUserId("fgsboarder")
                }
                );
                context.Comments.AddOrUpdate(
                new Comments
                {
                    CreatedDate = Convert.ToDateTime(DateTime.Now.ToString(new CultureInfo("hu-HU"))),
                    RecipesId = recipe.ID,
                    Text = "Ez az elsõ kommentem.",
                    UserId = GetUserId("admin")
                }
                );
            }
        }
    }
}
