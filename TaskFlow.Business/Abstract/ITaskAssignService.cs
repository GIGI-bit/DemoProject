using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.Business.Abstract
{
    public interface ITaskAssignService
    {
        Task<List<TaskAssigne>> GetTaskAssignes();
        Task<TaskAssigne> GetById(int id);
        Task Add(TaskAssigne assign);
        Task Update(TaskAssigne assign);
        Task Delete(TaskAssigne assign);
    }
}
