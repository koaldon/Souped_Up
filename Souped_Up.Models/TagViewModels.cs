using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Models
{
    public class TagViewListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class TagViewCreateModel //Create
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
    public class TagViewDetailModel //Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class TagViewEditModel //Edit
    {

        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class TagViewListItemModel //ListItem
    {
        public TagViewListItemModel()
        {
                
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

