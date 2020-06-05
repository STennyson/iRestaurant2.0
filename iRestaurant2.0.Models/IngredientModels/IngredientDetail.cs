using iRestaurant2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Models.IngredientModels
{
    public class IngredientDetail
    {
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
    }
}
