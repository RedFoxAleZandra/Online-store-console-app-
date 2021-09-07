using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.VMs.Auth
{
    public class RegistrationManagerVM
    {
        public Guid Id { get; set; }

        public string PasswordHash { get; set; }
        public string Login { get; set; }
        public bool Role { get; set; }

    }
}
