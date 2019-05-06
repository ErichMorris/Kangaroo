using Kangaroo.Data;
using Kangaroo.Models;
using Kangaroo.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Kangaroo.WebApi.Controllers
{
    [Authorize]
    public class RestaurantController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            RestaurantService restaurantService = CreateRestaurantService();
            var restaurants = restaurantService.GetRestaurants();
            return Ok(restaurants);
        }
        public IHttpActionResult Get(int id)
        {
            RestaurantService restaurantService = CreateRestaurantService();
            var restaurant = restaurantService.GetRestaurantById(id);
            return Ok(restaurant);
        }
        public IHttpActionResult Post(RestaurantCreate restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateRestaurantService();
            if (!service.CreateRestaurant(restaurant))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(RestaurantEdit restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateRestaurantService();
            if (!service.UpdateRestaurant(restaurant))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRestaurantService();
            if (!service.DeleteRestaurant(id))
                return InternalServerError();
            return Ok();
        }
        private RestaurantService CreateRestaurantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var restaurantService = new RestaurantService(userId);
            return restaurantService;
        }
    }
}