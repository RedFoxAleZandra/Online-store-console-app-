using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_Models
{
    public class Auth : BaseEntity
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public bool Role { get; set; }
    }
}
