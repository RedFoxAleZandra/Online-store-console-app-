using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FinalProject_OnlineShop_Models;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("AppDbContext20")
        {

        }

        public DbSet<Auth> Authes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
