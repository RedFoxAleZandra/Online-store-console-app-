using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_Models
{
    public class OrderItem : BaseEntity
    {
        public int CountOfProducts { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

    }
}
