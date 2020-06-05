using iRestaurant2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Models.ChefModels
{
    public class ChefListItem
    {
        public int ChefID { get; set; }
        public string Full_Name { get; set; }
        public string Speciality { get; set; }
        public Signature_Dish SignatureDish { get; set; }
    }
}
