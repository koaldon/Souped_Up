using Souped_Up.Data;
using Souped_Up.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Services.Interfaces
{
    public interface IMealService
    {
        bool Create(MealViewCreateModel model);

        Meal FindById(int id);

        MealViewDetailModel GetDetails(int id);

        bool Update(MealViewEditModel model);

        MealViewEditModel GetEditById(int id);

        MealViewListModel GetUserMeals(Guid id);

        bool Delete(int id);
    }
}
