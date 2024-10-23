using TaskFlow.Core.DataAccess.EntityFramework;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Data;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Concrete
{
    public class MessageDal : EFEntityBaseRepository<TaskFlowContext, Message>, IMessageDal
    {
        public MessageDal(TaskFlowContext context) : base(context)
        {
        }
    }
}
