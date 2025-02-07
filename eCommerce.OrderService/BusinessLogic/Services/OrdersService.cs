using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.ServiceContracts;
using DataAccess.Entities;
using DataAccess.RepositoryContracts;
using MongoDB.Driver;

namespace BusinessLogic.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IMapper _mapper;

    public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
    {
        _ordersRepository = ordersRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponse?> AddOrder(OrdersAddRequest addRequest)
    {
        Orders orderInput = _mapper.Map<Orders>(addRequest);

        foreach (OrderItem orderItem in orderInput.OrderItems)
        {
            orderItem.TotalPrice = orderItem.Quantity * orderItem.Price;
        }
        orderInput.TotalBill = orderInput.OrderItems.Sum(temp => temp.TotalPrice);

        Orders? addedOrder = await _ordersRepository.AddOrder(orderInput);
        OrderResponse addedOrderResponse = _mapper.Map<OrderResponse>(addedOrder);
        return addedOrderResponse;
    }

    public async Task<bool> DeleteOrder(Guid OrderId)
    {
        FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq(temp => temp.OrderId, OrderId);
        Orders? existingOrder = await _ordersRepository.GetOrderByCondition(filter);

        if (existingOrder == null)
        {
            return false;
        }

        return await _ordersRepository.DeleteOrder(OrderId);
    }

    public async Task<OrderResponse?> GetOrderByCondition(FilterDefinition<Orders> filter)
    {
        Orders? order = await _ordersRepository.GetOrderByCondition(filter);
        if (order == null)
            return null;

        OrderResponse orderResponse = _mapper.Map<OrderResponse>(order);
        return orderResponse;
    }

    public async Task<List<OrderResponse>> GetOrders()
    {
        IEnumerable<Orders?> orders = await _ordersRepository.GetOrders();


        IEnumerable<OrderResponse?> orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
        return orderResponses.ToList();
    }

    public async Task<List<OrderResponse?>> GetOrdersByCondition(FilterDefinition<Orders> filter)
    {
        IEnumerable<Orders?> orders = await _ordersRepository.GetOrdersByCondition(filter);


        IEnumerable<OrderResponse?> orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
        return orderResponses.ToList();
    }

    public async Task<OrderResponse?> UpdateOrder(OrdersUpdateRequest updateRequest)
    {
        Orders orderInput = _mapper.Map<Orders>(updateRequest);

        foreach (OrderItem orderItem in orderInput.OrderItems)
        {
            orderItem.TotalPrice = orderItem.Quantity * orderItem.Price;
        }
        orderInput.TotalBill = orderInput.OrderItems.Sum(temp => temp.TotalPrice);

        Orders? updatedOrder = await _ordersRepository.UpdateOrder(orderInput);

        OrderResponse updatedOrderResponse = _mapper.Map<OrderResponse>(updatedOrder);
        return updatedOrderResponse;
    }
}
