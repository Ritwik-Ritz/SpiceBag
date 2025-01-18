using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegsiterValidator : AbstractValidator<RegisterRequest>
{
    public RegsiterValidator()
    {
        //email
        RuleFor(temp => temp.Email).NotEmpty().EmailAddress().WithMessage("Invalid Email format");

        //password
        RuleFor(temp => temp.Password).NotEmpty();

        //Personname
        RuleFor(temp => temp.PersonName).NotEmpty().MinimumLength(1).MaximumLength(50);

        //Gender
        RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Gender must be Male, female or others");
    }
}
