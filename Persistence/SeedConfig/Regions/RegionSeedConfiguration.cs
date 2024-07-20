using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedConfig.Regions
{
    public class RegionSeedConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasData(
                new Region(new Guid("8c8a6b61-43f9-4b7c-ab58-be16c05762b4"), "Surrey", "Kingston"),
                new Region(new Guid("49ebba81-a529-490c-add9-37046df783f4"), "Surrey", "St. Andrew"),
                new Region(new Guid("67a014d7-dbc6-40e7-a5b8-8eb12edfd68b"), "Surrey", "Portland"),
                new Region(new Guid("5d3bb8cd-bdb8-4752-9a53-b656e2543481"), "Surrey", "St. Thomas"),
                new Region(new Guid("02befa99-5924-4fea-a633-3736e651a2dc"), "Middlesex", "St. Catherine"),
                new Region(new Guid("05b21946-589d-4195-a632-1f0c554206bb"), "Middlesex", "St. Mary"),
                new Region(new Guid("cfcfccac-f17b-4ae2-96af-2a4be6b42ba2"), "Middlesex", "St. Ann"),
                new Region(new Guid("bc5cee4e-a273-4b67-8697-23a489b041fe"), "Middlesex", "Manchester"),
                new Region(new Guid("1d0844ea-761c-4d00-8446-57cbed7d971a"), "Middlesex", "Clarendon"),
                new Region(new Guid("5cc3280f-7a72-4fa0-9452-d320bc5dc000"), "Cornwall", "Hanover"),
                new Region(new Guid("2f020ff7-8b30-48ff-8aff-caf7f18503c2"), "Cornwall", "Westmoreland"),
                new Region(new Guid("d6b104f3-693f-4c43-8035-21661b61a82b"), "Cornwall", "St. James"),
                new Region(new Guid("957748c0-ba86-4764-b8c7-a8c0c0bc20c8"), "Cornwall", "Trelawny"),
                new Region(new Guid("e80ac700-0536-476a-8c7e-467a25a13f55"), "Cornwall", "St. Elizabeth")
            );
        }
    }
}
