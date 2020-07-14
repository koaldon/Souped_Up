using Souped_Up.Data;
using Souped_Up.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Services.Interfaces
{
   public interface IDishService
    {
        bool Create(DishViewCreateModel model);

        Dish FindById(int id);

        DishViewDetailModel GetDetails(int id);

        bool Update(DishViewEditModel model);

        DishViewEditModel GetEditById(int id);

        DishViewListModel GetUserDishes(Guid id);

        bool Delete(int id);

    }
}
