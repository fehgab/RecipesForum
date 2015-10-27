using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebPPublished.DTO;
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
            return View(model);
        }

        private string GetUserId()
        {
            var manager = new UserManager();
            string id = manager.GetUserIdByName(User.Identity.Name);
            return id;
        }
        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Category_ID,Title,Ingredients,PrepareTime,HowToPreparel,PictureUrl")] Recipes model)
        {
            var list = new CategoriesListData();
            list.AllCategory = new CategoryManager().GetAllCategory();
            list.RecipesDB = model;
            if (ModelState.IsValid)
            {
                var recipe = new Recipes
                {
                    CategoryID = model.CategoryID,
                    Title = model.Title,
                    HowToPrepare = model.HowToPrepare,
                    Ingredients = model.Ingredients,
                    PrepareTime = model.PrepareTime,
                    UserID = GetUserId(),
                    FriendlyUrl = model.Title.Replace(" ","_"),
                    PictureUrl = model.PictureUrl
                };
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Details");
             }
        return View(list);
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
