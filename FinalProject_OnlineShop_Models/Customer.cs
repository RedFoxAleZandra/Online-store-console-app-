using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_Models
{
    public class Customer : Person
    {
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public string Location { get; set; }
        public virtual List<Order> Orders { get; set; }


    }
}
