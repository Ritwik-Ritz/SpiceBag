
namespace eCommerce.Prod.Core.DTO;

public record ProductUpdateRequest(Guid ProductId, string ProductName, CategoryTypes Category, double? UnitPrice, int? Quantity)
{
    public ProductUpdateRequest() : this(default, default, default, default, default)
    {

    }
}

