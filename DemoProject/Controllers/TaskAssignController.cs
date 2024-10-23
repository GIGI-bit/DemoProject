using DemoProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Business.Abstract;
using TaskFlow.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignController : ControllerBase
    {
        private readonly ITaskAssignService taskAssignService;

        public TaskAssignController(ITaskAssignService taskAssignService)
        {
            this.taskAssignService = taskAssignService;
        }

        // GET: api/<TaskAssignController>
        [HttpGet]
        public async Task<IActionResult> GetBackColors()
        {
            var list = await taskAssignService.GetTaskAssignes();
            if (list == null) return NotFound();

            var items = list.Select(c =>
            {
                return new TaskAssigneDto
                {
                    UserId = c.UserId,
                    TaskForUserId = c.TaskForUserId,
                };

            });
            return Ok(items);
        }

        // GET api/<TaskAssignController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await taskAssignService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            var task = new TaskAssigneDto
            {
                UserId = item.UserId,
                TaskForUserId = item.TaskForUserId, 
            };
            return Ok(task);

        }

        // POST api/<TaskAssignController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskAssigneDto value)
        {
            var item = new TaskAssigne
            {
                UserId = value.UserId,
                TaskForUserId = value.TaskForUserId,
            };
            await taskAssignService.Add(item);
            return Ok(item);
        }

        // PUT api/<TaskAssignController>/5
        [HttpPut("ChangeUser/{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] int value)
        {
            var item = await taskAssignService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            item.UserId= value;
            await taskAssignService.Update(item);   
            return Ok();


        }
        [HttpPut("ChangeUserTask/{id}")]
        public async Task<IActionResult> PutUserTask(int id, [FromBody] int value)
        {
            var item = await taskAssignService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            item.TaskForUserId = value;
            await taskAssignService.Update(item);
            return Ok();

        }

        // DELETE api/<TaskAssignController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await taskAssignService.GetById(id);
            if (item == null) { return NotFound(); };
            await taskAssignService.Delete(item);
            return Ok();
        }
    }
}
