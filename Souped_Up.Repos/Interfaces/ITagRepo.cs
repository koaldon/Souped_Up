using Souped_Up.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Repos.Interfaces
{
   public interface ITagRepo : IRepository<Tag>
    {
        ICollection<Tag> GetByUserId(Guid id);
    }
}
