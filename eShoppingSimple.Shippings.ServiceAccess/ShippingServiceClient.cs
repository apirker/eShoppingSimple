using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.Shippings.ServiceAccess
{
    class ShippingServiceClient : IShippingServiceClient
    {
        private readonly string baseUri;
        private readonly HttpClient httpClient;

        public ShippingServiceClient(string baseUri)
        {
            this.baseUri = baseUri;
            this.httpClient = new HttpClient();
        }

        public async Task AddPacket(PacketDto dto)
        {
            await httpClient.PostAsync($"{baseUri}/api/shippings", CreateJsonPayload(dto));
        }

        public async Task DeletePacket(Guid packetId)
        {
            await httpClient.DeleteAsync($"{baseUri}/api/shippings/{packetId}");
        }

        public async Task<IEnumerable<PacketDto>> GetPackets()
        {
            var result = await httpClient.GetAsync($"{baseUri}/api/shippings");
            return await DeserializeResponse<IEnumerable<PacketDto>>(result);
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
