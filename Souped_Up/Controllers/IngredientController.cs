using Microsoft.AspNet.Identity;
using Souped_Up.Models;
using Souped_Up.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Souped_Up.Controllers
{
    public class IngredientController : Controller
    {
        //readonly IIngredientRepo ingredientRepo;
        private IIngredientService IngredientService { get; set; }
        public IngredientController(IIngredientService ingredientService)
        {
            IngredientService = ingredientService;
        }
        // GET: Ingredient
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var model = IngredientService.GetUserIngredients(userId);

            return View(model);
        }
        public ActionResult ListIngredient(IngredientViewListItemModel model)
        {
            return PartialView(model);
        }
        //GET
        public ActionResult Create()
        {
            IngredientViewCreateModel model = new IngredientViewCreateModel();
            return View(model);
        }
        
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientViewCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = Guid.Parse(User.Identity.GetUserId());

            if (IngredientService.Create(model))
            {
                TempData["SaveResult"] = "Your ingredient was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Ingredient could not be created.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var meal = IngredientService.GetDetails(id);
            return View(meal);
        }
        public ActionResult Edit(int id)
        {
            var model = IngredientService.GetEditById(id);
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientViewEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (IngredientService.Update(model))
            {
                TempData["SaveResult"] = "Your ingredient was updated.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Ingredient could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var ingredient = IngredientService.GetDetails(id);
            return View(ingredient);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIngredient(int id)
        {
            IngredientService.Delete(id);

            TempData["SaveResult"] = "Your ingredient was deleted";

            return RedirectToAction("Index");
        }

    }
}