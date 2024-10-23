using DemoProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Business.Abstract;
using TaskFlow.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService friendService)
        {
            this.friendService = friendService;
        }

        // GET: api/<FriendController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await friendService.GetFriends();
            var items = list.Select(p =>
            {
                return new FriendDto
                {
                   UserFriendId=p.UserFriendId,
                   UserId = p.UserId,
                };
            });
            return Ok(items);
        }

        // GET api/<FriendController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await friendService.GetFriendsById(id);
            if (item == null)
            {
                return NotFound();
            }
            var friend = new FriendDto
            {
                UserFriendId = item.UserFriendId,
                UserId = item.UserId,
            };
            return Ok(friend);
        }

        // POST api/<FriendController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FriendDto value)
        {
            var item = new Friend
            {
                UserFriendId = value.UserFriendId,
                UserId = value.UserId, 
            };
            await friendService.Add(item);
            return Ok(item);
        }

       
        // DELETE api/<FriendController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await friendService.GetFriendsById(id);
            if (item == null)
            {
                return NotFound();
            }
            await friendService.Delete(item);
            return Ok();    
        }
    }
}
