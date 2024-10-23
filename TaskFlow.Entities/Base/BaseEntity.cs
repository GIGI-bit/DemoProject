using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Entities.Base
{
    //Diger entity-lerde ortaq olan property-leri ayri bir base-e yazilir.
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate {  get; set; }= DateTime.UtcNow;
    }
}
