
namespace eCommerce.Prod.Core.DTO;

public record ProductResponse(Guid ProductId, string ProductName, CategoryTypes Category, double? UnitPrice, int? Quantity)
{
    public ProductResponse() : this(default, default, default, default, default)
    {

    }
}
