﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Data
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Please use less than 100 characters.")]
        public string Name { get; set; }

        //UserId Foreign Key
        public Guid UserId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Dish> Dishes { get; set; }

        public Ingredient()
        {
            Dishes = new HashSet<Dish>();
        }
    }
}
