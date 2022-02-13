using System.Threading;
using System.Threading.Tasks;
using application.Features.Hotels.DTO;
using application.Repositories;
using AutoMapper;
using MediatR;

namespace application.Features.PeriodTypes.Querries
{
    public class GetPagedHotelHandler : IRequestHandler<GetPagedHotelRequest, GetPagedHotelResponse>
    { 
        private readonly IMapper _mapper;
        private readonly IHotelRepository _repository;
        public GetPagedHotelHandler(IHotelRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetPagedHotelResponse> Handle(GetPagedHotelRequest request, CancellationToken cancellationToken)
        {
            var result = new GetPagedHotelResponse{RequestId = request.RequestId};
            var validation = new GetPagedHotelValidator();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
            {
                var dbResult = await _repository.GetPaged(
                    new common.BasePagedRequest{
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    Page = true
                });
                if(dbResult == null){
                     result.Success = false;
                     result.Errors.Add("Status dosen't exist");
                     return result;
                }     
                
                result = _mapper.Map<GetPagedHotelResponse>(dbResult);
                
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