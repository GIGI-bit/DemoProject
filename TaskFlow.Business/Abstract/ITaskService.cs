using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models; 

namespace TaskFlow.DataAccess.Abstract
{
    public interface ITaskService
    {
        Task<List<Work>> GetTasks();
        Task<Work> GetTaskById(int id);
      Task Add(Work task);
      Task Update(Work task);
      Task Delete(Work task); 

    }
}
