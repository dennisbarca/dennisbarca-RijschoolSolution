using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rijschool.Frontend.Services;



namespace Rijschool.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<RijlesService>();
            builder.Services.AddScoped<ExamenService>();
            builder.Services.AddScoped<LeerlingService>();
            builder.Services.AddScoped<InstructeurService>();
            builder.Services.AddScoped<ZiekmeldingService>();



            builder.Services.AddScoped(sp => new HttpClient
            {
                //Dit vertelt Blazor: “alle requests naar API gaan naar deze poort”
                BaseAddress = new Uri("https://localhost:7121/") // je WebAPI URL
            });

            await builder.Build().RunAsync();
        }
    }
}
