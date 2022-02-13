using System;
using application.Features.Requests;
using MediatR;

namespace application.Features.Hotels.Commands
{
    public class UpdateHotelRequest:BaseFeatureRequest, IRequest<UpdateHotelResponse>
    {
        public Guid Id{get;set;}
        public string Name  {get;set;}
        public string Description  {get;set;}
    }
}