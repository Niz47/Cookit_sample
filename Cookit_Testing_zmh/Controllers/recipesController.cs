using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cookit_Testing_zmh.Models;
using Microsoft.AspNet.Identity;

namespace Cookit_Testing_zmh.Controllers
{
    public class recipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: recipes
        public ActionResult Index()
        {
            string username = User.Identity.GetUserName();
            var recipes = db.recipes.ToList();
            List<FavouriteRecipeVM> favRecipeVM = new List<FavouriteRecipeVM>();
            if (!string.IsNullOrEmpty(username))
            {
                int userid = db.user_list.Where(x => x.user_email == username).FirstOrDefault().userid;

                foreach (recipe r in recipes)
                {
                    FavouriteRecipeVM recipevm = new FavouriteRecipeVM(r);
                    fav_recipe fav = db.fav_recipe.Where(x => x.fav_recipe_id == r.recipe_id && x.userid == userid).FirstOrDefault();
                    if (fav != null) recipevm.favourite = true;
                    favRecipeVM.Add(recipevm);
                }
            }
            else
            {
                foreach (recipe r in recipes)
                {
                    FavouriteRecipeVM recipevm = new FavouriteRecipeVM(r);
                    favRecipeVM.Add(recipevm);
                }
            }

            return View(favRecipeVM);
        }

        [HttpPost]
        public JsonResult Favorite(string recipeid, string action)
        {
            string username = User.Identity.GetUserName();
            int userid = 0;
            if (!string.IsNullOrEmpty(username)) userid = db.user_list.Where(x => x.user_email == username).FirstOrDefault().userid;
            if (userid > 0)
            {
                int rid = Int32.Parse(recipeid);
                fav_recipe fav = db.fav_recipe.Where(x => x.userid == userid && x.recipe_id == rid).FirstOrDefault();
                if (action == "add" && fav == null)
                {
                    fav = new fav_recipe();
                    fav.recipe_id = rid;
                    fav.userid = userid;
                    db.fav_recipe.Add(fav);
                }
                else if (action == "remove" && fav != null)
                {
                    db.fav_recipe.Remove(fav);
                }
                db.SaveChanges();
                return Json("Success");
            }
            return Json("Invalid User!");
        }

        public ActionResult GrocerySave()
        {
            string tmp_name = User.Identity.GetUserName();
            var userid = db.user_list.Where(x => x.user_email == tmp_name).FirstOrDefault().userid;
            return View(db.grocery_list.Where(x => x.userid == userid).ToList());
        }
        [HttpPost]
        public ActionResult GrocerySave(grocery_list model)
        {
            if (model != null)
            {
                db.grocery_list.Add(model);
                string tmp_name = User.Identity.GetUserName();
                user_list user = db.user_list.Where(x => x.user_email == tmp_name).FirstOrDefault();
                model.userid = user.userid;
                db.SaveChanges();
                return Json(model.grocery_id);
            }
            return Json("An Error Has occoured");
        }

        [HttpPost]
        public ActionResult GroceryDelete(string groceryid)
        {
            if (!string.IsNullOrEmpty(groceryid))
            {
                int gid = Int32.Parse(groceryid);
                grocery_list glist = db.grocery_list.Where(x => x.grocery_id == gid).FirstOrDefault();
                if(glist != null)
                {
                    db.grocery_list.Remove(glist);
                    db.SaveChanges();
                    return Json("Success");
                }
            }
            return Json("An Error Has occoured");
        }

        // GET: recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recipe recipe = db.recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recipe_id,ImageName,ImagePath,recipe_name")] recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recipe recipe = db.recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recipe_id,ImageName,ImagePath,recipe_name")] recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recipe recipe = db.recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recipe recipe = db.recipes.Find(id);
            db.recipes.Remove(recipe);
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
