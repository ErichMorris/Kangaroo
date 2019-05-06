
using Kangaroo.Data;
using Kangaroo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Kangaroo.Services
{
    public class MenuItemService
    {
        private readonly Guid _userId;
        public MenuItemService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMenuItem(MenuItemCreate model)
        {
            var entity =
                new MenuItem()
                {
                    OwnerId = _userId,
                    MenuItemId = model.MenuItemId,
                    MenuItemName = model.MenuItemName,
                    MenuItemDescription = model.MenuItemDescription,
                    MenuItemPrice = model.MenuItemPrice,
                    MenuItemPicture = model.MenuItemPicture,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MenuItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MenuItemListItem> GetMenuItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MenuItems
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MenuItemListItem
                                {
                                    MenuItemId = e.MenuItemId,
                                    MenuItemName = e.MenuItemName,
                                    MenuItemDescription = e.MenuItemDescription,
                                    MenuItemPrice = e.MenuItemPrice,
                                    MenuItemPicture = e.MenuItemPicture,

                                }
                          );
                return query.ToArray();
            }
        }
        public MenuItemDetail GetMenuItemById(int menuItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MenuItems
                        .Single(e => e.MenuItemId == menuItemId);
                return
                    new MenuItemDetail
                    {
                        MenuItemId = entity.MenuItemId,
                        MenuItemName = entity.MenuItemName,
                        MenuItemDescription = entity.MenuItemDescription,
                        MenuItemPrice = entity.MenuItemPrice,
                        MenuItemPicture = entity.MenuItemPicture,
                    };
            }
        }
        public bool UpdateMenuItem(MenuItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MenuItems
                        .Single(e => e.MenuItemId == model.MenuItemId && e.OwnerId == _userId);
                entity.MenuItemId = model.MenuItemId;
                entity.MenuItemName = model.MenuItemName;
                entity.MenuItemDescription = model.MenuItemDescription;
                entity.MenuItemPrice = model.MenuItemPrice;
                entity.MenuItemPicture = model.MenuItemPicture;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMenuItem(int menuItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MenuItems
                        .Single(e => e.MenuItemId == menuItemId && e.OwnerId == _userId);
                ctx.MenuItems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}