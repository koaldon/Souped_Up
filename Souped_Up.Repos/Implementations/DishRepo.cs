using Souped_Up.Data;
using Souped_Up.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Souped_Up.Repos.Implementations
{
    public class DishRepo : Repository<Dish>, IDishRepo
    {
        public DishRepo(ApplicationDbContext ctx)
        {
            Db = ctx;
        }
        public ICollection<Dish> GetByUserId(Guid id)
        {
            var dishes = Db.Set<Dish>().Include(d=>d.Ingredients).Where(x => x.UserId == id).ToList();
            return dishes;
        }
    }
}
