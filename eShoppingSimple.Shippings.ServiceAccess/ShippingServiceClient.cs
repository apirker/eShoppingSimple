using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.Shippings.ServiceAccess
{
    class ShippingServiceClient : IShippingServiceClient
    {
        private readonly string baseUri;

        public ShippingServiceClient(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public IEnumerable<PackageDto> GetPackages()
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
