
using Domain.CheckBoxItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedConfig.CheckBox
{
    public class PurposeOfValuationPropertySeedConfiguration : IEntityTypeConfiguration<PurposeOfValuationItem>
    {
        public void Configure(EntityTypeBuilder<PurposeOfValuationItem> builder)
        {
            builder.HasData(
                new PurposeOfValuationItem
                {
                    Id = new Guid("58267416-7f04-4835-a58d-4312388daa00"),
                    Title = "Market Value",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = new Guid("665cbc87-cce3-406a-939f-fcded826144b"),
                    Title = "Sale",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = new Guid("d0a14c91-db14-4cb0-bac0-4b3906b98c90"),
                    Title = "Purchase",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = new Guid("aaab7fca-32b7-477e-9686-1b07a9029c78"),
                    Title = "Mortgage",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = new Guid("9c969106-3a24-464a-bef2-92bcbfceb831"),
                    Title = "Insurance",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = new Guid("f19291ab-2852-42ad-a29b-c3fdc91caf35"),
                    Title = "Probate",
                    IsChecked = false,
                }
                );
        }
    }
}