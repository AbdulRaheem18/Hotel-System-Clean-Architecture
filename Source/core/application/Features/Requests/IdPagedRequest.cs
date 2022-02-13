using System;

namespace application.Features.Requests
{
    public class IdPagedRequest:BaseFeaturePagedRequest
    {
        public Guid Id{get;set;}
    }
}