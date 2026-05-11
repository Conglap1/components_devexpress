using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Button_Segmented.Client.Components.Notification;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddDevExpressBlazor(options =>
{
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});

builder.Services.AddMudServices();
builder.Services.AddScoped<HqNotificationService>();

await builder.Build().RunAsync();
