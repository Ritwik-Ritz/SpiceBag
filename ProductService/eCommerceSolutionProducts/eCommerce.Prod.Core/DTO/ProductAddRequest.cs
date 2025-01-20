namespace eCommerce.Prod.Core.DTO;

public record ProductAddRequest(string ProductName, CategoryTypes Category, double? UnitPrice, int? Quantity)
{
    public ProductAddRequest():this(default, default, default, default)
    {

    }
}


