using Domain.CheckBoxItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                    Id = new Guid("61817dfe-5a97-4bc1-8f5a-ca92a7637b97"),
                    Title = "Commercial",
                    IsChecked = false,
                },

                new TypeOfPropertyItem
                {
                    Id = new Guid("ce6a20ec-d833-4cee-8301-365c796e7467"),
                    Title = "Residential",
                    IsChecked = false,
                },

                new TypeOfPropertyItem
                {
                    Id = new Guid("d5c0a1ba-4cad-4ec7-a4de-39d7b1e0b723"),
                    Title = "Agricultural",
                    IsChecked = false,
                },

                new TypeOfPropertyItem
                {
                    Id = new Guid("a13c3ef8-1c60-4be9-bc68-947e93f1ed7c"),
                    Title = "Industrial",
                    IsChecked = false,
                },

                new TypeOfPropertyItem
                {
                    Id = new Guid("0f60350d-072b-43f8-9026-9896cd0b601f"),
                    Title = "Vacant Lot",
                    IsChecked = false,
                }
            );
        }
    }
}




