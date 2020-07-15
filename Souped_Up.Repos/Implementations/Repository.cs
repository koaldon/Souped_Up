using Souped_Up.Repos.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace Souped_Up.Repos.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public DbContext Db { get; set; }
        public virtual T Create(T item) //Create
        {
            Db.Set<T>().Add(item);
            Db.SaveChanges();
            return item;
        }

        public virtual bool DeleteById(int id) //Delete
        {
            var item = Db.Set<T>().Find(id);
            Db.Set<T>().Remove(item);
           return Db.SaveChanges() == 1;
            
        }

        public virtual ICollection<T> Get() //Read
        {

            return Db.Set<T>().ToList();
        }

        public virtual T GetById(int id)  //Read
        {
            var item = Db.Set<T>().Find(id);
            return item;
        }

        public virtual bool Update(T item) //Update
        {
            Db.Set<T>().AddOrUpdate(item);
            return Db.SaveChanges()==1;
        }
    }
}
