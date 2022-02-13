using System;

namespace domain.entities
{
    public interface IEntity
    {
        
        DateTime? CreatedDate{get;set;}
        DateTime? ModifiedDate{get;set;}
    }
}