using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebPPublished.DTO;
using WebPPublished.Manager;
using WebPPublished.Models;

namespace WebPPublished.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Comments(int recipeId, int pageNumber = 1)
        {
            var model = new CategoriesListData();
            model.SelectedRecipe = new RecipeManager().GetRecipeHeaderData(recipeId);
            model.Comments = new CommentManager().GetRecipeComments(recipeId, pageNumber);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Comments(CategoriesListData model, int pageNumber = 1)
        {
            model.SelectedRecipe = new RecipeManager().GetRecipeHeaderData(model.CommentsDB.RecipesId);
            Comments comment = db.Comments.Find(model.CommentsDB.Id);
            if(comment != null)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();
            }
            model.Comments = new CommentManager().GetRecipeComments(model.SelectedRecipe.ID, pageNumber);
            return View(model);
        }

        public ActionResult ListComments(int recipeId, int pageNumber = 1)
        {
            var model = new CategoriesListData();
            model.Comments = new CommentManager().GetRecipeComments(recipeId, pageNumber);
            model.SelectedRecipe = new RecipeManager().GetRecipeHeaderData(recipeId);
            return PartialView(model);
        }

        // GET: Comments/Create
        public ActionResult Create(int recipeId)
        {
            var model = new CategoriesListData();
            model.SelectedRecipe = new RecipeManager().GetRecipeHeaderData(recipeId);
            model.CommentsDB = new Comments();
            return PartialView(model);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoriesListData model)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = await userManager.FindByIdAsync(User.Identity.GetUserId());

                var comment = new Comments
                {
                    CreatedDate = Convert.ToDateTime(DateTime.Now.ToString(new CultureInfo("hu-HU"))),
                    UserId = user.Id,
                    RecipesId = model.SelectedRecipe.ID,
                    Text = model.CommentsDB.Text
                };
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            return PartialView(model);
        }

        public ActionResult Edit(int? commentId)
        {
            if (commentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comment = db.Comments.Find(commentId);
            var model = new CategoriesListData();
            model.CommentsDB = comment;
            if (comment == null)
            {
                return HttpNotFound();
            }
            return PartialView(model);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesListData model)
        {
            if (ModelState.IsValid)
            {
                model.CommentsDB.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString(new CultureInfo("hu-HU")));
                db.Entry(model.CommentsDB).State = EntityState.Modified;
                db.SaveChanges();
            }
            return PartialView(model);
        }
    }
}