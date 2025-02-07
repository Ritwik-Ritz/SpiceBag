using BusinessLogic.DTO;
using BusinessLogic.ServiceContracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResponse?>> GetAllOrders()
        {
            var orders = await _ordersService.GetOrders();
            return orders;
        }

        [HttpGet("/search/orderid/{orderId}")]
        public async Task<OrderResponse?> GetOrderByOrderId(Guid orderId)
        {
            FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq(temp => temp.OrderId, orderId);
            var order = await _ordersService.GetOrderByCondition(filter);
            return order;
        }

        [HttpGet("/search/productid/{productId}")]
        public async Task<IEnumerable<OrderResponse?>> GetOrdersByProductId(Guid productId)
        {
            FilterDefinition<Orders> filter = Builders<Orders>.Filter.ElemMatch(temp => temp.OrderItems, Builders<OrderItem>.Filter.Eq(tempProduct => tempProduct.ProductId, productId));
            var order = await _ordersService.GetOrdersByCondition(filter);
            return order;
        }

        [HttpGet("/search/orderDate/{orderDate}")]
        public async Task<IEnumerable<OrderResponse?>> GetOrdersByDate(DateTime orderDate)
        {
            FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq(temp => temp.OrderDate.ToString("yyyy-mm-dd"), orderDate.ToString("yyyy-mm-dd"));
            var orders = await _ordersService.GetOrdersByCondition(filter);
            return orders;
        }

        [HttpGet("/search/userid/{userId}")]
        public async Task<IEnumerable<OrderResponse?>> GetOrdersByUserId(Guid userId)
        {
            FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq(temp => temp.UserId, userId);
            var orders = await _ordersService.GetOrdersByCondition(filter);
            return orders;
        }

        [HttpPost]
        public async Task<IActionResult> Post (OrdersAddRequest orderAddRequest)
        {
            if (orderAddRequest == null)
                return BadRequest("Invalid order data");

            var orderResponse = await _ordersService.AddOrder(orderAddRequest);

            if (orderResponse == null)
                return Problem("Error in adding product");

            return Created($"api/Orders/search/orderid/{orderResponse.OrderId}", orderResponse);
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> Update(Guid orderId, OrdersUpdateRequest orderUpdateRequest)
        {
            if (orderUpdateRequest == null)
                return BadRequest("Invalid order data");

            if(orderId != orderUpdateRequest.OrderId)
                return BadRequest("OrderId not matching");

            var orderResponse = await _ordersService.UpdateOrder(orderUpdateRequest);

            if (orderResponse == null)
                return Problem("Error in updating product");

            return Ok(orderResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid orderId)
        {
            if (orderId == Guid.Empty)
                return BadRequest("Invalid Order Id");

            bool isDeleted = await _ordersService.DeleteOrder(orderId);

            return isDeleted ? Ok(isDeleted) : Problem("Error in deleting order");
        }
    }
}
