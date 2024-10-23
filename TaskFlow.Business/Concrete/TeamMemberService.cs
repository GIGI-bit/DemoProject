﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Concrete
{
    public class TeamMemberService:ITeamMemberService
    {
        private readonly ITeamMemberDal dal;

        public TeamMemberService(ITeamMemberDal dal)
        {
            this.dal = dal;
        }

        public async Task<List<TeamMember>> TeamMembers()
        {
            return await dal.GetAll();
        }

        public async Task<TeamMember> GetTaskMemberById(int id)
        {
return await dal.GetById(f=>f.Id == id);
        }

        public async System.Threading.Tasks.Task Add(TeamMember teamMember)
        {
           await dal.Add(teamMember);   
        }

        public async System.Threading.Tasks.Task Update(TeamMember teamMember)
        {await  dal.Update(teamMember); 
        }

        public async System.Threading.Tasks.Task Delete(TeamMember teamMember)
        {await dal.Delete(teamMember);
        }
         

    }
}