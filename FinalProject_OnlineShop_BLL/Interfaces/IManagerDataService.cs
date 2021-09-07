using FinalProject_OnlineShop_BLL.VMs.ManagerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Interfaces
{
    interface IManagerDataService
    {
        bool UpdateManager(Guid ManagerId, OpenOrUpdateManagerDataVM editedData);
        OpenOrUpdateManagerDataVM GetManagerData(Guid ManagerId);
    }
}
