﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.VMs.Order
{
    public class CreateOrderItemVM
    {
        public int CountofProduct { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ID { get; set; }
    }
}
