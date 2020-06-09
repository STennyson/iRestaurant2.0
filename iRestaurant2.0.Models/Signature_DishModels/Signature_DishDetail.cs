using iRestaurant2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Models.Signature_DishModels
{
    public class Signature_DishDetail
    {
        public int DishID { get; set; }
        public string Name { get; set; }
        public Chef Chef { get; set; } //might need a foreign key?
        public virtual ICollection<IngredientInDish> IngredientsInDish { get; set; }
    }
}
