using FluentValidation;

namespace application.Features.Hotels.Commands
{
    public class AddHotelValidator: AbstractValidator<AddHotelRequest>
    {
        public AddHotelValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Please specify a Name");
             RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Please specify a Price");
        }

    }
}