using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Core.Abstract;
using TaskFlow.Entities.Base;

namespace TaskFlow.Entities.Models
{
    // Project ve User class-inin coxun coxa relation-undan emele gelen 3-cu class-dir.

    public class TeamMember:IEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public int? UserId { get; set; }
        public string? Role { get; set; }

        ///
        public virtual User? User { get; set; }
        public virtual Project? Project { get; set; }
    }
}
