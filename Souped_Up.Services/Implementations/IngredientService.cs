using Souped_Up.Data;
using Souped_Up.Models;
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
   public class IngredientService : IIngredientService
    {
        private IIngredientRepo ingredientRepo { get; set; }

        public IngredientService(IIngredientRepo ingredient)
        {
            ingredientRepo = ingredient;
        }
        //Create
        public bool Create(IngredientViewCreateModel model)
        {
            var ingredient = new Ingredient
            {
                UserId = model.UserId,
                Name = model.Name
            };
            ingredient = ingredientRepo.Create(ingredient);
            return ingredient.Id != 0;
        }
        //Read
        public Ingredient FindById(int id)
        {
            var ingredient = ingredientRepo.GetById(id);
            return ingredient;
        }
        public ICollection<Ingredient> GetUserIngredientSelectList(Guid id)
        {
            var ingredients = ingredientRepo.GetByUserId(id);
            return (ingredients);
        }
        public IEnumerable<IngredientViewListModel> GetUserIngredients(Guid id)
        {
            var ingredients = ingredientRepo.GetByUserId(id);

            var models = new List<IngredientViewListModel>();
            foreach (var ingredient in ingredients)
            {
                var model = new IngredientViewListModel()
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name
                };
                models.Add(model);
            }
            return models;
        }
        public IngredientViewDetailModel GetDetails(int id)
        {
            var ingredient = ingredientRepo.GetById(id);
            var model = new IngredientViewDetailModel()
            {
                Id = ingredient.Id,
                Name = ingredient.Name                
            };
            return model;
        }

        //Update
        public bool Update(IngredientViewEditModel model)
        {
            var ingredient = ingredientRepo.GetById(model.Id);

            ingredient.Name = model.Name;
  
            return ingredientRepo.Update(ingredient);
        }

        public IngredientViewEditModel GetEditById(int id)
        {
            var ingredient = ingredientRepo.GetById(id);
            var model = new IngredientViewEditModel
            {
                Name = ingredient.Name                
            };

            return model;
        }
        //Delete
        public bool Delete(int id)
        {
            return ingredientRepo.DeleteById(id);
        }
    }
}
