using FluentValidation;

namespace CThub.Application.Authentication.Commands.Driver;

public class DriverRegistrationCommandValidator: AbstractValidator<DriverRegisterCommand>
{
    public DriverRegistrationCommandValidator()
    {
        RuleFor(d => d.Email).EmailAddress();
        RuleFor(d => d.Password).NotEmpty();
        RuleFor(d => d.FirstName).NotEmpty();
        RuleFor(d => d.LastName).NotEmpty();
        RuleFor(d => d.VehincleModel).NotEmpty();
        RuleFor(d => d.VehincleCapacity).NotEmpty().LessThanOrEqualTo(4);
        RuleFor(d => d.VehincleName).NotEmpty();
        RuleFor(d => d.VehincleType).NotEmpty();
    }
}