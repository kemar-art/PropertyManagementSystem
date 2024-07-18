using Domain.CheckBox.ServiceRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedConfig.CheckBox
{
    public class ServiceRequestPropertySeedConfiguration : IEntityTypeConfiguration<ServiceRequestItem>
    {
        public void Configure(EntityTypeBuilder<ServiceRequestItem> builder)
        {
            builder.HasData(
                new ServiceRequestItem
                {
                    Id = 1,
                    Title = "VALUATION",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 2,
                    Title = "LAND SURVEYOR",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 3,
                    Title = "LEGAL REPRESENTATION",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 4,
                    Title = "SALES/RENTALS",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 5,
                    Title = "AUCTION",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 6,
                    Title = "PROPERTY MANAGEMENT",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 7,
                    Title = "STRUCTURAL SURVEY",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 8,
                    Title = "CONSTRUCTION ESTIMATE",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 9,
                    Title = "GENERAL CONTRACTOR",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = 10,
                    Title = "OTHER",
                    IsChecked = false,
                }
                );
        }
    }
}
