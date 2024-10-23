using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Abstract
{
    public interface ICommentService
    {
        Task<List<Comment>> GetComments();
        Task<Comment> GetCommentById(int id);
        Task Add(Comment comment);
        Task Update(Comment comment);
        Task Delete(Comment comment);
        Task<int> GetCount();

    }
}
