using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderDB
{
    public class Address
    {
        [Key]
        public int id { get; set; }
        public string houseno { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string country { get; set; }
        public string street { get; set; }
        public string pincode { get; set; }
        public int? r_id { get; set; }
        public Restaurant? restaurant { get; set; }
        public int? u_id { get; set; }
        public User? User { get; set; }

    }
}
