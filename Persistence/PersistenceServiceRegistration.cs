﻿using Application.Contracts.Email;
using Application.Contracts.Repository_Interface;
using Domain;
using Domain.Repository_Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.EmailService;
using Persistence.Repository_Implementations;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PMSDatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("PropertManagmentSystemConnectionString"));
        });

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PMSDatabaseContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //options.Lockout.MaxFailedAccessAttempts = 3;
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IFormRepository, FormRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IEmailSender, EmailSender>();
        return services;
    }
}
