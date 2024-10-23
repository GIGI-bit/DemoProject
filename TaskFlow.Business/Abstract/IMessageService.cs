using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.Business.Abstract
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessages();
        Task<Message> GetMessageById(int id);
        Task Add(Message message);
        Task Update(Message message);
        Task Delete(Message message);
    }
}
