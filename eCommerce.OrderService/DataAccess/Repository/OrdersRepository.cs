
using DataAccess.Entities;
using DataAccess.RepositoryContracts;
using MongoDB.Driver;

namespace DataAccess.Repository;

public class OrdersRepository : IOrdersRepository
{
    private readonly IMongoCollection<Orders> _database;

    public OrdersRepository(IMongoDatabase mongodb)
    {
        _database = mongodb.GetCollection<Orders>("orders");
    }

    public async Task<Orders> AddOrder(Orders order)
    {
        order.OrderId = Guid.NewGuid();
        order._id = order.OrderId;

        foreach(OrderItem item in order.OrderItems)
        {
            item._id = Guid.NewGuid();
        }
        await _database.InsertOneAsync(order);
        return order;
    }

    public async Task<bool> DeleteOrder(Guid OrderId)
    {
        FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq(temp => temp.OrderId, OrderId);

        Orders? existingOrder = (await _database.FindAsync(filter)).FirstOrDefault();

        if (existingOrder != null)
        {
            return false;
        }
        DeleteResult result = await _database.DeleteOneAsync(filter);

        return result.DeletedCount > 0;
    }

    public async Task<Orders> GetOrderByCondition(FilterDefinition<Orders> filter)
    {
        return (await _database.FindAsync(filter)).FirstOrDefault();
    }

    public async Task<IEnumerable<Orders>> GetOrders()
    {
        return (await _database.FindAsync(Builders<Orders>.Filter.Empty)).ToList();
    }

    public async Task<IEnumerable<Orders>> GetOrdersByCondition(FilterDefinition<Orders> filter)
    {
        return(await _database.FindAsync(filter)).ToList();
    }

    public async Task<Orders> UpdateOrder(Orders order)
    {
        FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq(temp => temp.OrderId, order.OrderId);
        Orders? existingOrder = (await _database.FindAsync(filter)).FirstOrDefault();

        if (existingOrder != null)
        {
            return null;
        }

        ReplaceOneResult updatedOrder = await _database.ReplaceOneAsync(filter, order);

        return order;
    }
}
