using iRestaurant2._0.Data;
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

        public virtual ICollection<IngredientInDish> IngredientsInDish { get; set; }
    }
}
