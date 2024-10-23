using DemoProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Business.Abstract;
using TaskFlow.Business.Concrete;
using TaskFlow.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        // GET: api/<MessageController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await messageService.GetMessages();
            if (list == null) return NotFound();

            var items = list.Select(c =>
            {
                return new MessageDto
                {
                    ReceiverId = c.ReceiverId,
                    SenderId = c.SenderId,
                    Text = c.Text,
                    SentDate=DateTime.Now,
                };

            });
            return Ok(items);
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await messageService.GetMessageById(id);
            if (item == null)
            {
                return NotFound();
            }
            var project = new MessageDto
            {
                ReceiverId = item.ReceiverId,
                SenderId = item.SenderId,
                Text = item.Text,
                SentDate = item.SentDate,
            };
            return Ok(project);
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageDto value)
        {
            var item = new Message
            {
                ReceiverId = value.ReceiverId,
                SenderId = value.SenderId,
                Text = value.Text,
                SentDate = DateTime.Now,
            };
            await messageService.Add(item);
            return Ok(item);
        }

     

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await messageService.GetMessageById(id);
            if (item == null)
            {
                return NotFound();
            }
            await messageService.Delete(item);
            return Ok();
        }
    }
}
