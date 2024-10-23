using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Concrete
{
    public class TaskCustomizeService : ITaskCustomizeService
    {
        private readonly ITaskCustomizeDal dal;

        public TaskCustomizeService(ITaskCustomizeDal dal)
        {
            this.dal = dal;
        }

        public async Task Add(TaskCustomize taskCustomize)
        {
           await dal.Add(taskCustomize);    
        }

        public async Task Delete(TaskCustomize taskCustomize)
        {
            await dal
                  .Delete(taskCustomize);
        }

        public async Task<TaskCustomize> GetCustomizeById(int id)
        {
           return await dal.GetById(f=> f.Id == id);    
        }

        public async Task<List<TaskCustomize>> GetCustomize()
        {
            return await dal.GetAll();
        }

        public async Task Update(TaskCustomize taskCustomize)
        {
          await dal .Update(taskCustomize);
        }
    }
}
