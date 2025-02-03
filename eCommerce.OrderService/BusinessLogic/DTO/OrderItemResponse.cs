
namespace BusinessLogic.DTO;

public record OrderItemResponse(Guid ProductId, Decimal Price, int Quantity, Decimal TotalPrice)
{
    public OrderItemResponse():this(default, default, default, default)
    {
        
    }
}
