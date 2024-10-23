using DemoProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Business.Abstract;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.DataAccess.Concrete;
using TaskFlow.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        private readonly INotificationService notificationService;
        private readonly IUserService userService;

        public NotificationController(INotificationService notificationService, IUserService userService)
        {
            this.notificationService = notificationService;
            this.userService = userService;
        }


        //url-den gelen token
        private async Task<User> GetUserAsync()
        {
            var tokenFromHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(tokenFromHeader) || !tokenFromHeader.StartsWith("Bearer "))
            {
                return null;
            }

            var tokenValue = tokenFromHeader.Substring("Bearer ".Length).Trim();
            var user = await userService.GetUserByToken(tokenValue);

            return user;
        }

        // GET: api/<NotificationController>
        [HttpGet("Notifications")]
        public async Task<IActionResult> Get()
        {
            var list = await notificationService.GetNotifications();
            var items = list.Select(p =>
            {
                return new NotificationDto
                {
                    Text = p.Text,
                    UserId = p.UserId,
                };
            });
            return Ok(items);
        }
        [HttpGet("UserNotificationCount")]
        public async Task<IActionResult> GetCount()
        {
            var user= await GetUserAsync(); 
            var list = await notificationService.GetNotifications();
          
            return Ok(list.Where(l=>l.UserId==user.Id).Count());
        }



        // POST api/<NotificationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NotificationDto value)
        {

            var item = new Notification
            {
                Text = value.Text,
                UserId = value.UserId,
            };
            await notificationService.Add(item);
            return Ok(item);
        }


        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await notificationService.GetNotificationById(id);
            if (item == null) return NotFound();
            await notificationService.Delete(item);
            return Ok();
        }
    }
}
