using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Data
{
    public class IngredientInDish
    {
        [Key]
        public int IngredientInDishID { get; set; }

        [ForeignKey("Dish")]
        public int DishID { get; set; }
        public virtual Dish Dish { get; set; }

        [ForeignKey("Ingredient")]
        public int IngredientID { get; set; }
        public virtual Ingredient Ingredient { get; set; }

    }
}
