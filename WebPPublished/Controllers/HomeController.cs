using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPPublished.Manager;
using WebPPublished.Models;

namespace WebPPublished.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int pageNumber = 1)
        {
            var model = new CategoriesListData();
            model.AllCategory = new CategoryManager().GetAllCategory();
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