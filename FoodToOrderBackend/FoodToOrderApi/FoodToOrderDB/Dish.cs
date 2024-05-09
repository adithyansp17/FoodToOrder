using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderDB;


public partial class Dish
{
    [Key]
    public int id { get; set; }

   
    public string dName { get; set; } 
    public bool isAvailable { get; set; }
    public int price { get; set; }
    public string img_path { get; set; }
    public int? r_id { get; set; }
    public Restaurant? restaurant { get; set; }

    public ICollection<OrderDish>? orderdish { get; set; }

    public ICollection<CartDish>? cartdish { get; set; }
}
