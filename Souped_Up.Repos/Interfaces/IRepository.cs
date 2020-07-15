using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Repos.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Create(T item);

        bool Update(T item);

        T GetById(int id);

        ICollection<T>Get();

        bool DeleteById(int id);

        DbContext Db { get; set; }
    }
}
