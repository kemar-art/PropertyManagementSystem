using Application.Contracts.Repository_Interface;
using Domain;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        public RegionRepository(PMSDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
