using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPPublished.DTO;
using WebPPublished.Helpers;
using WebPPublished.Manager;
using WebPPublished.Models;

namespace WebPPublished.ApiControllers
{
    public class RecipesController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IEnumerable<RecipeHeaderData> Get()
        {
            return new RecipeManager().WinApiGetAllRecipes();
        }

        [HttpGet]
        public RecipeHeaderData Get(int id)
        {
            return new RecipeManager().GetRecipeHeaderData(id);
        }

        [HttpPost]
        public int Post([FromBody]RecipeHeaderData recipeHeader)
        {
            var userId = new UserManager().GetUserIdByName("Admin");
            var recipe = new Recipes
            {
                CategoryID = (int)recipeHeader.Category_ID,
                Title = recipeHeader.Title,
                HowToPrepare = recipeHeader.HowToPrepare,
                Ingredients = recipeHeader.Ingredients,
                PrepareTime = recipeHeader.PrepareTime,
                UserID = userId,
                FriendlyUrl = recipeHeader.FriendlyUrl,
                PictureUrl = recipeHeader.PictureUrl
            };
            db.Recipes.Add(recipe);
            db.SaveChanges();
            return recipe.ID;
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]RecipeHeaderData recipeHeader)
        {
            var SelectedRecipe = new RecipeManager().GetRecipeHeaderData(recipeHeader.ID);
            var userId = new UserManager().GetUserIdByName("Admin");
            var recipe = new Recipes
            {
                ID = SelectedRecipe.ID,
                CategoryID = (int)recipeHeader.Category_ID,
                Title = recipeHeader.Title,
                HowToPrepare = recipeHeader.HowToPrepare,
                Ingredients = recipeHeader.Ingredients,
                PrepareTime = recipeHeader.PrepareTime,
                UserID = userId,
                FriendlyUrl = SelectedRecipe.FriendlyUrl,
                PictureUrl = recipeHeader.PictureUrl
            };
            db.Entry(recipe).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("api/Recipes/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Recipes recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            string path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~"), "Upload\\Images", recipe.PictureUrl);
            File.Delete(path);
            List<Comments> comments = new CommentManager().GetRecipeCommentsList(id);
            foreach (Comments comment in comments)
            {
                db.Comments.Remove(comment);
            }
            db.SaveChanges();
            return Ok();
        }
    }
}
