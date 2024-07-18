using Domain;
using Domain.CheckBox.PurposeValuation;
using Domain.CheckBox.ServiceRequest;
using Domain.CheckBox.TypeOfProperty;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.SeedConfig;
using Persistence.SeedConfig.CheckBox;
using Persistence.SeedConfig.Regions;
using Persistence.SeedConfig.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public DbSet<FormTypeOfPropertyItem> ServiceRequesFormTypeOfPropertyItems { get; set; }

    public DbSet<ServiceRequestItem> ServiceRequestItems { get; set; }
    public DbSet<FormServiceRequestItem> ServiceRequestFormServiceRequestItems { get; set; }

    public DbSet<PurposeOfValuationItem> PurposeOfValuationItems { get; set; }
    public DbSet<FormPurposeOfValuationItem> ServiceRequestFormPurposeOfValuationItems { get; set; }

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

        //Type Of Property checkboxes Configuration
        builder.Entity<FormTypeOfPropertyItem>().HasKey(t => new { t.FormId, t.TypeOfPropertyItemId });
        builder.Entity<FormTypeOfPropertyItem>()
            .HasOne(sr => sr.Form)
            .WithMany(st => st.ServiceRequesFormTypeOfPropertyItem)
            .HasForeignKey(sr => sr.FormId);

        builder.Entity<FormTypeOfPropertyItem>()
            .HasOne(tp => tp.TypeOfPropertyItem)
            .WithMany(st => st.FormTypeOfPropertyItem)
            .HasForeignKey(tp => tp.TypeOfPropertyItemId);

        //Service Request checkboxes Configuration
        builder.Entity<FormServiceRequestItem>().HasKey(s => new { s.FormId, s.ServiceRequestItemId });
        builder.Entity<FormServiceRequestItem>()
            .HasOne(sr => sr.Form)
            .WithMany(ss => ss.ServiceRequestFormServiceRequestItem)
            .HasForeignKey(sr => sr.FormId);

        builder.Entity<FormServiceRequestItem>()
            .HasOne(s => s.ServiceRequestItem)
            .WithMany(ss => ss.FormServiceRequestItem)
            .HasForeignKey(s => s.ServiceRequestItemId);

        //Purpose Of Valuation checkboxes Configuration
        builder.Entity<FormPurposeOfValuationItem>().HasKey(p => new { p.FormId, p.PurposeOfValuationItemId });
        builder.Entity<FormPurposeOfValuationItem>()
            .HasOne(sr => sr.Form)
            .WithMany(sp => sp.ServiceRequestFormPurposeOfValuationItem)
            .HasForeignKey(sr => sr.FormId);

        builder.Entity<FormPurposeOfValuationItem>()
            .HasOne(pv => pv.PurposeOfValuationItem)
            .WithMany(sp => sp.FormPurposeOfValuationItem)
            .HasForeignKey(pv => pv.PurposeOfValuationItemId);
    }
}
