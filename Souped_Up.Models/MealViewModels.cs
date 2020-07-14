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
    public class MealViewListModel
    {
        public List<MealViewListItemModel> Meals { get; set; }

        public MealViewListModel()
        {
            Meals = new List<MealViewListItemModel>();
        }
    }
    public class MealViewCreateModel //Create
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }
        public SelectList Tags { get; set; }
        public SelectList Dishes { get; set; }
        public Guid UserId { get; set; }

        public MealViewCreateModel()
        {
            Dishes = new SelectList(new List<Dish>());
            Tags = new SelectList(new List<Tag>());
        }
    }
    public class MealViewDetailModel //Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public string DisplayTags { get => string.Join(" | ", Tags.Select(t => t.Name)); }

        public MealViewDetailModel()
        {
           
        }

    }
    public class MealViewEditModel //Edit
    {

        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }
        public SelectList Tags { get; set; }
        public SelectList Dishes { get; set; }
    }
    public class MealViewListItemModel //ListItem
    {
        public MealViewListItemModel()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Dish> Dishes { get; set; }

        public string DisplayTags { get =>Tags==null ? string.Empty : string.Join(" | ", Tags.Select(t => t.Name)); }
    }
}
