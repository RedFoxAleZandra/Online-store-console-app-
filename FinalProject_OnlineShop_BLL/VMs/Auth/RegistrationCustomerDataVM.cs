using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.VMs.Auth
{
    public class RegistrationCustomerDataVM
    {
        public Guid AuthId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public string Location { get; set; }
        public bool Role { get; set; }

    }
}
