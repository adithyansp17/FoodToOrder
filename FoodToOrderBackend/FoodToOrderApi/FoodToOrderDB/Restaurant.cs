using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderDB;


[Table("Restaurant")]
public partial class Restaurant
{
    [Key]
    public int id { get; set; }

   
    public string rName { get; set; } 

 
    public bool ROpen { get; set; }

    public int? user_id { get; set; }
    public string location { get; set; }

    public string Type { get; set; }
    public ICollection<Dish>? dishlist { get; set; }
    public ICollection<Address>? arrAddress { get; set; }
}

 