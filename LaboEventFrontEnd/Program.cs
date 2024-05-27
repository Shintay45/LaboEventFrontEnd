using Blazored.Toast;
using LaboEventFrontEnd;
using LaboEventFrontEnd.Infrastructure;
using LaboEventFrontEnd.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace LaboEventFrontEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7080/Api/") });
            builder.Services.AddBlazoredToast();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddTransient<TokenInterceptor>();
            builder.Services.AddHttpClient("WithToken", sp =>
            {
                new HttpClient();
                sp.BaseAddress = new Uri("https://localhost:7080/api/");
            }).AddHttpMessageHandler<TokenInterceptor>();
            builder.Services.AddSingleton<AuthenticationStateProvider, MyStateProvider>();
            

            


            await builder.Build().RunAsync();
        }
    }
}
