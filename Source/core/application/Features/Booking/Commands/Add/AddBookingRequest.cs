using application.Features.Requests;
using MediatR;
using System;

namespace application.Features.Bookings.Commands
{
    public class AddBookingRequest:BaseFeatureRequest, IRequest<AddBookingResponse>
    {
        public Guid id { get; set; }
       
        public decimal? Price { get; set; }
        
        public DateTime fromDate { get; set; }
        
        public DateTime toDate { get; set; }
       
       
    }
}