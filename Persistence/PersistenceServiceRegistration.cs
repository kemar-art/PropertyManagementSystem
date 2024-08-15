using Application.AppURLSettings;
using Application.Contracts.Email;
using Application.Contracts.Identity;
using Application.Contracts.Repository_Interface;
using Application.IdentityModels;
using Domain;
using Domain.Repository_Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.DatabaseContext;
using Persistence.EmailService;
using Persistence.Repository_Implementations;
using System.Reflection;
using System.Text.Json;
using System.Text;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure JWT settings
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        // Configure URLSetttings 
        services.Configure<UrlSettings>(configuration.GetSection("UrlSettings"));

        // Configure database context
        services.AddDbContext<PMSDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PropertManagmentSystemConnectionString"));
        });

        // Configure Identity
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            //options.Password.RequiredLength = 8;
        })
        .AddEntityFrameworkStores<PMSDatabaseContext>()
        .AddDefaultTokenProviders();

        // Configure JWT Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(auth =>
        {
            auth.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero, // Optional, for strict validation
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });

        // Register HttpContextAccessor
        services.AddHttpContextAccessor();

        // Register repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IFormRepository, FormRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IAppraiserRerpository, AppraiserRerpository>();
        services.AddScoped<ICheckBoxRepository, CheckBoxRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();

        // Register EmailSender as a singleton
        services.AddSingleton<IEmailSender, EmailSender>();

        // Register AuthService as a transient service
        services.AddTransient<IAuthService, AuthService>();

        // Configure AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}


