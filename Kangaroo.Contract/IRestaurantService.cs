using Kangaroo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo.Contract
{
    public interface IRestaurantService
    {
        bool CreateRestaurant(RestaurantCreate model);
        IEnumerable<RestaurantListItem> GetRestaurants();
        IEnumerable<RestaurantListItem> GetRestaurantsByOwner();
        RestaurantDetail GetRestaurantById(int restaurantId);
        bool UpdateRestaurant(RestaurantEdit model);
        bool DeleteRestaurant(int restaurantId);
    }
}
