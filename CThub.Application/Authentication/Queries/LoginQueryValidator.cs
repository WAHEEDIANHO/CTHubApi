using FluentValidation;

namespace CThub.Application.Authentication.Queries;

public class LoginQueryValidator: AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(l => l.Email)
            .NotEmpty().EmailAddress().WithMessage("Enter a valid email");
        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Password can't be empty");
    }
}