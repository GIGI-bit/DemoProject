using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Abstract;
using TaskFlow.Entities.Base;

namespace TaskFlow.Entities.Models
{
    public class Project: BaseEntity,IEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? CreatedById { get; set; }//UserId
        public bool IsCompleted { get; set; }   

        public virtual User? CreatedBy { get; set; }
        public virtual List<Work>? TaskForUsers { get;set; }
        public virtual List<TeamMember>? TeamMembers { get; set; }

    }
}
