using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Data
{
    public class MenuItem
    {
        public Guid OwnerId { get; set; }

        [Key]
        public int MenuItemId { get; set; }

        public string MenuItemName { get; set; }

        public string MenuItemPrice { get; set; }

        public string MenuItemDescription { get; set; }

        public string MenuItemPicture { get; set; }
    }
}
