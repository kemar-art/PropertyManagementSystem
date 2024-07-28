
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
    public class ServiceRequestPropertySeedConfiguration : IEntityTypeConfiguration<ServiceRequestItem>
    {
        public void Configure(EntityTypeBuilder<ServiceRequestItem> builder)
        {
            builder.HasData(
                new ServiceRequestItem
                {
                    Id = new Guid("8a7f9203-3906-41ea-8345-de258ff9d23a"),
                    Title = "VALUATION",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("3f2bd4ce-b418-43f2-8cc6-58096bafbf92"),
                    Title = "LAND SURVEYOR",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("7bc822a4-0b9f-4783-94e2-536b4833d4e6"),
                    Title = "LEGAL REPRESENTATION",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("c464358d-7c96-40b5-9530-8596796bfecc"),
                    Title = "SALES/RENTALS",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("db1069d2-7ba8-4ead-89d9-c2ad3c4805ca"),
                    Title = "AUCTION",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("23d13fcf-3e3c-46b1-aad3-02e0fb63dcd7"),
                    Title = "PROPERTY MANAGEMENT",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("bf8207bc-5c6b-4c01-9559-9b2488b04dcb"),
                    Title = "STRUCTURAL SURVEY",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("d1b9d319-ff21-4a37-842d-a6a0073ef246"),
                    Title = "CONSTRUCTION ESTIMATE",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("75c9ad78-7831-4c87-b83b-4bb51d0ea542"),
                    Title = "GENERAL CONTRACTOR",
                    IsChecked = false,
                },

                new ServiceRequestItem
                {
                    Id = new Guid("a316cb71-7ced-4053-8b05-2078555007c2"),
                    Title = "OTHER",
                    IsChecked = false,
                }
            );
        }
    }
}









