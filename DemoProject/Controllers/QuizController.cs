using DemoProject.DTOs;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.DataAccess.Concrete;
using TaskFlow.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        // GET: api/<QuizController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _quizService.Quizzes();
            var items = list.Select(l =>
            {
                return new QuizDto
                {
                    AgeRange = l.AgeRange,
                    Profession = l.Profession,
                    UsagePurpose = l.UsagePurpose,
                    UserId =l.UserId,
                };
            });
            return Ok(items);
        }

     
        // put api/<QuizController>
        [HttpPut("Profession")]
        public async Task<IActionResult> PutProfession([FromBody] string value)
        {
            var items=await _quizService.Quizzes();
           var last= items.Last();
          
            last.Profession = value;    
            await _quizService.Update(last);
            return Ok();
        }

        [HttpPut("Occupation")]
        public async Task<IActionResult> PutOccupation([FromBody] string value)
        {
            var items = await _quizService.Quizzes();
            var last = items.Last();

            last.UsagePurpose = value;
            await _quizService.Update(last);
            return Ok();
        }

    }
}
