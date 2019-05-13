using Kangaroo.Data;
using Kangaroo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    OwnerId = _userId,
                    CustomerName = model.CustomerName,
                    CustomerAddress = model.CustomerAddress,
                    CustomerPhone = model.CustomerPhone,
                    CustomerEmail = model.CustomerEmail
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    CustomerName = e.CustomerName,
                                    CustomerAddress = e.CustomerAddress,
                                    CustomerPhone = e.CustomerPhone,
                                    CustomerEmail = e.CustomerEmail
                                }
                          );

                return query.ToArray();
            }
        }
        public CustomerDetail GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        CustomerName = entity.CustomerName,
                        CustomerAddress = entity.CustomerAddress,
                        CustomerPhone = entity.CustomerPhone,
                        CustomerEmail = entity.CustomerEmail
                    };
            }
        }
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId && e.OwnerId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.CustomerName = model.CustomerName;
                entity.CustomerAddress = model.CustomerAddress;
                entity.CustomerPhone = model.CustomerPhone;
                entity.CustomerEmail = model.CustomerEmail;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
