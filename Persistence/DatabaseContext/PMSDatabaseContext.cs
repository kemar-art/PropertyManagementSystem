using Domain;
using Domain.CheckBox.PurposeValuation;
using Domain.CheckBox.ServiceRequest;
using Domain.CheckBox.TypeOfProperty;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.SeedConfig;
using Persistence.SeedConfig.CheckBox;
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

    //public DbSet<PurposeOfValuationCheckBox> PurposeOfValuationCheckBoxes { get; set; }
    //public DbSet<PurposeOfValuationCheckBoxProperty> PurposeOfValuationCheckBoxProperties { get; set; }

    //public DbSet<ServiceRequestCheckBox> ServiceRequestCheckBoxes { get; set; }
    //public DbSet<ServiceRequestCheckBoxProperty> ServiceRequestCheckBoxProperties { get; set; }
        
    //public DbSet<TypeOfPropertyCheckBox> TypeOfPropertyCheckBoxes { get; set; }
    //public DbSet<TypeOfPropertyCheckBoxProperty> TypeOfPropertyCheckBoxProperties { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RolesSeedConfiguration());
        builder.ApplyConfiguration(new UserSeedConfiguration());
        builder.ApplyConfiguration(new UserRolesSeedConfiguration());
        //builder.ApplyConfiguration(new PurposeOfValuationPropertySeedConfiguration());
        //builder.ApplyConfiguration(new ServiceRequestPropertySeedConfiguration());
        //builder.ApplyConfiguration(new TypeOfPropertySeedConfiguration());

        ///Purpose Of Valuation checkboxes Configuration
        //builder.Entity<PurposeOfValuationCheckBox>().HasKey(p => new { p.FormId, p.PurposeOfValuationCheckBoxPropertyId });
        //builder.Entity<PurposeOfValuationCheckBox>()
        //    .HasOne(p => p.Form)
        //    .WithMany(p => p.PurposeOfValuationCheckBoxItems)
        //    .HasForeignKey(p => p.FormId);

        //builder.Entity<PurposeOfValuationCheckBox>()
        //    .HasOne(p => p.PurposeOfValuationCheckBoxProperty)
        //    .WithMany(p => p.PurposeOfValuationItemCheckBoxes)
        //    .HasForeignKey(p => p.PurposeOfValuationCheckBoxPropertyId);

        ////Service Request checkboxes Configuration
        //builder.Entity<ServiceRequestCheckBox>().HasKey(s => new { s.FormId, s.ServiceRequestCheckBoxPropertyId });
        //builder.Entity<ServiceRequestCheckBox>()
        //    .HasOne(s => s.Form)
        //    .WithMany(s => s.ServiceRequestCheckBoxItems)
        //    .HasForeignKey(s => s.FormId);

        //builder.Entity<ServiceRequestCheckBox>()
        //    .HasOne(s => s.ServiceRequestCheckBoxProperty)
        //    .WithMany(s => s.ServiceRequestCheckBoxes)
        //    .HasForeignKey(s => s.ServiceRequestCheckBoxPropertyId);

        ////Type Of Property checkboxes Configuration
        //builder.Entity<TypeOfPropertyCheckBox>().HasKey(t => new { t.FormId, t.TypeOfPropertyCheckBoxPropertyId });
        //builder.Entity<TypeOfPropertyCheckBox>()
        //    .HasOne(t => t.Form)
        //    .WithMany(t => t.TypeOfPropertyCheckBoxItems)
        //    .HasForeignKey(sr => sr.FormId);

        //builder.Entity<TypeOfPropertyCheckBox>()
        //    .HasOne(t => t.TypeOfPropertyCheckProperty)
        //    .WithMany(t => t.TypeOfPropertyCheckBoxes)
        //    .HasForeignKey(t => t.TypeOfPropertyCheckBoxPropertyId);


    }
}
