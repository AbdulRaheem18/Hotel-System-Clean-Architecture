using System;
using application.Features.Requests;
using MediatR;

namespace application.Features.Hotels.Querries
{
    public class GetHotelByIdRequest: IdRequest, IRequest<GetHotelByIdResponse>
    {
        
    }
}