using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace IntegrationTests
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(this object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

        public static T ContentAsType<T>(this HttpResponseMessage response)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            return string.IsNullOrEmpty(data) ? default : JsonConvert.DeserializeObject<T>(data);
        }
    }
}
