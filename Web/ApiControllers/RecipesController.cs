using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var recioe = new RecipeManager().WinApiGetAllRecipes();
            return recioe;
        }

        [HttpGet]
        public RecipeHeaderData Get(int id)
        {
            return new RecipeManager().GetRecipeHeaderData(id);
        }

        [HttpPost]
        [Route("api/Recipes/{id}", Name = "GetRecipeUrl")]
        public void Post(RecipeHeaderData recipeHeader)
        {
            var recipe = new Recipes
            {
                CategoryID = (int)recipeHeader.Category_ID,
                Title = recipeHeader.Title,
                HowToPrepare = recipeHeader.HowToPrepare,
                Ingredients = recipeHeader.Ingredients,
                PrepareTime = recipeHeader.PrepareTime,
                UserID = recipeHeader.User.Id,
                FriendlyUrl = recipeHeader.FriendlyUrl,
                PictureUrl = recipeHeader.PictureUrl
            };
            db.Recipes.Add(recipe);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("api/Recipes/{id}")]
        public void Put(RecipeHeaderData recipeHeader)
        {
            var SelectedRecipe = new RecipeManager().GetRecipeHeaderData(recipeHeader.ID);
            var recipe = new Recipes
            {
                ID = SelectedRecipe.ID,
                CategoryID = (int)recipeHeader.Category_ID,
                Title = recipeHeader.Title,
                HowToPrepare = recipeHeader.HowToPrepare,
                Ingredients = recipeHeader.Ingredients,
                PrepareTime = recipeHeader.PrepareTime,
                UserID = recipeHeader.User.Id,
                FriendlyUrl = recipeHeader.FriendlyUrl,
                PictureUrl = recipeHeader.PictureUrl
            };
            db.Entry(recipe).State = EntityState.Modified;
            db.SaveChanges();
        }

        [HttpDelete]
        [Route("api/Recipes/{id}")]
        public void Delete(int id)
        {
            Recipes recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();

            List<Comments> comments = new CommentManager().GetRecipeCommentsList(id);
            foreach (Comments comment in comments)
            {
                db.Comments.Remove(comment);
            }
            db.SaveChanges();
        }
    }
}
