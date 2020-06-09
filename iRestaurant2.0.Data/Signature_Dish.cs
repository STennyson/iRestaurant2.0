using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Data
{
    public class Signature_Dish : Dish
    {
        [Key]
        public int Signature_DishID { get; set; }
        
        //[ForeignKey("Chef")]
        //public int ChefID { get; set; }
        //[Required]
        //public virtual Chef Chef { get; set; } = new Chef();

    }
}
