using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Abstract;
using TaskFlow.Entities.Base;

namespace TaskFlow.Entities.Models
{
   public class Notification:BaseEntity,IEntity
    { 
        public string? Text { get; set; } 
        public int? UserId { get; set; } 
        public virtual User? User { get; set; }  

    }
}
