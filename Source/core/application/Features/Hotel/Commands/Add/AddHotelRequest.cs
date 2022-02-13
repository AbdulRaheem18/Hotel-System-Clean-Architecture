using application.Features.Requests;
using MediatR;
using System;

namespace application.Features.Hotels.Commands
{
    public class AddHotelRequest:BaseFeatureRequest, IRequest<AddHotelResponse>
    {
        public string Description { get; set; }
       
        public decimal? Price { get; set; }
        
        public string Address { get; set; }
        
        public string Name { get; set; }
       
        public string ProfilePicture { get; set; }
    }
}