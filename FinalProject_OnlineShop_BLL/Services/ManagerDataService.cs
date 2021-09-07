using FinalProject_OnlineShop_BLL.Interfaces;
using FinalProject_OnlineShop_BLL.VMs.ManagerData;
using FinalProject_OnlineShop_DAL;
using FinalProject_OnlineShop_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Services
{
    public class ManagerDataService : IManagerDataService
    {
        readonly AppDbContext db;

        public ManagerDataService()
        {
            db = new AppDbContext();
        }
        public ManagerDataService(AppDbContext _db)
        {
            db = _db;
        }


        public OpenOrUpdateManagerDataVM GetManagerData(Guid ManagerId)
        {
            db.Managers.Where(m => m.Id == ManagerId);
            OpenOrUpdateManagerDataVM result = new OpenOrUpdateManagerDataVM();

            return result;
        }

        public bool UpdateManager(Guid ManagerId, OpenOrUpdateManagerDataVM editedData)
        {
            db.Managers.Remove(new Manager() { Id = ManagerId });
            db.Managers.Add(new Manager() { Name = editedData.Name, Surname = editedData.Surname, DateOfBirth = editedData.DateOfBirth, Sex = editedData.Sex, RecruitmentDate = editedData.RecruitmentDate });
            db.SaveChanges();
            return true;
        }
    }
}
