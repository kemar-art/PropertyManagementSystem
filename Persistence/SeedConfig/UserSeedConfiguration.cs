using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedConfig;

public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        _ = builder.HasData(
                new ApplicationUser
                {
                    Id = "588cc79d-bfba-4063-a577-a08a19ff3fba",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "admin@1"),
                    EmailConfirmed = true
                },

                new ApplicationUser
                {
                    Id = "4cb8218a-f54a-472f-84db-275ff92a659f",
                    Email = "appraiser@localhost.com",
                    NormalizedEmail = "Appraiser@LOCALHOST.COM".ToUpper(),
                    NormalizedUserName = "Appraiser@LOCALHOST.COM".ToUpper(),
                    UserName = "appraiser@localhost.com",
                    FirstName = "Appraiser",
                    LastName = "Appraiser",
                    PasswordHash = hasher.HashPassword(null, "appraiser@1"),
                    EmailConfirmed = true
                },

                new ApplicationUser
                {
                    Id = "89d67a78-bd8e-4e72-93dc-602de068282a",
                    Email = "client@localhost.com",
                    NormalizedEmail = "Client@LOCALHOST.COM".ToUpper(),
                    NormalizedUserName = "Client@LOCALHOST.COM".ToUpper(),
                    UserName = "client@localhost.com",
                    FirstName = "Client",
                    LastName = "Client",
                    PasswordHash = hasher.HashPassword(null, "client@1"),
                    EmailConfirmed = true
                }

            );
    }
}
