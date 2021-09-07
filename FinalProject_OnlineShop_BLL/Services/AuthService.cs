using FinalProject_OnlineShop_BLL.Interfaces;
using FinalProject_OnlineShop_BLL.VMs.Auth;
using FinalProject_OnlineShop_DAL;
using FinalProject_OnlineShop_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Services
{
    public class AuthService : IAuthService

    {
        readonly AppDbContext db;

        public AuthService()
        {
            db = new AppDbContext();
        }
        public AuthService(AppDbContext _db)
        {
            db = _db;
        }


        public bool LogIn(LoginVM currUser)
        {
            
                var AuthDB = db.Authes.ToList();
                var currentUserId = AuthDB.SingleOrDefault(m => m.Login == currUser.Login && m.PasswordHash == currUser.PasswordHash);
                if (currentUserId == null)
                {
                    throw new Exception("Login or password is wrong. Please, try again");
                }
                else
                {
                    if (currUser.Role == currentUserId.Role)
                    {

                    }
                    else
                    {
                        throw new Exception("Нou have chosen the wrong role. Please try again.");
                    }

                    return currentUserId.Role;
                } 
        }

        public bool RegisterCustomer(RegistrationCustomerVM newCustomer)
        {
            try
            {

                db.Authes.Add(new Auth() { Login = newCustomer.Login, PasswordHash = newCustomer.PasswordHash,  Id = newCustomer.Id, Role = newCustomer.Role });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool RegisterCustomerData(RegistrationCustomerDataVM newCustomerdata)
        {
            try
            {
                var newCustomer = new Customer()
                {
                    Name = newCustomerdata.Name,
                    Surname = newCustomerdata.Surname,
                    DateOfBirth = newCustomerdata.DateOfBirth,
                    Sex = newCustomerdata.Sex,
                    Location = newCustomerdata.Location,
                    CardNumber = newCustomerdata.CardNumber,
                    PhoneNumber = newCustomerdata.PhoneNumber,
                    AuthId = newCustomerdata.AuthId,
                    Id = Guid.NewGuid(),
                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool RegisterManager(RegistrationManagerVM newManager)
        {
            try
            {
                db.Authes.Add(new Auth() { Login = newManager.Login, PasswordHash = newManager.PasswordHash,  Id = newManager.Id, Role = newManager.Role });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RegisterManagerData(RegistrationManagerDataVM newManagerdata)
        {
            try
            {
                db.Managers.Add(new Manager() 
                { Name = newManagerdata.Name, 
                    Surname = newManagerdata.Surname, 
                    DateOfBirth = newManagerdata.DateOfBirth, 
                    Sex = newManagerdata.Sex, 
                    RecruitmentDate = newManagerdata.RecruitmentDate, 
                    AuthId = newManagerdata.AuthId, 
                    Id = Guid.NewGuid() 
                });

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
