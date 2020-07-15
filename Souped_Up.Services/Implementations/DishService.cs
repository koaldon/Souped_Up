using Souped_Up.Data;
using Souped_Up.Models;
using Souped_Up.Repos.Interfaces;
using Souped_Up.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Souped_Up.Services.Implementations
{
    public class DishService : IDishService
    {
        private IDishRepo dishRepo { get; set; }
        private IIngredientRepo ingredientRepo { get; set; }
        private ITagRepo tagRepo { get; set; }
        public DishService(IDishRepo dish, IIngredientRepo ingredient,ITagRepo tag, ApplicationDbContext context)
        {
            dishRepo = dish;
            ingredientRepo = ingredient;
            tagRepo = tag;
            dishRepo.Db = context;
            ingredientRepo.Db = context;
            tagRepo.Db = context;
        }

        //Create
        public bool Create(DishViewCreateModel model)
        {
            var ingredients = new List<Ingredient>();
            model.Ingredients.ForEach(x =>
            {
                ingredients.Add(ingredientRepo.GetById(x));
                
            });
            var tags = new List<Tag>();
            model.Tags.ForEach(x =>
            {
                tags.Add(tagRepo.GetById(x));
                
            });
            var dish = new Dish
            {
                UserId = model.UserId,
                Name = model.Name,
                Ingredients = ingredients,
                Tags=tags
                
            };
            dish = dishRepo.Create(dish);
            return dish.Id != 0;
        }
        //Read
        public Dish FindById(int id)
        {
            var dish = dishRepo.GetById(id);
            return dish;
        }
        public ICollection<Dish> GetUserDishSelectList(Guid id) //for use in creating Meals
        {
            var dishes = dishRepo.GetByUserId(id);
            return (dishes);
        }
        public DishViewListModel GetUserDishes(Guid id)
        {
            var dishes = dishRepo.GetByUserId(id);

            var model = new DishViewListModel();
            foreach (var dish in dishes)
            {
                model.Dishes.Add(new DishViewListItemModel
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Ingredients=dish.Ingredients,
                    Tags=dish.Tags
                });
            }
            return model;
        }
        public DishViewDetailModel GetDetails(int id)
        {
            var dish = dishRepo.GetById(id);
            var model = new DishViewDetailModel()
            {
                Id = dish.Id,
                Name = dish.Name,
                Ingredients = dish.Ingredients,
                Tags = dish.Tags
            };
            return model;
        }
        //Update
        public bool Update(DishViewEditModel model)
        {
            var dish = dishRepo.GetById(model.Id);
            var ingredients = new List<Ingredient>();
            model.Ingredients.ForEach(x =>
            {
                ingredients.Add(ingredientRepo.GetById(x));
                
            });
            var tags = new List<Tag>();
            model.Tags.ForEach(x =>
            {
                tags.Add(tagRepo.GetById(x));
                
            });
            dish.Name = model.Name;
            dish.Ingredients = (ICollection<Ingredient>)model.Ingredients;
            dish.Tags = (ICollection<Tag>)model.Tags;

            return dishRepo.Update(dish);


        }

        public DishViewEditModel GetEditById(int id)
        {
            var dish = dishRepo.GetById(id);
            var model = new DishViewEditModel
            {
                Name = dish.Name,
               //Ingredients = new SelectList(dish.Ingredients),
               // Tags = new SelectList(dish.Tags)
            };

            return model;
        }
        //Delete
        public bool Delete(int id)
        {
            return dishRepo.DeleteById(id);
        }

    }
}
