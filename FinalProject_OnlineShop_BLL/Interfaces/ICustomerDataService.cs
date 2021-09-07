using FinalProject_OnlineShop_BLL.VMs.CustomerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Interfaces
{
    interface ICustomerDataService
    {
        OpenOrUpdateCustomerdataVM GetCustomerData(Guid customerId);
        bool UpdateCutstomerName(Guid customerId, string updatedName);
        bool UpdateCustomerSurname(Guid customerId, string updatedSurname);
        bool UpdateCustomerDateOfBirth(Guid customerId, DateTime updatedDate);
        bool UpdateCustomerPhone(Guid customerId, string updatedPhone);
        bool UpdateCustomerCardNumber(Guid customerId, string updatedCard);
        bool UpdateCustomerLocation(Guid customerId, string updatedLocation);
    }
}
