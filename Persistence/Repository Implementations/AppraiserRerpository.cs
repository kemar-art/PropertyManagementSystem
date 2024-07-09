using Application.Contracts.ILogging;
using Application.Contracts.Repository_Interface;
using Application.Exceptions;
using Application.Features.Commands;
using Application.StaticDetails;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IAppLogger<AppraiserRerpository> _appLogger;

        public AppraiserRerpository(PMSDatabaseContext dbContext, IHttpContextAccessor httpContextAccessor, IAppLogger<AppraiserRerpository> appLogger) : base(dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _appLogger = appLogger;
        }

        public async Task<Unit> AcceptTheFormThatWasAssigned(int? acceptFromId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
            if (userId == null)
            {
                _appLogger.LogWarning("User ID not found in the context.");
                throw new UnauthorizedAccessException("User ID was not found.");
            }

            _appLogger.LogInformation($"Starting to accept form with ID {acceptFromId} for user {userId}.");

            var formFromDb = await _dbContext.Forms.FirstOrDefaultAsync(q => q.Id == acceptFromId);
            if (formFromDb == null)
            {
                _appLogger.LogWarning($"Form with ID {acceptFromId} not found in the database.");
                throw new KeyNotFoundException($"Form with ID {acceptFromId} not found.");
            }

            try
            {
                if (formFromDb.AppraiserId == userId)
                {
                    _appLogger.LogInformation($"User {userId} is the assigned appraiser for form {acceptFromId}. Accepting form...");

                    formFromDb.FromAccepted = DateTime.Now;
                    formFromDb.Status = FormStatus.StatusAccepted;

                    _dbContext.Update(formFromDb);
                    await _dbContext.SaveChangesAsync();

                    _appLogger.LogInformation($"Form {acceptFromId} accepted successfully by user {userId}.");

                    return Unit.Value;
                }
                else
                {
                    _appLogger.LogWarning($"User {userId} is not the assigned appraiser for form {acceptFromId}. No changes made.");
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while accepting form {acceptFromId} for user {userId}.", ex);               
            }

            throw new BadRequestException("An error occurred while accepting this job. Please refresh and try again.");
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

        public async Task<Unit> RejectTheFormThatWasAssigned(int? rejectFromId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
            if (userId == null)
            {
                _appLogger.LogWarning("User ID not found in the context.");
                throw new UnauthorizedAccessException("User ID not found in the context.");
            }

            _appLogger.LogInformation($"Starting to reject form with ID {rejectFromId} for user {userId}.");

            var formFromDb = await _dbContext.Forms.FirstOrDefaultAsync(q => q.Id == rejectFromId);
            if (formFromDb == null)
            {
                _appLogger.LogWarning($"Form with ID {rejectFromId} not found in the database.");
                throw new KeyNotFoundException($"Form with ID {rejectFromId} not found.");
            }

            try
            {
                if (formFromDb.AppraiserId == userId)
                {
                    _appLogger.LogInformation($"User {userId} is the assigned appraiser for form {rejectFromId}. Rejecting form...");

                    formFromDb.RejectedForm = DateTime.Now;
                    formFromDb.Status = FormStatus.StatusRejected;

                    _dbContext.Update(formFromDb);
                    await _dbContext.SaveChangesAsync();

                    _appLogger.LogInformation($"Form {rejectFromId} rejected successfully by user {userId}.");

                    return Unit.Value;
                }
                else
                {
                    _appLogger.LogWarning($"User {userId} is not the assigned appraiser for form {rejectFromId}. No changes made.");
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError($"An error occurred while rejecting form {rejectFromId} for user {userId}.", ex);
                
            }

            throw new BadHttpRequestException("An error occurred while rejecting this job. Please refresh and try again.");
        }

    }
}
