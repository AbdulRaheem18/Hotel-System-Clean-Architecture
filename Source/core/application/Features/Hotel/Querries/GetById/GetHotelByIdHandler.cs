using System.Threading;
using System.Threading.Tasks;
using application.Features.Hotel.DTO;
using application.Features.Hotels.DTO;
using application.Repositories;
using AutoMapper;
using MediatR;

namespace application.Features.Hotels.Querries
{
    public class GetHotelByIdHandler : IRequestHandler<GetHotelByIdRequest, GetHotelByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _repository;
        public GetHotelByIdHandler(IHotelRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<GetHotelByIdResponse> Handle(GetHotelByIdRequest request, CancellationToken cancellationToken)
        {
            var result = new GetHotelByIdResponse{RequestId = request.RequestId};
            var validation = new GetHotelByIdValidator();
            var validationResult = validation.Validate(request);
            if (validationResult.IsValid)
            {
                var dbResult = await _repository.Get(request.Id);
                var dbResultFaciliies = await _repository.GetFacilities(request.Id);
                if (dbResult == null){
                     result.Success = false;
                     result.Errors.Add("Period Type dosen't exist");
                     return result;
                }

                result.Result = new Hotel.DTO.HotelDetaildto() {
                    hotel = _mapper.Map<Hoteldto>(dbResult),
                    Facilities = _mapper.Map<Facilitiesdto>(dbResultFaciliies)
                };
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