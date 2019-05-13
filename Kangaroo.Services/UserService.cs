using Kangaroo.Data;
using Kangaroo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Services
{
    public class UserService
    {
        private readonly Guid _ownerId;

        public UserService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool SetRole(string newRole)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new
                UserStore<ApplicationUser>(context));
            userManager.AddToRole(_ownerId.ToString(), newRole);
            return true;
        }

        public UserInfoEdit GetUserById(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == _ownerId.ToString());
                return
                    new UserInfoEdit
                    {
                        Id = Guid.Parse(entity.Id),
                        Email = entity.Email
                    };
            }
        }

        public bool UpdateUser(UserInfoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == _ownerId.ToString());
                entity.Email = model.Email;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
