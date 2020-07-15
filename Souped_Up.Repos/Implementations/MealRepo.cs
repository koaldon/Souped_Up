using Souped_Up.Data;
using Souped_Up.Repos.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Souped_Up.Repos.Implementations
{
    public class MealRepo : Repository<Meal>, IMealRepo
    {
        public MealRepo(ApplicationDbContext ctx)
        {
            Db = ctx;
        }

        public ICollection<Meal> GetByUserId(Guid id)
        {
            var meals = Db.Set<Meal>().Where(x => x.UserId == id).ToList();
            return meals;
        }
    }
}
