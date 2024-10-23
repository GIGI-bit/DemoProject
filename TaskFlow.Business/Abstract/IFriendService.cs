using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Entities.Models;

namespace TaskFlow.Business.Abstract
{
    public interface IFriendService
    {
        Task<List<Friend>> GetFriends();
        Task<Friend> GetFriendsById(int id);
        Task Add(Friend friend);
        Task Update(Friend friend);
        Task Delete(Friend friend);
    }
}
