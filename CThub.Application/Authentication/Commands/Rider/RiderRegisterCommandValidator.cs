using FluentValidation;

namespace CThub.Application.Authentication.Commands.Rider;

public class RiderRegisterCommandValidator: AbstractValidator<RiderRegisterCommand>
{
    public RiderRegisterCommandValidator()
    {
        RuleFor(d => d.Email).EmailAddress();
        RuleFor(d => d.Password).NotEmpty();
        RuleFor(d => d.FirstName).NotEmpty();
        RuleFor(d => d.LastName).NotEmpty();
    }
}