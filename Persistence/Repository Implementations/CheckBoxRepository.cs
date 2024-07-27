using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Domain.CheckBox.PurposeValuation;
using Domain.CheckBox.ServiceRequest;
using Domain.CheckBox.TypeOfProperty;
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
            //if (serviceRequestList.Count == 0)
            //{
            //    throw new NotFoundException(serviceRequestList, )
            //}
            return serviceRequestList;
        }

        public async Task<List<TypeOfPropertyItem>> GetAllTypeOfPropertyItem()
        {
            var typeOfPropertyList = await _dbContext.TypeOfPropertyItems.AsNoTracking().ToListAsync();
            return typeOfPropertyList;
        }
    }
}
