using KK.LMS.Source.App;
using KK.LMS.Source.Shared.Extensions;
using KK.UIKit.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddLmsClient(builder.Configuration)
    .AddElixorKit();

await builder.Build().RunAsync();