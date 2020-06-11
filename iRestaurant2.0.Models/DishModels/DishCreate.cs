using iRestaurant2._0.Data;
using iRestaurant2._0.Models.IngredientInDishModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Models.DishModels
{
    public class DishCreate
    {
        [Required]
        public string Name { get; set; }

        public int[] IngredientsInDish { get; set; } = new int[100]; //maybe get with Casey to clean this up later, low priority
    }
}
