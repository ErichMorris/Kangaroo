using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public Guid OwnerId { get; set; }
        public string Comments { get; set; }

        public int MenuItemId { get; set; }
        public int CustomerId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
