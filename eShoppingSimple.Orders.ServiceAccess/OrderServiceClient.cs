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

        public async Task AddOrder(Guid customerId, IEnumerable<ItemDto> itemDtos)
        {
            var result = await httpClient.PostAsync($"{baseUri}/api/orders", CreateJsonPayload(new OrderDto(customerId, itemDtos)));
        }

        public async Task DeleteOrder(Guid orderId)
        {
            await httpClient.DeleteAsync($"{baseUri}/api/orders/{orderId}");
        }

        public async Task<IEnumerable<ResultOrderDto>> GetOrders()
        {
            var result = await httpClient.GetAsync($"{baseUri}/api/orders");
            return await DeserializeResponse<IEnumerable<ResultOrderDto>>(result);
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
