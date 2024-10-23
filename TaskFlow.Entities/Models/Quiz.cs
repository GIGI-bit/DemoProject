using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Abstract;

namespace TaskFlow.Entities.Models
{
    //Quiz class-inin yaranma tarixine ehtiyac yoxdur. Ona gore o Base-den torenmir
    public class Quiz:IEntity
    {
        public int Id { get; set; }
        public string? AgeRange { get; set; }
        public string? Profession { get; set; }
        public string? UsagePurpose { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
