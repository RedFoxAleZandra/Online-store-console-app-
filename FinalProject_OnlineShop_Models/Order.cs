using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
