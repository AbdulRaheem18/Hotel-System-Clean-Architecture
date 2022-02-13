using System;
using application.Features.Requests;
using MediatR;

namespace application.Features.Hotels.Commands
{
    public class DeleteHotelRequest:BaseFeatureRequest, IRequest<DeleteHotelResponse>
    {
        public Guid Id  {get;set;}
        
    }
}