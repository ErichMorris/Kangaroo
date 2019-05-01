using Kangaroo.Data;
using Kangaroo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Services
{
    public class OrderService
    {
        private readonly Guid _userId;
        public OrderService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateOrder(OrderCreate model)
        {
         var entity = new Order()
            {
                OwnerId = _userId,
                OrderId = model.OrderId,
                Comments = model.Comments,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Orders
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                    e => new OrderListItem
                    {

                       OrderId=e.OrderId,
                       Comments=e.Comments,


                    }
                    );
                return query.ToArray();
            }
        }

        public OrderDetail GetOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Orders
                    .Single(e => e.OrderId == id);
                return new OrderDetail
                {

                    OrderId = entity.OrderId,
                    OwnerId = _userId,
                    Comments = entity.Comments,

                };

            }
        }
            public bool UpdateOrder(OrderEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx
                        .Orders
                        .Single(e => e.OrderId == model.OrderId && e.OwnerId == _userId);
                entity.OrderId = model.OrderId;
                entity.Comments = model.Comments;
                    return ctx.SaveChanges() == 1;
                }
            }

        public bool DeleteOrder(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Orders
                    .Single(e => e.OrderId == orderId && e.OwnerId == _userId);
                ctx.Orders.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
    }

