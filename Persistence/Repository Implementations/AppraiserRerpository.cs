using Application.Contracts.Repository_Interface;
using Application.StaticDetails;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations
{
    public class AppraiserRerpository : GenericRepository<Form>, IAppraiserRerpository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppraiserRerpository(PMSDatabaseContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Form>> GetFormThatWasAssignedToAppraiser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;

            List<string> statusList = new()
            {
                FormStatus.StatusAssigned,
                FormStatus.StatusAccepted,
                FormStatus.StatusInProcess,
                FormStatus.StatusApproved,
                FormStatus.StatusReturnToAppraiser,
                FormStatus.StatusSubmitForApproval,
            };

            return await _dbContext.Forms//.Include(x => x.Region)
                                         .Where(x => x.AppraiserId == userId && statusList
                                         .Contains(x.Status))
                                         .Include(x => x.Appraiser)
                                         //.Include(x => x.ServiceRequestFormServiceRequestItem)
                                         //.ThenInclude(x => x.ServiceRequestItem)
                                         //.Include(x => x.ServiceRequesFormTypeOfPropertyItem)
                                         //.ThenInclude(x => x.TypeOfPropertyItem)
                                         //.Include(x => x.ServiceRequestFormPurposeOfValuationItem)
                                         //.ThenInclude(x => x.PurposeOfValuationItem)
                                         .ToListAsync();
        }
    }
}
