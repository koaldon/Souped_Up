using Souped_Up.Data;
using Souped_Up.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Souped_Up.Services.Interfaces
{
   public interface IIngredientService
    {
        bool Create(IngredientViewCreateModel ingredient);

        Ingredient FindById(int id);

        IngredientViewDetailModel GetDetails(int id);

        bool Update(IngredientViewEditModel model);

        IngredientViewEditModel GetEditById(int id);

        IEnumerable<IngredientViewListModel> GetUserIngredients(Guid id);

        ICollection<Ingredient> GetUserIngredientSelectList(Guid id);

        bool Delete(int id);
    }
}
