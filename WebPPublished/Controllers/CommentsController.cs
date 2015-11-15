using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPPublished.Manager;
using WebPPublished.Models;

namespace WebPPublished.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Comments(int recipeId, int pageNumber = 1)
        {
            var model = new CategoriesListData();
            model.SelectedRecipe = new RecipeManager().GetRecipeHeaderData(recipeId);
            model.Comments = new CommentManager().GetRecipeComments(recipeId, pageNumber);
            return View(model);
        }
    }
}