using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.Orders.ServiceAccess
{
    class OrderServiceClient : IOrderServiceClient 
    {
        private readonly string baseUri;

        public OrderServiceClient(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public Guid AddOrder(Guid customerId, IEnumerable<ItemDto> itemDtos)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public OrderDto GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Guid orderId, IEnumerable<ItemDto> itemDtos)
        {
            throw new NotImplementedException();
        }

        private StringContent CreateJsonPayload(object content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        private async Task<TResponsePayload> DeserializeResponse<TResponsePayload>(HttpResponseMessage responseMessage)
        {
            var stringResponse = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponsePayload>(stringResponse);
        }
    }
}
