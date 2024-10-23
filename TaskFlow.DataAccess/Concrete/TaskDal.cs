using System;
using System.Collections.Generic;
using System.Linq; 
using TaskFlow.Core.DataAccess.EntityFramework;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Data;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Concrete
{
    public class TaskDal : EFEntityBaseRepository<TaskFlowContext, Work>, ITaskDal
    {
        public TaskDal(TaskFlowContext context) : base(context)
        {
        }
    }
}
