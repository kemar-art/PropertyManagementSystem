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
using System.Text;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<PMSDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PropertManagmentSystemConnectionString"));
        });

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 8;
            //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //options.Lockout.MaxFailedAccessAttempts = 3;
        })
        .AddEntityFrameworkStores<PMSDatabaseContext>()
        .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(auth =>
        {
            auth.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            };
        });

        services.AddHttpContextAccessor();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IFormRepository, FormRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IAppraiserRerpository, AppraiserRerpository>();
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IRegionRepository, RegionRepository>();

        return services;
    }
}

