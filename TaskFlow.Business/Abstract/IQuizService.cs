using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Abstract
{
    public interface IQuizService
    {
        Task Add(Quiz quiz);    
        Task Update(Quiz quiz);
        Task<Quiz> GetQuizByUserId(int userId);
        Task<List<Quiz>> Quizzes(); 
    }
}
