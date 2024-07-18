using Domain.CheckBox.PurposeValuation;
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
                    Id = 1,
                    Title = "Market Value",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = 2,
                    Title = "Sale",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = 3,
                    Title = "Purchase",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = 4,
                    Title = "Mortgage",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = 5,
                    Title = "Insurance",
                    IsChecked = false,
                },

                new PurposeOfValuationItem
                {
                    Id = 6,
                    Title = "Probate",
                    IsChecked = false,
                }
                );
        }
    }
}
