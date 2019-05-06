using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public Guid OwnerId { get; set; }
      
        public string Comments { get; set; }

        public override string ToString()
        => $"[{OrderId}]{Comments}";

        public int MenuItemId { get; set; }
        public int CustomerId { get; set; }

        public string MenuItemName { get; set; }
        public string MenuItemPrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}
