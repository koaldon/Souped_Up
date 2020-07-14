using Souped_Up.Repos.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace Souped_Up.Repos.Implementations
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;
        public virtual T Create(T item) //Create
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
            return item;
        }

        public virtual bool DeleteById(int id) //Delete
        {
            var item = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(item);
           return _db.SaveChanges() == 1;
            
        }

        public virtual ICollection<T> Get() //Read
        {

            return _db.Set<T>().ToList();
        }

        public virtual T GetById(int id)  //Read
        {
            var item = _db.Set<T>().Find(id);
            return item;
        }

        public virtual bool Update(T item) //Update
        {
            _db.Set<T>().AddOrUpdate(item);
            return _db.SaveChanges()==1;
        }
    }
}
