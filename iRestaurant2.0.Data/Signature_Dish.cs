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
        
        [ForeignKey("SignatureChef")]
        public int ChefID { get; set; }
        public virtual Chef SignatureChef { get; set; }

    }
}
