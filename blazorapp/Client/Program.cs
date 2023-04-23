using blazorapp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace blazorapp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton(new HttpClient { });
            builder.Services.AddSingleton(sp => new RestApi.ApiClient ("http://localhost:5000/", sp.GetRequiredService<HttpClient>()));

            await builder.Build().RunAsync();
        }
    }
}