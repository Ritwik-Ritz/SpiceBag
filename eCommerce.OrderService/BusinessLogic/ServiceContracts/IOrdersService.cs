
using BusinessLogic.DTO;
using DataAccess.Entities;
using MongoDB.Driver;

namespace BusinessLogic.ServiceContracts;

public interface IOrdersService
{
    Task<List<OrderResponse>> GetOrders();
    Task<List<OrderResponse?>> GetOrdersByCondition(FilterDefinition<Orders> filter);

    Task<OrderResponse?> GetOrderByCondition(FilterDefinition<Orders> filter);

    Task<OrderResponse?> AddOrder(OrdersAddRequest addRequest);
    Task<bool> DeleteOrder(Guid OrderId);
    Task<OrderResponse?> UpdateOrder(OrdersUpdateRequest updateRequest);
}
