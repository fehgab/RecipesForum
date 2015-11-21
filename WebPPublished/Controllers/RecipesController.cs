using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPPublished.DTO;
using WebPPublished.Helpers;
using WebPPublished.Manager;
using WebPPublished.Models;

namespace WebPPublished.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string title, int pageNumber = 1)
        {
            var model = new CategoriesListData();
            model.AllCategory = new CategoryManager().GetAllCategory();
            model.Recipes = new RecipeManager().GetAllRecipes()
                                               .Where(r => r.Title.ToLower().Contains(title.ToLower()))
                                               .ToPagedList(pageNumber, 8);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Search(CategoriesListData model, int pageNumber = 1)
        {
            model.AllCategory = new CategoryManager().GetAllCategory();

            Recipes recipe = db.Recipes.Find(model.RecipesDB.ID);
            db.Recipes.Remove(recipe);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~"), "Upload\\Images", recipe.PictureUrl));

            List<Comments> comments = new CommentManager().GetRecipeCommentsList(model.RecipesDB.ID);
            foreach (Comments comment in comments)
            {
                db.Comments.Remove(comment);
            }

            db.SaveChanges();
            model.Recipes = new RecipeManager().GetAllRecipeHeaderData(pageNumber);
            return View(model);
        }

        // GET: Recipes/Details/5
        public ActionResult Details(string sortBy, int pageNumber = 1)
        {
            string name = User.Identity.Name;
            var model = new CategoriesListData();
            model.AllCategory = new CategoryManager().GetAllCategory();
            model.Recipes = new RecipeManager().GetUserRecipes(sortBy, name, pageNumber);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Details(CategoriesListData model, int pageNumber = 1)
        {
            string name = User.Identity.Name;
            model.AllCategory = new CategoryManager().GetAllCategory();

            Recipes recipe = db.Recipes.Find(model.RecipesDB.ID);
            db.Recipes.Remove(recipe);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~"), "Upload\\Images", recipe.PictureUrl));

            List<Comments> comments = new CommentManager().GetRecipeCommentsList(model.RecipesDB.ID);
            foreach (Comments comment in comments)
            {
                db.Comments.Remove(comment);
            }

            db.SaveChanges();
            model.Recipes = new RecipeManager().GetUserRecipes(name, pageNumber);
            return View(model);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            var model = new CategoriesListData();
            model.AllCategory = new CategoryManager().GetAllCategory();
            model.RecipesDB = new Recipes();
            return View(model);
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoriesListData model, HttpPostedFileBase picture)
        {
            model.AllCategory = new CategoryManager().GetAllCategory();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await userManager.FindByIdAsync(User.Identity.GetUserId());

            var recipe = new Recipes
            {
                CategoryID = model.RecipesDB.CategoryID,
                Title = model.RecipesDB.Title,
                HowToPrepare = model.RecipesDB.HowToPrepare,
                Ingredients = model.RecipesDB.Ingredients,
                PrepareTime = model.RecipesDB.PrepareTime,
                UserID = user.Id,
                FriendlyUrl = FriendlyUrlHelper.RemoveDiacritics(model.RecipesDB.Title.Replace(" ", "_"))
            };
            var pictureUrl = FileHelper.GetFileName("", picture);
            if (pictureUrl == null)
            {
                if(picture != null)
                {
                    if (picture.ContentLength > 0)
                    {
                        ModelState.AddModelError("", "Nem megfelelő fájlformátum.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Nincs kép kiválasztva.");
                    return View(model);
                }
            }
            else if (picture.ContentLength > 5000000)
            {
                ModelState.AddModelError("", "Túl nagy méretű kép.");
                return View(model);
            }
            db.Recipes.Add(recipe);
            db.SaveChanges();

            int id = recipe.ID;
            Recipes rec = db.Recipes.Find(id);
            pictureUrl = FileHelper.GetFileName(rec.ID.ToString(), picture);
            if (pictureUrl != null)
            {
                rec.PictureUrl = pictureUrl;
                picture.SaveAs(Path.Combine(Server.MapPath("~"), "Upload\\Images", pictureUrl));
            }
            db.SaveChanges();

            return RedirectToAction("Details");
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? recipeId)
        {
            if (recipeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Find(recipeId);
            var model = new CategoriesListData();
            model.AllCategory = new CategoryManager().GetAllCategory();
            model.RecipesDB = recipes;
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesListData model, HttpPostedFileBase picture)
        {
            model.SelectedRecipe = new RecipeManager().GetRecipeHeaderData(model.RecipesDB.ID);
            model.AllCategory = new CategoryManager().GetAllCategory();
            if (ModelState.IsValid)
            {
                var pictureUrl = FileHelper.GetFileName(model.RecipesDB.ID.ToString(), picture);
                if (pictureUrl != null)
                {
                    model.RecipesDB.PictureUrl = pictureUrl;
                    List<string> pictureUrlElements = new List<string>(pictureUrl.Split(new string[] { "_" }, StringSplitOptions.None));
                    var files = Directory.GetFiles(Path.Combine(Server.MapPath("~"), "Upload\\Images")).ToList();
                    foreach(string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        List<string> fileElemets = new List<string>(fileName.Split(new string[] { "_" }, StringSplitOptions.None));
                        if (fileElemets.First().Equals(pictureUrlElements.First()))
                        {
                            System.IO.File.Delete(file);
                        }
                    }
                    picture.SaveAs(Path.Combine(Server.MapPath("~"), "Upload\\Images", pictureUrl));
                }
                else if(picture != null)
                {
                    if (picture.ContentLength > 0)
                    {
                        ModelState.AddModelError("", "Nem megfelelő fájlformátum.");
                        return View(model);
                    }
                }
                
                model.RecipesDB.FriendlyUrl = FriendlyUrlHelper.RemoveDiacritics(model.RecipesDB.Title.Replace(" ", "_").ToLower());
                db.Entry(model.RecipesDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Comments", "Comments", new { recipeId = model.RecipesDB.ID });
            }
            return View(model);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipes recipes = db.Recipes.Find(id);
            if (recipes == null)
            {
                return HttpNotFound();
            }
            return View(recipes);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipes recipes = db.Recipes.Find(id);
            db.Recipes.Remove(recipes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
