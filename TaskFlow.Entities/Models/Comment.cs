using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Abstract;
using TaskFlow.Entities.Base;

namespace TaskFlow.Entities.Models
{
    public class Comment:BaseEntity,IEntity
    {
        public string? Context {  get; set; }
        public int ? TaskForUserId { get; set; }
        public int ? UserId { get; set; }

        public virtual Work? TaskForUser { get; set; }
        public virtual User? User { get; set; }

    }
}
