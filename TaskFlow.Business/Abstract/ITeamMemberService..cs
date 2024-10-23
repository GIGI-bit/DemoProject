using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Abstract
{
    public interface ITeamMemberService
    {
        Task<List<TeamMember>> TeamMembers();
        Task<TeamMember> GetTaskMemberById(int id);
     Task Add(TeamMember teamMember);
     Task Update(TeamMember teamMember);
     Task Delete(TeamMember teamMember);
    }
}
