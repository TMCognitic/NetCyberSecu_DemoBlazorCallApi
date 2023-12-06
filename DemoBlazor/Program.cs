using DemoBlazor.Models.Respositoris;
using DemoBlazor.Models.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DemoBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //Package Nuget Microsoft.Extensions.Http -> 8.0
            builder.Services.AddHttpClient("Api", config =>
            {
                config.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
                config.BaseAddress = new Uri("https://localhost:7012/");
            });

            builder.Services.AddScoped<IDataRepository, DataService>();
            

            
            await builder.Build().RunAsync();
        }
    }
}
