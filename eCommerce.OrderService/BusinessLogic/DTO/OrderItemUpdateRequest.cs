namespace BusinessLogic.DTO;

public record OrderItemUpdateRequest(Guid ProductId, decimal Price, int Quantity)
{
    public OrderItemUpdateRequest():this(default, default, default)
    {
        
    }
}
