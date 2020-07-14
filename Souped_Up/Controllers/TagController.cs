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
    [Authorize]
    public class TagController : Controller
    {
        //readonly ITagRepo tagRepo
        private ITagService TagService { get; set; }
        public TagController(ITagService tagService)
        {
            TagService = tagService;
        }
        // GET: Tag
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var model =TagService.GetUserTags(userId);

            return View(model);
        }
        public ActionResult ListTag(TagViewListItemModel model)
        {
            return PartialView(model);
        }
        //GET
        public ActionResult Create()
        {
            TagViewCreateModel model = new TagViewCreateModel();
            return View(model);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TagViewCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = Guid.Parse(User.Identity.GetUserId());

            if (TagService.Create(model))
            {
                TempData["SaveResult"] = "Your tag was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Tag could not be created.");
            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var tag = TagService.GetDetails(id);
            return View(tag);
        }

        public ActionResult Edit(int id)
        {
            var model = TagService.GetEditById(id);
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TagViewEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (TagService.Update(model))
            {
                TempData["SaveResult"] = "Your tag was updated.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Tag could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var tag = TagService.GetDetails(id);
            return View(tag);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTag(int id)
        {
            TagService.Delete(id);

            TempData["SaveResult"] = "Your tag was deleted";

            return RedirectToAction("Index");
        }

    }
}