using FoodToOrderAppWPF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderAppWPF
{
    public class Cart
    {
        [Key]
        public int id { get; set; }

        public int Amount { get; set; } 

        public ICollection<Dish>? arrDishes { get; set; }

        //public int[] quantity { get; set; }
    }
}
