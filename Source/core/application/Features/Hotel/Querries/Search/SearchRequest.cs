using application.Features.Requests;
using MediatR;

namespace application.Features.Hotels.Querries
{
    public class SearchRequest:BaseFeatureRequest, IRequest<SearchResponse>
    {
        public string search { get; set; }
    }
}