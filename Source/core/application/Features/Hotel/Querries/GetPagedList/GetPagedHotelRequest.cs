using application.Features.Requests;
using MediatR;

namespace application.Features.PeriodTypes.Querries
{
    public class GetPagedHotelRequest:BaseFeaturePagedRequest, IRequest<GetPagedHotelResponse>
    {
        
    }
}