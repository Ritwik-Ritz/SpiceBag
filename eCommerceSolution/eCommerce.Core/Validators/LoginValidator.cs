using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<Loginrequest>
{
    public LoginRequestValidator()
    {
        //email
        RuleFor(temp => temp.Email).NotEmpty().EmailAddress().WithMessage("Invalid Email format");

        //password
        RuleFor(temp => temp.Password).NotEmpty();
    }
}
