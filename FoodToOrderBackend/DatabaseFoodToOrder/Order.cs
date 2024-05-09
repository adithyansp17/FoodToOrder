using FoodToOrderAppWPF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderAppWPF
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        public int userId { get; set; }

        public DateTime orderDate { get; set; }

        public int orderAmount { get; set; }
        public ICollection<Dish>? arrDishes { get; set; }

        //public int[] quantity { get; set; }
    }
}
