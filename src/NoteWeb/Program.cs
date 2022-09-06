using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NoteWeb;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5128") });
//builder.Services.AddHttpClient();
//builder.Services.AddHttpClient("NoteApi", c => c.BaseAddress = new Uri("http://localhost:5128"));

await builder.Build().RunAsync();
