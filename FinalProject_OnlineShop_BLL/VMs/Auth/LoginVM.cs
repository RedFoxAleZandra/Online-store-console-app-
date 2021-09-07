using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.VMs.Auth
{
    public class LoginVM
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public bool Role { get; set; }

    }
}
