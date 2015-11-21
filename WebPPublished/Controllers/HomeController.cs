using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPPublished.DTO;
using WebPPublished.Manager;
using WebPPublished.Models;

namespace WebPPublished.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string sortBy, int pageNumber = 1)
        {
            var model = new CategoriesListData();
            model.AllCategory = new CategoryManager().GetAllCategory();
            model.Recipes = new RecipeManager().GetAllRecipeHeaderData(sortBy, pageNumber);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Index(CategoriesListData model, int pageNumber = 1)
        {
            model.AllCategory = new CategoryManager().GetAllCategory();

            Recipes recipe = db.Recipes.Find(model.RecipesDB.ID);
            db.Recipes.Remove(recipe);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~"), "Upload\\Images", recipe.PictureUrl));
            db.SaveChanges();

            List<Comments> comments = new CommentManager().GetRecipeCommentsList(model.RecipesDB.ID);
            foreach(Comments comment in comments)
            {
                db.Comments.Remove(comment);
            }
            db.SaveChanges();

            model.Recipes = new RecipeManager().GetAllRecipeHeaderData(pageNumber);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}