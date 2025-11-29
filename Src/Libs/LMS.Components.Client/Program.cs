using LMS.Components.Client.Source.App;
using LMS.Components.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddWMBOS()
    .AddLmsComponents();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();