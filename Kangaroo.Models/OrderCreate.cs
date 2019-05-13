﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Models
{
    public class OrderCreate
    {
        public int OrderId { get; set; }
        public string Comments { get; set; }
        public int MenuItemId { get; set; }
        public int CustomerId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemPrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

    }
}
