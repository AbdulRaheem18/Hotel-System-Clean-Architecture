using FluentValidation;

namespace application.Features.Hotels.Commands
{
    public class UpdateHotelValidator: AbstractValidator<UpdateHotelRequest>
    {
        public UpdateHotelValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Please specify a Name");
            RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Please specify a Description");
        }

    }
}