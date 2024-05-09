using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderDB
{
    public class Cart
    {
        [Key]
        public int id { get; set; }

        public int Amount { get; set; }

        public ICollection<CartDish>? cartdish { get; set; }

        public int? userid { get; set; }

        public User? User { get; set; }

        //public int[] quantity { get; set; }
    }
}
