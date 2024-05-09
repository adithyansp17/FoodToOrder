using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderDB
{
    public class CartDish
    {
        public int? c_id {  get; set; }
        public Cart? Cart { get; set; }
        public int? d_id { get; set; }
        public Dish? dish { get; set; }
        public int quantity { get; set; }

    }
}
