using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using Souped_Up.Data;
using Souped_Up.Models;
using Souped_Up.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Souped_Up.Controllers
{
    public class DishController : Controller
    {
        //readonly IDishRepo dishRepo;
        private IDishService DishService { get; set; }
        private IIngredientService IngredientService { get; set; }
        private ITagService TagService { get; set; }
        public DishController(IDishService dishService, ITagService tagService, IIngredientService ingredientService)
        {
            DishService = dishService;
            TagService = tagService;
            IngredientService = ingredientService;
        }
        // GET: Dish
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var model = DishService.GetUserDishes(userId);

            return View(model);
        }

        public ActionResult ListDish(DishViewListItemModel model)
        {
            return PartialView(model);
        }
        //GET
        public ActionResult Create()
        {
            DishViewCreateModel model = new DishViewCreateModel();
            return View(model);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishViewCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = Guid.Parse(User.Identity.GetUserId());

            if (DishService.Create(model))
            {
                TempData["SaveResult"] = "Your dish was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Dish could not be created.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var dish = DishService.GetDetails(id);
            return View(dish);
        }
        public ActionResult Edit(int id)
        {
            var model = DishService.GetEditById(id);
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DishViewEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (DishService.Update(model))
            {
                TempData["SaveResult"] = "Your dish was updated.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Dish could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var dish = DishService.GetDetails(id);
            return View(dish);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDish(int id)
        {
            DishService.Delete(id);

            TempData["SaveResult"] = "Your dish was deleted";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult GetIngredients([DataSourceRequest] DataSourceRequest request)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ingredients = IngredientService.GetUserIngredients(userId);

            return Json(ingredients.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetTags()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var tags = TagService.GetUserTags(userId);

            return Json(tags, JsonRequestBehavior.AllowGet);
        }
    }
}