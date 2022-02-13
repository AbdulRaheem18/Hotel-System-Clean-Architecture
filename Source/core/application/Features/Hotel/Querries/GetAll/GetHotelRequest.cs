using application.Features.Requests;
using MediatR;

namespace application.Features.Hotels.Querries
{
    public class GetHotelRequest : BaseFeatureRequest, IRequest<GetHotelResponse>
    {
        
    }
}