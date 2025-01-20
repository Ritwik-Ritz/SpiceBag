using eCommerce.Prod.Core.DTO;
using FluentValidation;

namespace eCommerce.Prod.Core.Validators
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateValidator()
        {
            RuleFor(temp => temp.ProductId).NotEmpty();
            RuleFor(temp => temp.ProductName).NotEmpty();
            RuleFor(temp => temp.Category).IsInEnum();
            RuleFor(temp => temp.UnitPrice).InclusiveBetween(0, double.MaxValue);
            RuleFor(temp => temp.Quantity).InclusiveBetween(0, int.MaxValue);
        }
    }
}
