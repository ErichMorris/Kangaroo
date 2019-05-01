using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Data
{
    public class Restaurant
    {
        [Key]
       public int RestaurantId { get; set; }

        [Required]
       public Guid OwnerId { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string ContactEmail { get; set; }
        public string Rating { get; set; }

    }
}
