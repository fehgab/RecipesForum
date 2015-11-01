using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
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

        // GET: Recipes/Details/5
        public ActionResult Details()
        {
            string name = User.Identity.Name;
            var model = new CategoriesListData();
            model.AllCategory = new CategoryManager().GetAllCategory();
            model.Recipes = new RecipeManager().GetUserRecipes(name);
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
            if (!ModelState.IsValid)
            {
                model.AllCategory = new CategoryManager().GetAllCategory();
                return View(model);
            }
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await userManager.FindByIdAsync(User.Identity.GetUserId());

            var pictureUrl = FileHelper.GetFileName(user.UserName, picture);
            if (pictureUrl != null)
            {
                picture.SaveAs(Path.Combine(Server.MapPath("~"), "Upload\\Images", pictureUrl));
            }

            var recipe = new Recipes
            {
                CategoryID = model.RecipesDB.CategoryID,
                Title = model.RecipesDB.Title,
                HowToPrepare = model.RecipesDB.HowToPrepare,
                Ingredients = model.RecipesDB.Ingredients,
                PrepareTime = model.RecipesDB.PrepareTime,
                UserID = user.Id,
                FriendlyUrl = model.RecipesDB.Title.Replace(" ", "_"),
                PictureUrl = pictureUrl
            };
            db.Recipes.Add(recipe);
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category_ID,PageNumber,SumRating,RaitingCount,Title,Ingredients,PrepareTime,HowToPrepare,FriendlyUrl,PictureUrl")] Recipes recipes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipes);
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
