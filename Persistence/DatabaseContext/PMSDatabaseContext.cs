﻿using Domain;
using Domain.CheckBoxItems;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.SeedConfig;
using Persistence.SeedConfig.CheckBox;
using Persistence.SeedConfig.Regions;
using Persistence.SeedConfig.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext;

//Property Management System Database
public class PMSDatabaseContext : IdentityDbContext<ApplicationUser>
{
    public PMSDatabaseContext(DbContextOptions<PMSDatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<Form> Forms { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public DbSet<Region> Regions { get; set; }

    public DbSet<FormInteractionLog> FormInteractionLogs { get; set; }

    public DbSet<TypeOfPropertyItem> TypeOfPropertyItems { get; set; }

    public DbSet<ServiceRequestItem> ServiceRequestItems { get; set; }

    public DbSet<PurposeOfValuationItem> PurposeOfValuationItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RolesSeedConfiguration());
        builder.ApplyConfiguration(new UserSeedConfiguration());
        builder.ApplyConfiguration(new UserRolesSeedConfiguration());
        builder.ApplyConfiguration(new RegionSeedConfiguration());
        builder.ApplyConfiguration(new TypeOfPropertySeedConfiguration());
        builder.ApplyConfiguration(new ServiceRequestPropertySeedConfiguration());
        builder.ApplyConfiguration(new PurposeOfValuationPropertySeedConfiguration());

        builder.Entity<Form>()
       .Property(f => f.CustomerId)
       .ValueGeneratedOnAdd();
    }
}
