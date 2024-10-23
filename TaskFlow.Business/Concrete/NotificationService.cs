using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Business.Abstract;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Models;

namespace TaskFlow.Business.Concrete
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationDal notificationDal;

        public NotificationService(INotificationDal notificationDal)
        {
            this.notificationDal = notificationDal;
        }

        public async Task Add(Notification notification)
        {
          await notificationDal.Add(notification);  
        }

        public async Task Delete(Notification notification)
        {
           await notificationDal.Delete(notification);  
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await notificationDal.GetById(p=>p.Id==id);
        }

        public async Task<List<Notification>> GetNotifications()
        {
            return await notificationDal.GetAll();
        }

        public async Task<int> GetCount()
        {
           var list= await notificationDal.GetAll();
            return list.Count();
        }
    }
}
