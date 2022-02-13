using System.Threading;
using System.Threading.Tasks;
using application.Features.Hotels.DTO;
using application.Repositories;
using AutoMapper;
using MediatR;

namespace application.Features.Hotels.Querries
{
    public class GetHotelHandler : IRequestHandler<GetHotelRequest, GetHotelResponse>
    { 
        private readonly IMapper _mapper;
        private readonly IHotelRepository _repository;
        public GetHotelHandler(IHotelRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetHotelResponse> Handle(GetHotelRequest request, CancellationToken cancellationToken)
        {
            var result = new GetHotelResponse{RequestId = request.RequestId};
            var validation = new GetHotelValidator();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
            {
                var dbResult = await _repository.GetAll();
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