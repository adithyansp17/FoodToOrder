using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrderDB
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string role { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public DateTime DOB { get; set; }

        public Address? Address { get; set; }

        public Cart? Cart { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
