using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodToOrderAppWPF;

public partial class Restaurant
{
    [Key]
    public int Id { get; set; }

    public string Rname { get; set; } = null!;

    public bool Ropen { get; set; }

    public int UserId { get; set; }
}
