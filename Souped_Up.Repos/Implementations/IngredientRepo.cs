﻿using Souped_Up.Data;
using Souped_Up.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Souped_Up.Repos.Implementations
{
    public class IngredientRepo : Repository<Ingredient>, IIngredientRepo
    {
        public IngredientRepo(ApplicationDbContext ctx)
        {
            Db = ctx;
        }
        public ICollection<Ingredient>GetByUserId(Guid id)
        {
            var ingredients = Db.Set<Ingredient>().Where(x => x.UserId == id).ToList();
            return ingredients;
        }
    }
}
