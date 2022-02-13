using FluentValidation;

namespace application.Features.Hotels.Querries
{
    public class GetHotelByIdValidator: AbstractValidator<GetHotelByIdRequest>
    {
        public GetHotelByIdValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Please specify a Id");
           
        }

    }
}