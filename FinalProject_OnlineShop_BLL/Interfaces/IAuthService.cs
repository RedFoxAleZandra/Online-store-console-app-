using FinalProject_OnlineShop_BLL.VMs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Interfaces
{
    interface IAuthService
    {
        bool RegisterManager(RegistrationManagerVM newManager);
        bool RegisterCustomer(RegistrationCustomerVM newCustomer);
        bool RegisterManagerData(RegistrationManagerDataVM newManagerdata);
        bool RegisterCustomerData(RegistrationCustomerDataVM newCustomerdata);
        bool LogIn(LoginVM currUser);
    }
}
