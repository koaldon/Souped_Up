﻿using Microsoft.AspNet.Identity;
using Souped_Up.Data;
using Souped_Up.Models;
using Souped_Up.Repos.Interfaces;
using Souped_Up.Services.Implementations;
using Souped_Up.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Souped_Up.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        // readonly IMealRepo mealRepo;
        private IMealService MealService { get; set; }
        private IDishService DishService { get; set; }
        private ITagService TagService { get; set; }
        public MealController(IMealService mealService, IDishService dishService, ITagService tagService)
        {
            MealService = mealService;
            DishService = dishService;
            TagService = tagService;
        }
        // GET: Meal
        public ActionResult Index()
        {


            var userId = Guid.Parse(User.Identity.GetUserId());
            var model = MealService.GetUserMeals(userId);

            return View(model);
        }
        public ActionResult ListMeal(MealViewListItemModel model)
        {
            return PartialView(model);
        }

        //GET
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dishes = DishService.GetUserDishSelectList(userId);
            var tags = TagService.GetUserTagSelectList(userId);
            MealViewCreateModel model = new MealViewCreateModel();
            model.DishData = dishes.ToList();
            model.TagData = tags.ToList();
            return View(model);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealViewCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = Guid.Parse(User.Identity.GetUserId());

            if (MealService.Create(model))
            {
                TempData["SaveResult"] = "Your meal was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Meal could not be created.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var meal = MealService.GetDetails(id);
            return View(meal);
        }

        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var model = MealService.GetEditById(id);
            var dishes = DishService.GetUserDishSelectList(userId);
            var tags = TagService.GetUserTagSelectList(userId);

            model.DishData = dishes.ToList();
            model.TagData = tags.ToList();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealViewEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            MealService.Update(model);
            TempData["SaveResult"] = "Your meal was updated.";
            return RedirectToAction("Index");

        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = MealService.GetDetails(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMeal(int id)
        {
            MealService.Delete(id);

            TempData["SaveResult"] = "Your meal was deleted";

            return RedirectToAction("Index");
        }
        public JsonResult GetDishes()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dishes = DishService.GetUserDishes(userId);

            return Json(dishes, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTags()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var tags = TagService.GetUserTags(userId);

            return Json(tags, JsonRequestBehavior.AllowGet);
        }
    }
}