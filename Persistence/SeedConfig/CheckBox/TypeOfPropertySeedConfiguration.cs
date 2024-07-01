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
    public class TypeOfPropertySeedConfiguration : IEntityTypeConfiguration<TypeOfPropertyCheckBoxProperty>
    {
        public void Configure(EntityTypeBuilder<TypeOfPropertyCheckBoxProperty> builder)
        {
            builder.HasData(
                new TypeOfPropertyCheckBoxProperty
                {
                    Id = 1,
                    Title = "Commercial",
                    IsChecked = false,
                },

                new TypeOfPropertyCheckBoxProperty
                {
                    Id = 2,
                    Title = "Residential",
                    IsChecked = false,
                },

                new TypeOfPropertyCheckBoxProperty
                {
                    Id = 3,
                    Title = "Agricultural",
                    IsChecked = false,
                },

                new TypeOfPropertyCheckBoxProperty
                {
                    Id = 4,
                    Title = "Industrial",
                    IsChecked = false,
                },

                new TypeOfPropertyCheckBoxProperty
                {
                    Id = 5,
                    Title = "Vacant Lot",
                    IsChecked = false,
                }
                );
        }
    }
}
