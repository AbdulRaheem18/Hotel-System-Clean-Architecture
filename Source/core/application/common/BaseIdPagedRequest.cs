using System;

namespace application.common
{
    public class BaseIdPagedRequest:BasePagedRequest
    {
        public Guid Id{get;set;}
        
    }
}