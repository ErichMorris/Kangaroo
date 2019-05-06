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

        public bool CreateMenuItem(MenuItem model)
        {
            var entity =
                new MenuItem()
                {
                    OwnerId = _userId,
                    MenuItemId = model.MenuItemId,
                    MenuItemName = model.MenuItemName,
                    MenuItemPrice = model.MenuItemPrice,
                    MenuItemDescription = model.MenuItemDescription,
                    MenuItemPicture = model.MenuItemPicture
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MenuItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MenuItemListItem> GetMenuItem()
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
                                        MenuItemPrice = e.MenuItemPrice,
                                        MenuItemDescription = e.MenuItemDescription,
                                        MenuItemPicture = e.MenuItemPicture
                                    }
                                    );
                return query.ToArray();
            }
        }
        public MenuItemDetail GetMenuItemById (int MenuItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MenuItems
                        .Single(e => e.MenuItemId == MenuItemId);
                return
                    new MenuItemDetail
                    {
                        MenuItemId = entity.MenuItemId,
                        MenuItemName = entity.MenuItemName,
                        MenuItemPrice = entity.MenuItemPrice,
                        MenuItemDescription = entity.MenuItemDescription,
                        MenuItemPicture = entity.MenuItemPicture
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
                entity.MenuItemPrice = model.MenuItemPrice;
                entity.MenuItemDescription = model.MenuItemDescription;
                entity.MenuItemPicture = model.MenuItemPicture;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMenuItem(int MenuItemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MenuItems
                        .Single(e => e.MenuItemId == MenuItemId && e.OwnerId == _userId);

                 ctx.MenuItems.Remove(entity);

                 return ctx.SaveChanges() == 1;
            }
        }
    }
}
