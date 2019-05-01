using System;
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

        public override string ToString() => Comments;
       
    }
}
