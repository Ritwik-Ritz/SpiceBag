
namespace BusinessLogic.DTO;

public record OrderItemAddRequest(Guid ProductId, decimal Price, int Quantity)
{
    public OrderItemAddRequest():this(default, default, default)
    {
        
    }
}
