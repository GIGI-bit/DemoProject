﻿using TaskFlow.Business.Abstract;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Models;

namespace TaskFlow.Business.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageDal messageDal;

        public MessageService(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public async Task Add(Message message)
        {
            await messageDal.Add(message);  
        }

        public async Task Delete(Message message)
        {
            await messageDal.Delete(message);
        }

        public async Task<Message> GetMessageById(int id)
        {
            return await messageDal.GetById(f=>f.Id==id);
        }

        public async Task<List<Message>> GetMessages()
        {
            return await messageDal.GetAll();
        }

        public async Task Update(Message message)
        {
           await messageDal.Update(message);
        }
    }
}