using Souped_Up.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Repos.Interfaces
{
    public interface IDishRepo :IRepository<Dish>
    {
        ICollection<Dish> GetByUserId(Guid id);
    }
}
