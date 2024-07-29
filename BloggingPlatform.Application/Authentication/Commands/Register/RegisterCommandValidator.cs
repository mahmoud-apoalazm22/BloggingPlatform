
using FluentValidation;

namespace BloggingPlatform.Application.Authentication.Commands.Register;
public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
{


    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
    
}
