using iRestaurant2._0.Data;
using iRestaurant2._0.Models.IngredientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Models.DishModels
{
    public class DishDetail
    {
        public int DishID { get; set; }
        public string Name { get; set; }
        public List<IngredientListItem> IngredientsInDish { get; set; }
    }
}
