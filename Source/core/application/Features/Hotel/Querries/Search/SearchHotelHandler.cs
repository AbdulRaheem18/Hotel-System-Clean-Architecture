using System.Threading;
using System.Threading.Tasks;
using application.Features.Hotels.DTO;
using application.Repositories;
using AutoMapper;
using MediatR;

namespace application.Features.Hotels.Querries
{
    public class SearchHotelHandler : IRequestHandler<SearchRequest, SearchResponse>
    { 
        private readonly IMapper _mapper;
        private readonly IHotelRepository _repository;
        public SearchHotelHandler(IHotelRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<SearchResponse> Handle(SearchRequest request, CancellationToken cancellationToken)
        {
            var result = new SearchResponse{RequestId = request.RequestId};
            var validation = new SearchValidator();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
            {
                var dbResult =  _repository.SearchHotel(request.search);
                if(dbResult == null){
                     result.Success = false;
                     result.Errors.Add("Period Type dosen't exist");
                     return result;
                }
                
                foreach(var item in dbResult){
                   result.Result.Add(_mapper.Map<Hoteldto>(item));
                }
            }
            else
            {
                result.Success = false;
                foreach (var error in validationResult.Errors)
                {
                    result.Errors.Add(error.ErrorMessage);                  
                }
            }
            return result;
        }
    }
}