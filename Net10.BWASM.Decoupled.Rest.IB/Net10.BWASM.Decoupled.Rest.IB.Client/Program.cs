using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Net10.BWASM.Decoupled.Rest.IB.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7017";
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });
builder.Services.AddScoped<IssueApiService>();

await builder.Build().RunAsync();
