namespace BusinessLogic.DTO;

public record OrderResponse(Guid OrderId, Guid UserId, DateTime OrderDate, Decimal TotalBill, List<OrderItemResponse> OrderItems)
{
    public OrderResponse():this(default, default, default, default, default)
    {
        
    }
}
