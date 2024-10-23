using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDal dal;

        public CommentService(ICommentDal dal)
        {
            this.dal = dal;
        }

        public async  Task Add(Comment comment)
        {
           await dal.Add(comment);
        }

        public async Task Delete(Comment comment)
        {
          await dal.Delete(comment);
        }

        public async Task<Comment> GetCommentById(int id)
        {
          return await dal.GetById(f=>f.Id == id);
        }

        public async Task<List<Comment>> GetComments()
        {
           return await dal.GetAll();
        }

        public async Task<int> GetCount()
        {
            var list= await dal.GetAll();   
            return list.Count;
        }

        public async  Task Update(Comment address)
        {
            await dal.Update(address);  
        }
    }
}
