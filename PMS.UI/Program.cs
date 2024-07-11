using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PMS.UI;
using PMS.UI.Contracts;
using PMS.UI.Services.Base;
using PMS.UI.Services.Repository_Implementation;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7091"));

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAppraiserRerpository, AppraiserRerpository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
