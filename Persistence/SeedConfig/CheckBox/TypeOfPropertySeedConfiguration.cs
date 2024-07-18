using Domain.CheckBox.TypeOfProperty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedConfig.CheckBox
{
    public class TypeOfPropertySeedConfiguration : IEntityTypeConfiguration<TypeOfPropertyItem>
    {
        public void Configure(EntityTypeBuilder<TypeOfPropertyItem> builder)
        {
            builder.HasData(
                new TypeOfPropertyItem
                {
                    Id = 1,
                    Title = "Commercial",
                    IsChecked = false,
                },

                new TypeOfPropertyItem
                {
                    Id = 2,
                    Title = "Residential",
                    IsChecked = false,
                },

                new TypeOfPropertyItem
                {
                    Id = 3,
                    Title = "Agricultural",
                    IsChecked = false,
                },

                new TypeOfPropertyItem
                {
                    Id = 4,
                    Title = "Industrial",
                    IsChecked = false,
                },

                new TypeOfPropertyItem
                {
                    Id = 5,
                    Title = "Vacant Lot",
                    IsChecked = false,
                }
                );
        }
    }
}
