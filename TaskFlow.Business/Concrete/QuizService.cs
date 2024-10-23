using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Concrete
{
    public class QuizService : IQuizService
    {
        private readonly IQuizDal dal;

        public QuizService(IQuizDal dal)
        {
            this.dal = dal;
        }

        public async Task Add(Quiz quiz)
        {
            await dal.Add(quiz);    
        }

        public async Task<Quiz> GetQuizByUserId(int userId)
        {
          return  await dal.GetById(p => p.UserId == userId);
        }

        public async Task<List<Quiz>> Quizzes()
        {
            return await dal.GetAll();
        }

        public async Task Update(Quiz quiz)
        {
            await  dal.Update(quiz);
        }
    }
}
