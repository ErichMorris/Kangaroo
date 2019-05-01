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
    }
}
