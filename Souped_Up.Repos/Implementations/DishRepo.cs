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
            _db = ctx;
        }
        public ICollection<Dish> GetByUserId(Guid id)
        {
            var dishes = _db.Set<Dish>().Where(x => x.UserId == id).ToList();
            return dishes;
        }
    }
}
