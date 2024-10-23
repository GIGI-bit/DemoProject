using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Abstract
{
    public interface IProjectService
    {

        Task<List<Project>> GetProjects();
        Task<Project> GetProjectById(int id);
        Task Add(Project project);
        Task Update(Project project);
        Task Delete(Project project);
        Task<int> GetUserProjectCount(int userId);
    }
}
