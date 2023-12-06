using DemoBlazor.Models.Entities;
using DemoBlazor.Models.Respositoris;
using System.Text.Json;

namespace DemoBlazor.Models.Services
{
    public class DataService : IDataRepository
    {
        private readonly IHttpClientFactory _factory;

        public DataService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Data>?> Get()
        {
            using HttpClient client = _factory.CreateClient("Api");

            using HttpResponseMessage response = await client.GetAsync("Data");

            response.EnsureSuccessStatusCode();
            
            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Data>?>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });            
        }
    }
}
