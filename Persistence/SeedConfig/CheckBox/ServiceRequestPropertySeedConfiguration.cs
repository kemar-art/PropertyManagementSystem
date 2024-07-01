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
    public class ServiceRequestPropertySeedConfiguration : IEntityTypeConfiguration<ServiceRequestCheckBoxProperty>
    {
        public void Configure(EntityTypeBuilder<ServiceRequestCheckBoxProperty> builder)
        {
            builder.HasData(
                new ServiceRequestCheckBoxProperty
                {
                    Id = 1,
                    Title = "VALUATION",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 2,
                    Title = "LAND SURVEYOR",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 3,
                    Title = "LEGAL REPRESENTATION",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 4,
                    Title = "SALES/RENTALS",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 5,
                    Title = "AUCTION",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 6,
                    Title = "PROPERTY MANAGEMENT",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 7,
                    Title = "STRUCTURAL SURVEY",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 8,
                    Title = "CONSTRUCTION ESTIMATE",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 9,
                    Title = "GENERAL CONTRACTOR",
                    IsChecked = false,
                },

                new ServiceRequestCheckBoxProperty
                {
                    Id = 10,
                    Title = "OTHER",
                    IsChecked = false,
                }
                );
        }
    }
}
