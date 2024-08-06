using Application.Contracts.Repository_Interface;
using Blazored.LocalStorage;
using Blazorise;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Persistence.Repository_Implementations;
using PMS.UI;
using PMS.UI.AuthProviders;
using PMS.UI.Contracts;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Services.Base;
using PMS.UI.Services.Repository_Implementation;
using PMS.UI.Services.Repository_Implementation.AuthService;
using System.Reflection;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using PMS.UI.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register the JwtAuthorizationMessageHandler
builder.Services.AddTransient<JwtAuthorizationMessageHandler>();

builder.Services.AddHttpClient<IClient, Client>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7091");
}).AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAppraiserRerpository, AppraiserRerpository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IRegionRepositoey, RegionRepositoey>();
builder.Services.AddScoped<ICheckBoxRepository, CheckBoxRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddSweetAlert2();
builder.Services.AddMudServices();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
