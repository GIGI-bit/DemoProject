using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Abstract;

namespace TaskFlow.Entities.Models
{
    
    public class TaskCustomize:IEntity
    {
        public int Id { get; set; } 
        public string? BackColor { get; set; }
        public string? TagColor { get; set; } 
        public int TaskId { get; set; }
        public virtual Work? Task { get; set; }

    }
}
