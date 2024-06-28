using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedConfig;

public class RolesSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        _ = builder.HasData(
                new IdentityRole
                {
                    Id = "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },

                new IdentityRole
                {
                    Id = "1ff8b9a5-91cd-478d-942d-baaca93a4bf9",
                    Name = Roles.Appraiser,
                    NormalizedName = Roles.Appraiser.ToUpper()
                },

                new IdentityRole
                {
                    Id = "abcf3529-e04c-4fc6-b654-da3f444b3c0c",
                    Name = Roles.Client,
                    NormalizedName = Roles.Client.ToUpper()

                }
            );
    }
}
