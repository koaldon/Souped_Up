using Souped_Up.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Models
{
    public class IngredientViewListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class IngredientViewCreateModel //Create
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
    public class IngredientViewDetailModel //Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        

    }
    public class IngredientViewEditModel //Edit
    {

        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }
        
    }
    public class IngredientViewListItemModel //ListItem
    {
        public IngredientViewListItemModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
