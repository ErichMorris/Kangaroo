using Kangaroo.Data;
using Kangaroo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Services
{
    public class RestaurantService
    {
        private readonly Guid _userId;
        public RestaurantService(Guid userId)
        {
            _userId = userId;

        }
        public bool CreateRestaurant (RestaurantCreate model)
        {
            var entity = new Restaurant()
            {
                OwnerId = _userId,
                Name = model.Name,
                Address = model.Address,
                Description = model.Description,
                ContactNumber = model.ContactNumber,
                ContactEmail = model.ContactEmail,
                Rating = model.Rating,
                RestaurantId = model.RestaurantId
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Restaurants.Add(entity);
                return ctx.SaveChanges() == 1;
                
            }
        }

        public IEnumerable<RestaurantListItem> GetRestaurants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Restaurants
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                    e => new RestaurantListItem
                    {
                        RestaurantId = e.RestaurantId,
                        Name = e.Name,
                        Address = e.Address,
                        Description = e.Description,
                        ContactNumber = e.ContactNumber,
                        ContactEmail = e.ContactEmail,
                        Rating = e.Rating,

                    }
                    );
                return query.ToArray();
            }
        }

        public RestaurantDetail GetRestaurantById(int id)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var entity = ctx
                    .Restaurants
                    .Single(e => e.RestaurantId == id);
                return new RestaurantDetail
                {
                    RestaurantId = entity.RestaurantId,
                    OwnerId = _userId,
                    Name = entity.Name,
                    Address = entity.Address,
                    Description = entity.Description,
                    ContactNumber = entity.ContactNumber,
                    ContactEmail = entity.ContactEmail,
                    Rating = entity.Rating,
                };
            }
        }

        public bool UpdateRestaurant (RestaurantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                     .Restaurants
                     .Single(e => e.RestaurantId == model.RestaurantId && e.OwnerId == _userId);
                entity.RestaurantId = model.RestaurantId;
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.Description = model.Description;
                entity.ContactNumber = model.ContactNumber;
                entity.ContactEmail = model.ContactEmail;
                entity.Rating = model.Rating;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteRestaurant(int restaurantId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Restaurants
                    .Single(e => e.RestaurantId == restaurantId && e.OwnerId == _userId);
                ctx.Restaurants.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
