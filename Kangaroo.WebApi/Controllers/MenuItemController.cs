using Kangaroo.Models;
using Kangaroo.Data;
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
    public class MenuItemController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            MenuItemService menuItemService = CreateMenuItemService();
            var menuItems = menuItemService.GetMenuItems();
            return Ok(menuItems);
        }
        public IHttpActionResult Get(int id)
        {
            MenuItemService menuItemService = CreateMenuItemService();
            var menuItem = menuItemService.GetMenuItemById(id);
            return Ok(menuItem);
        }
        public IHttpActionResult Post(MenuItemCreate menuItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMenuItemService();
            if (!service.CreateMenuItem(menuItem))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(MenuItemEdit menuItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMenuItemService();
            if (!service.UpdateMenuItem(menuItem))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMenuItemService();
            if (!service.DeleteMenuItem(id))
                return InternalServerError();
            return Ok();
        }
        private MenuItemService CreateMenuItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var menuItemService = new MenuItemService(userId);
            return menuItemService;
        }
    }
}