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
    public class PurposeOfValuationPropertySeedConfiguration : IEntityTypeConfiguration<PurposeOfValuationCheckBoxProperty>
    {
        public void Configure(EntityTypeBuilder<PurposeOfValuationCheckBoxProperty> builder)
        {
            builder.HasData(
                new PurposeOfValuationCheckBoxProperty
                {
                    Id = 1,
                    Title = "Market Value",
                    IsChecked = false,
                },

                new PurposeOfValuationCheckBoxProperty
                {
                    Id = 2,
                    Title = "Sale",
                    IsChecked = false,
                },

                new PurposeOfValuationCheckBoxProperty
                {
                    Id = 3,
                    Title = "Purchase",
                    IsChecked = false,
                },

                new PurposeOfValuationCheckBoxProperty
                {
                    Id = 4,
                    Title = "Mortgage",
                    IsChecked = false,
                },

                new PurposeOfValuationCheckBoxProperty
                {
                    Id = 5,
                    Title = "Insurance",
                    IsChecked = false,
                },

                new PurposeOfValuationCheckBoxProperty
                {
                    Id = 6,
                    Title = "Probate",
                    IsChecked = false,
                }
                );
        }
    }
}
