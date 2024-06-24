using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    return base.SaveChangesAsync(cancellationToken);
    //}
}
