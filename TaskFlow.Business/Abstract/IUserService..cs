using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.DataAccess.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
       Task Add(User user);
       Task Update(User user);
       Task Delete(User user);
        Task<User> Login(string username, string password);


        Task<User> Register(User user, string password); 
          Task<bool> UserExists(string username);
        Task<int> GetAllUserCount();
        Task<User> GetUserByToken(string token);
    }
}
