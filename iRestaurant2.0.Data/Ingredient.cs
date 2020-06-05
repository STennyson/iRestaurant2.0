using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Data
{
    public enum IngredientType { Vegetable, Protein, Grain, Spice, Fruit, Dairy }
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IngredientType Type { get; set; }

        public virtual ICollection<IngredientInDish> IngredientsInDish { get; set; } //you need a joining table

    }
}
