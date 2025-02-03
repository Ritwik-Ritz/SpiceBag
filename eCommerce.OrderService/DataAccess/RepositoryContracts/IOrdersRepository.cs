using DataAccess.Entities;
using MongoDB.Driver;

namespace DataAccess.RepositoryContracts;

public interface IOrdersRepository
{
    Task<IEnumerable<Orders>> GetOrders();
    Task<IEnumerable<Orders>> GetOrdersByCondition(FilterDefinition<Orders> filter);
    Task<Orders> GetOrderByCondition(FilterDefinition<Orders> filter);
    Task<Orders> AddOrder(Orders order);
    Task<Orders> UpdateOrder(Orders order);
    Task<bool> DeleteOrder(Guid OrderId);
}
