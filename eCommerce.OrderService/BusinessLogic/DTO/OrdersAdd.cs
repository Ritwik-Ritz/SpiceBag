namespace BusinessLogic.DTO;

public record OrdersAddRequest(Guid UserId, DateTime OrderDate, List<OrderItemAddRequest> OrderItems)
{
    public OrdersAddRequest() : this(default, default, default) { }
}
