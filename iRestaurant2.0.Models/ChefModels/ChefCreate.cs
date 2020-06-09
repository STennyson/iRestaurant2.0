using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Models.ChefModels
{
    public class ChefCreate
    {
        [Required]
        public string Full_Name { get; set; }
        public string Speciality { get; set; }
        public int Signature_DishID { get; set; }
    }
}
