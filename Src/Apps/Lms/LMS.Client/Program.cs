using LMS.Client.Source.App;
using LMS.Client.Source.Shared.Extensions;
using LMS.Components.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
builder.Services
    .AddKeyCloak()
    .AddLmsComponents();

await builder.Build().RunAsync();