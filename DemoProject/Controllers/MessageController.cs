﻿using DemoProject.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        [Authorize]
        [HttpGet("UserMessage")]
        public async Task<IActionResult> Get()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return BadRequest("User not authenticated.");
            }

            if (!int.TryParse(userId, out int id))
            {
                return BadRequest("Invalid user ID.");
            }

            var list = await messageService.GetMessages();
            if (list == null) return NotFound();

            var items = list.Where(i => i.ReceiverId == id).Select(c =>
            {
                return new
                {
                    ReceiverName = c.Receiver?.UserName,
                    SenderName = c.Sender?.UserName,
                    Path = c.Sender?.Image,
                    Text = c.Text,
                    SentDate = c.SentDate,
                };

            });
            return Ok(items);
        }


        [HttpGet("TwoMessage")]
        public async Task<IActionResult> TakeTwoMessage()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return BadRequest("User not authenticated.");
            }

            if (!int.TryParse(userId, out int id))
            {
                return BadRequest("Invalid user ID.");
            }

            var list = await messageService.GetMessages();
            var items = list.Where(i => i.ReceiverId == id).OrderByDescending(p => p.Id).Take(2)
                .Select(c => new
            {
                ReceiverName = c.Receiver?.UserName,
                SenderName = c.Sender?.UserName,
                Path=c.Sender?.Image,
                Text = c.Text,
                SentDate = c.SentDate,
            });

            return Ok(items);
        }




        [Authorize]
        //userin bildirim sayi
        [HttpGet("UserMessageCount")]
        public async Task<IActionResult> GetCount()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = int.Parse(userId);

            var list = await messageService.GetMessages();

            return Ok(list.Where(l => l.ReceiverId == id).Count());
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
