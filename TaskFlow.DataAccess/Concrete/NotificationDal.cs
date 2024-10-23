using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.DataAccess.EntityFramework;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Data;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Concrete
{
    public class NotificationDal : EFEntityBaseRepository<TaskFlowContext, Notification>, INotificationDal
    {
        public NotificationDal(TaskFlowContext context) : base(context)
        {
        }
    }
}
