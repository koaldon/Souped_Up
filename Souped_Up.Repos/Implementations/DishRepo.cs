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
        public override Dish GetById(int id)  
        {
            var item = Db.Set<Dish>().Include(x=>x.Ingredients).Include(x=>x.Tags).FirstOrDefault(x=>x.Id==id);
            return item;
        }
    }
}
