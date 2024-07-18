using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Services.Base;

namespace PMS.UI.Services.Repository_Implementation
{
    public class RegionRepositoey : IRegionRepositoey
    {
        private readonly IClient _client;

        public RegionRepositoey(IClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Region>> GetAllRegion()
        {
            var getAllRegions = await _client.RegionsAsync();
            return getAllRegions;
        }
    }
}
