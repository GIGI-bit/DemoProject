using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.Business.Abstract
{
  public  interface INotificationService
    {
        Task<List<Notification>> GetNotifications();
        Task<Notification> GetNotificationById(int id);
        Task Add(Notification notification);
        Task<int> GetCount();
        Task Delete(Notification notification);
    }
}
