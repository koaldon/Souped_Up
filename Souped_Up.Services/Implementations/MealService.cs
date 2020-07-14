using Souped_Up.Data;
using Souped_Up.Models;
using Souped_Up.Repos.Implementations;
using Souped_Up.Repos.Interfaces;
using Souped_Up.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Souped_Up.Services.Implementations
{
    public class MealService : IMealService
    {
        private IMealRepo mealRepo { get; set; }

        public MealService(IMealRepo meal)
        {
            mealRepo = meal;
        }

        //Create
        public bool Create(MealViewCreateModel model)
        {
            var meal = new Meal
            {
                UserId = model.UserId,
                Name = model.Name,
                Dishes = (ICollection<Dish>)(model.Dishes == null ? new List<Dish>() : model.Dishes.SelectedValues),
                Tags = (ICollection<Tag>)(model.Tags == null ? new List<Tag>() : model.Tags.SelectedValues)
            };
            meal = mealRepo.Create(meal);
            return meal.Id != 0;
        }
        //Read
        public Meal FindById(int id)
        {
            var meal = mealRepo.GetById(id);
            return meal;
        }
        public MealViewListModel GetUserMeals(Guid id)
        {
            var meals = mealRepo.GetByUserId(id);

            var model = new MealViewListModel();
            foreach (var meal in meals)
            {
                model.Meals.Add(new MealViewListItemModel
                {
                    Id = meal.Id,
                    Name = meal.Name
                });
            }
            return model;
        }
        public MealViewDetailModel GetDetails(int id)
        {
            var meal = mealRepo.GetById(id);
            var model = new MealViewDetailModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Dishes = meal.Dishes,
                Tags = meal.Tags
            };
            return model;
        }

        //Update
        public bool Update(MealViewEditModel model)
        {
            var meal = mealRepo.GetById(model.Id);

            meal.Name = model.Name;
           //meal.Dishes = model.Dishes;
            //meal.Tags = model.Tags;

            return mealRepo.Update(meal);

        }

        public MealViewEditModel GetEditById(int id)
        {
            var meal = mealRepo.GetById(id);
            var model = new MealViewEditModel
            {
                Name = meal.Name,
                Dishes = new SelectList(meal.Dishes),
                Tags = new SelectList(meal.Tags)
            };

            return model;
        }
        //Delete
        public bool Delete(int id)
        {
           return mealRepo.DeleteById(id);
        }

    }
}
