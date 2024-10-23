using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Abstract;

namespace TaskFlow.Entities.Models
{
    public class Message:IEntity
    {
        public int Id { get; set; }
        public string? Text { get; set; }    
        public int? SenderId { get; set; }    
        public int? ReceiverId { get; set; }    
        public DateTime SentDate { get; set; }

        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }
    }
}
