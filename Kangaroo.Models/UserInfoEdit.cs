using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Models
{
    public class UserInfoEdit
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }

    public class RoleData
    {
        public string Role { get; set; }
        public bool Value { get; set; }
    }
}
