using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPPublished.Manager;
using WebPPublished.DTO;
using WebPPublished.Models;
using System.IO;

namespace WebPPublished.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(string friendlyUrl, string sortBy, int pageNumber = 1)
        {
            var manager = new CategoryManager();
            var model = new CategoriesListData
            {
                Recipes = manager.GetRecipesInCategory(friendlyUrl, sortBy, pageNumber),
                AllCategory = manager.GetAllCategory()
            };
            model.SelectedCategory = model.AllCategory.FirstOrDefault(c => c.FriendlyUrl == friendlyUrl);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Details(CategoriesListData model, int pageNumber = 1)
        {
            CategoryManager manager = new CategoryManager();
            model.AllCategory = manager.GetAllCategory();

            Recipes recipe = db.Recipes.Find(model.RecipesDB.ID);
            db.Recipes.Remove(recipe);
            System.IO.File.Delete(Path.Combine(Server.MapPath("~"), "Upload\\Images", recipe.PictureUrl));

            List<Comments> comments = new CommentManager().GetRecipeCommentsList(model.RecipesDB.ID);
            foreach (Comments comment in comments)
            {
                db.Comments.Remove(comment);
            }

            db.SaveChanges();
            Categories category = db.Categories.Find(model.SelectedCategory.ID);
            model.Recipes = manager.GetRecipesInCategory(category.FriendlyUrl, pageNumber);
            model.SelectedCategory = model.AllCategory.FirstOrDefault(c => c.FriendlyUrl == category.FriendlyUrl);
            return View(model);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DisplayName,FriendlyUrl")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categories);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = db.Categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DisplayName,FriendlyUrl")] CategoryHeaderData categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = db.Categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories categories = db.Categories.Find(id);
            db.Categories.Remove(categories);
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
