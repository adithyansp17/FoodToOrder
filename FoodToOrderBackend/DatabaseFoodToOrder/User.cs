using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FoodToOrder_WebAPI.Helpers;

namespace FoodToOrderAppWPF;

public partial class User
{
    [Key]
    public int id { get; set; }

    public string firstName { get; set; } 

    public string lastName { get; set; } 

    public string role { get; set; } 

    public string email { get; set; } 

    public string password { get; set; }

   
    public DateTime DOB { get; set; }
}
