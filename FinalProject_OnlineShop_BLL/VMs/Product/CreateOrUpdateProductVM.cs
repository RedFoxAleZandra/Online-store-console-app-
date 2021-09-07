using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.VMs.Product
{
    public class CreateOrUpdateProductVM
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Description { get; set; }
        public string CountryOfOrigin { get; set; }
        public Guid Id { get; set; }
    }
}
