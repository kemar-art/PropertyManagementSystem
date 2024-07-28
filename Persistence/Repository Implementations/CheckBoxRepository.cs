using Application.Contracts.Repository_Interface;
using Domain.CheckBoxItems;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations
{
    public class CheckBoxRepository : ICheckBoxRepository
    {
        private readonly PMSDatabaseContext _dbContext;

        public CheckBoxRepository(PMSDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PurposeOfValuationItem>> GetAllPurposeOfValuationItem()
        {
            var purposeOfValuationList = await _dbContext.PurposeOfValuationItems.AsNoTracking().ToListAsync();
            return purposeOfValuationList;
        }

        public async Task<List<ServiceRequestItem>> GetAllServiceRequestItem()
        {
            var serviceRequestList = await _dbContext.ServiceRequestItems.AsNoTracking().ToListAsync();
            return serviceRequestList;
        }

        public async Task<List<TypeOfPropertyItem>> GetAllTypeOfPropertyItem()
        {
            var typeOfPropertyList = await _dbContext.TypeOfPropertyItems.AsNoTracking().ToListAsync();
            return typeOfPropertyList;
        }
    }
}
