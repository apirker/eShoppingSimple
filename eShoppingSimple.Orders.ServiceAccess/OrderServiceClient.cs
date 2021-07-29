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
        private readonly HttpClient httpClient;

        public OrderServiceClient(string baseUri)
        {
            this.baseUri = baseUri;
            this.httpClient = new HttpClient();
        }

        public async Task<Guid> AddOrder(Guid customerId, IEnumerable<ItemDto> itemDtos)
        {
            var result = await httpClient.PostAsync($"{baseUri}/api/orders", CreateJsonPayload(new OrderDto(customerId, itemDtos)));
            return await DeserializeResponse<Guid>(result);
        }

        public async Task DeleteOrder(Guid orderId)
        {
            await httpClient.DeleteAsync($"{baseUri}/api/orders/{orderId}");
        }

        public async Task<OrderDto> GetOrder(Guid id)
        {            
            var result = await httpClient.GetAsync($"{baseUri}/api/orders/{id}");
            return await DeserializeResponse<OrderDto>(result);
        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            var result = await httpClient.GetAsync($"{baseUri}/api/orders");
            return await DeserializeResponse<IEnumerable<OrderDto>>(result);
        }

        public async Task UpdateOrder(Guid orderId, IEnumerable<ItemDto> itemDtos)
        {
            await httpClient.PutAsync($"{baseUri}/api/orders/{orderId}", CreateJsonPayload(new OrderDto(orderId, itemDtos)));
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
