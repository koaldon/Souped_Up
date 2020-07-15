using Souped_Up.Data;
using Souped_Up.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Souped_Up.Repos.Implementations
{
    public class TagRepo : Repository<Tag>, ITagRepo
    {
        public TagRepo(ApplicationDbContext ctx)
        {
            Db = ctx;
        }
        public ICollection<Tag> GetByUserId(Guid id)
        {
            var tags = Db.Set<Tag>().Where(x => x.UserId == id).ToList();
            return tags;
        }
    }
}
