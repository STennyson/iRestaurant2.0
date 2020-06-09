using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Data
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<IngredientInDish> IngredientsInDish { get; set; } = new List<IngredientInDish>();


    }
}
