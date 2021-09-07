using FinalProject_OnlineShop_BLL.Interfaces;
using FinalProject_OnlineShop_BLL.VMs.CustomerData;
using FinalProject_OnlineShop_DAL;
using FinalProject_OnlineShop_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        readonly AppDbContext db;

        public CustomerDataService()
        {
            db = new AppDbContext();
        }
        public CustomerDataService(AppDbContext _db)
        {
            db = _db;
        }


        public OpenOrUpdateCustomerdataVM GetCustomerData(Guid customerId)
        {
            
            var customerData = db.Customers.FirstOrDefault(m => m.Id == customerId);

            OpenOrUpdateCustomerdataVM result = new OpenOrUpdateCustomerdataVM()
            { 
            Name = customerData.Name,
            Surname = customerData.Surname,
            DateOfBirth = customerData.DateOfBirth,
            CardNumber = customerData.CardNumber,
            Id = customerData.Id,
            Location = customerData.Location,
            PhoneNumber =customerData.PhoneNumber
            };

            return result; 
        }

        public bool UpdateCutstomerName(Guid customerId, string updatedName)
        {
            var customerDb = db.Customers.ToList();
            var updatedCustomer = customerDb.FirstOrDefault(m => m.Id == customerId);
            updatedCustomer.Name = updatedName;
            db.SaveChanges();

            return true;
        }

        public bool UpdateCustomerSurname(Guid customerId, string updatedSurname)
        {
            var customerDb = db.Customers.ToList();
            var updatedCustomer = customerDb.FirstOrDefault(m => m.Id == customerId);
            updatedCustomer.Surname = updatedSurname;
            db.SaveChanges();

            return true;
        }

        public bool UpdateCustomerDateOfBirth(Guid customerId, DateTime updatedDate)
        {
            var customerDb = db.Customers.ToList();
            var updatedCustomer = customerDb.FirstOrDefault(m => m.Id == customerId);
            updatedCustomer.DateOfBirth = updatedDate;
            db.SaveChanges();

            return true;
        }

        public bool UpdateCustomerPhone(Guid customerId, string updatedPhone)
        {
            var customerDb = db.Customers.ToList();
            var updatedCustomer = customerDb.FirstOrDefault(m => m.Id == customerId);
            updatedCustomer.PhoneNumber = updatedPhone;
            db.SaveChanges();

            return true;
        }

        public bool UpdateCustomerCardNumber(Guid customerId, string updatedCard)
        {
            var customerDb = db.Customers.ToList();
            var updatedCustomer = customerDb.FirstOrDefault(m => m.Id == customerId);
            updatedCustomer.CardNumber = updatedCard;
            db.SaveChanges();

            return true;
        }

        public bool UpdateCustomerLocation(Guid customerId, string updatedLocation)
        {
            var customerDb = db.Customers.ToList();
            var updatedCustomer = customerDb.FirstOrDefault(m => m.Id == customerId);
            updatedCustomer.Location = updatedLocation;
            db.SaveChanges();

            return true;
        }

    }
}
