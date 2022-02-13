using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace domain.entities
{
    public class BaseEntity:IEntity
    {
        //public Guid Id{get;set;}
        public DateTime? CreatedDate{get;set;}
        public DateTime? ModifiedDate{get;set;}
    }
}