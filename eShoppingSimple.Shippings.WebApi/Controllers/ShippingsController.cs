using eShoppingSimple.Shippings.Domain.Contracts.Commands;
using eShoppingSimple.Shippings.Domain.Contracts.Queries;
using eShoppingSimple.Shippings.ServiceAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Shippings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly IServiceProvider serviceProvider;

        public ShippingsController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        
        [HttpGet]
        public IEnumerable<PacketDto> Get()
        {
            var getAllPacketsQuery = new GetAllPacketsQuery(serviceProvider);
            var result = getAllPacketsQuery.Query();

            return result.Select(r => new PacketDto(r.Id, r.DeliveryService, r.Destination, r.Items.Select(i => new ItemDto(i.Id, i.Weight, new OrderDto(i.Order.Id))))).ToList();
        }

        [HttpPost]
        public void Post([FromBody] PacketDto packetDto)
        {
            var addPacketCommand = new AddPacketCommand(packetDto.Id, packetDto.Destination, packetDto.DeliveryService, packetDto.Items.Select(i => (i.Id, i.Weight, i.Order.Id)).ToList(), serviceProvider);
            addPacketCommand.Execute();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var deletePacketCommand = new DeletePacketCommand(id, serviceProvider);
            deletePacketCommand.Execute();
        }
    }
}
