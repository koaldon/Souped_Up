using Souped_Up.Data;
using Souped_Up.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Services.Interfaces
{
   public interface ITagService
    {
        bool Create(TagViewCreateModel model);

        Tag FindById(int id);

        TagViewDetailModel GetDetails(int id);

        bool Update(TagViewEditModel model);

        TagViewEditModel GetEditById(int id);

       IEnumerable<TagViewListModel> GetUserTags(Guid id);

        bool Delete(int id);
    }
}
