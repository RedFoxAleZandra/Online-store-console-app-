using FinalProject_OnlineShop.PureFabrication;
using FinalProject_OnlineShop_DAL;
using FinalProject_OnlineShop_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                ConsoleHelper.db = db;
                ConsoleHelper newUser = new ConsoleHelper();
                newUser.OpenStartPage();

                Console.ReadKey();
            };
        }
    }
}
