using Souped_Up.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Souped_Up.Models
{
    public class DishViewListModel
    {
        public List<DishViewListItemModel> Dishes { get; set; }

        public DishViewListModel()
        {
            Dishes = new List<DishViewListItemModel>();
        }
    }
    public class DishViewCreateModel //Create
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }
        public List<int> Tags { get; set; }
        public List<int> Ingredients { get; set; }
        public List<Ingredient>IngredientData { get; set; }
        public List<Tag> TagData { get; set; }
        public Guid UserId { get; set; }

        public DishViewCreateModel()
        {
            Ingredients = new List<int>();
            Tags = new List<int>();
        }
    }
    public class DishViewDetailModel //Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public string DisplayTags { get => string.Join(" | ", Tags.Select(t => t.Name)); }

        public DishViewDetailModel()
        {
           
        }

    }
    public class DishViewEditModel //Edit
    {

        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }
        public List<int> Tags { get; set; }
        public List<int> Ingredients { get; set; }
        public List<Ingredient> IngredientData { get; set; }
        public List<Tag> TagData { get; set; }

        public DishViewEditModel()
        {
            Ingredients = new List<int>();
            Tags = new List<int>();
        }
    }
    public class DishViewListItemModel //ListItem
    {
        public DishViewListItemModel()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }

        public string DisplayTags { get =>Tags==null ? string.Empty : string.Join(" | ", Tags.Select(t => t.Name)); }
    }
}
