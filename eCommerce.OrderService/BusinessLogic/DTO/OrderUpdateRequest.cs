namespace BusinessLogic.DTO;

public record OrdersUpdateRequest(Guid OrderId, Guid UserId, DateTime OrderDate, List<OrderItemAddRequest> OrderItems)
{
    public OrdersUpdateRequest() : this(default, default, default, default) { }
}

