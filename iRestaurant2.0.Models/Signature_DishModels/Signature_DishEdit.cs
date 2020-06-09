using iRestaurant2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Models.Signature_DishModels
{
    public class Signature_DishEdit
    {
        public int DishID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<IngredientInDish> IngredientsInDish { get; set; }
    }
}
