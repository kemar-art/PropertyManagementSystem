using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedConfig
{
    public class UserRolesSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c",
                        UserId = "588cc79d-bfba-4063-a577-a08a19ff3fba",
                    },

                    new IdentityUserRole<string>
                    {
                        RoleId = "1ff8b9a5-91cd-478d-942d-baaca93a4bf9",
                        UserId = "4cb8218a-f54a-472f-84db-275ff92a659f",
                    },

                    new IdentityUserRole<string>
                    {
                        RoleId = "abcf3529-e04c-4fc6-b654-da3f444b3c0c",
                        UserId = "89d67a78-bd8e-4e72-93dc-602de068282a",
                    }
                );
        }
    }
}
