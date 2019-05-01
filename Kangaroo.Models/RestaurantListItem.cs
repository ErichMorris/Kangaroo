using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Models
{
    public class RestaurantListItem
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Rating { get; set; }

        public override string ToString() => Name;
       
    }
}
