using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Models
{
    public class MenuItemDetail
    {
        public int OwnerId { get; set; }

        public int MenuItemId { get; set; }

        public string MenuItemName { get; set; }

        public string MenuItemPrice { get; set; }

        public string MenuItemDescription { get; set; }

        public string MenuItemPicture { get; set; }

        public int RestaurantId { get; set; }

        public string Name { get; set; }
    }
}
