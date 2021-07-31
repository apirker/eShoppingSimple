using eShoppingSimple.Orders.Domain.Contracts;
using eShoppingSimple.Orders.ServiceAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Orders.WebApi.Controllers
{
    /// <summary>
    /// API controller for orders
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceScopeFactory"></param>
        public OrdersController(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
        
        /// <summary>
        /// Returns all orders.
        /// </summary>
        [HttpGet]
        public IEnumerable<ResultOrderDto> Get()
        {
            var getAllOrdersCommand = new GetOrdersCommand(serviceScopeFactory.CreateScope().ServiceProvider);
            var results = getAllOrdersCommand.Query();

            return results.Select(
                o => new ResultOrderDto(
                    o.Id,
                    o.CustomerId,
                    o.Items.Select(i => new ItemDto(i.Id, i.Name, i.Price, i.Pictures.Select(p => p.Content).ToList()))
                )
            );
        }

        /// <summary>
        /// Adds a new order to the service.
        /// </summary>
        [HttpPost]
        public void Post([FromBody] OrderDto orderDto)
        {
            var addOrderCommand = new AddOrderCommand(orderDto.CustomerId, orderDto.Items.Select(i => (i.Id, i.Name, i.Price, i.Pictures)).ToList(), serviceScopeFactory.CreateScope().ServiceProvider);
            addOrderCommand.Execute();
        }

        /// <summary>
        /// Updates an existing order.
        /// </summary>
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] OrderDto orderDto)
        {
            var updateOrderCommand = new UpdateOrderCommand(id, orderDto.Items.Select(i => (i.Id, i.Name, i.Price, i.Pictures)).ToList(), serviceScopeFactory.CreateScope().ServiceProvider);
            updateOrderCommand.Execute();
        }

        /// <summary>
        /// Deletes an existing order from the service.
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var deleteOrderCommand = new DeleteOrderCommand(id, serviceScopeFactory.CreateScope().ServiceProvider);
            deleteOrderCommand.Execute();
        }
    }
}
