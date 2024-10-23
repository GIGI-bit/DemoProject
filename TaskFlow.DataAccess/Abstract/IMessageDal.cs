using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.DataAccess;
using TaskFlow.Core.DataAccess.EntityFramework;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Abstract
{
    public interface IMessageDal:IEntityRepository<Message>
    {
    }
}
