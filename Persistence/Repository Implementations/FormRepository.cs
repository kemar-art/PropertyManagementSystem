using Application.Contracts.ILogging;
using Application.Exceptions;
using Application.Features.Commands.Admin;
using Application.Features.Commands.ClientForm.CreateForm;
using Application.Features.Commands.ClientForm.UpdateForm;
using Application.Features.Queries.ClientForm.GetAllForms;
using Application.StaticDetails;
using AutoMapper;
using Domain;
using Domain.Repository_Interface;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations;

public class FormRepository : GenericRepository<Form>, IFormRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor; // Changed HttpContextAccessor to IHttpContextAccessor
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAppLogger<FormRepository> _appLogger;
    private readonly IMapper _mapper;


    public FormRepository(PMSDatabaseContext dbContext, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IAppLogger<FormRepository> appLogger, IMapper mapper) : base(dbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _appLogger = appLogger;
        _mapper = mapper;
    }

    public async Task<Guid> CreateFrom(CreateFormCommand createForm)
    {
        try
        {
            var formToCreate = _mapper.Map<Form>(createForm);
            formToCreate.Status = FormStatus.StatusSubmitted;
            formToCreate.DateCreated = DateTime.Now;

            await CreateAsync(formToCreate);

            await _dbContext.SaveChangesAsync();

            return formToCreate.Id;
        }
        catch (DbUpdateException ex)
        {
            var innerExceptionMessage = ex.InnerException?.Message;
            var errorMessage = $"An error occurred while saving changes for the form. " +
                               $"Inner Exception: {innerExceptionMessage}. " +
                               $"Form Details: {JsonSerializer.Serialize(createForm)}";

            // Log the detailed error message
            _appLogger.LogError(errorMessage, ex);

            // Return an empty Guid to indicate failure
            return Guid.Empty;
        }
        catch (Exception ex)
        {
            var errorMessage = $"An unexpected error occurred while creating the form. Exception: {ex.Message}";

            // Log the generic error
            _appLogger.LogError(errorMessage, ex);

            // Return an empty Guid to indicate failure
            return Guid.Empty;
        }
    }

    public async Task<IEnumerable<Form>> GetAllForms()
    {
        try
        {
            _appLogger.LogInformation("Retrieving all forms from the database.");

            var forms = await _dbContext.Forms.AsNoTracking()
                                              .OrderBy(x => x.CustomerId)
                                              .ToListAsync();

            _appLogger.LogInformation($"Retrieved {forms.Count} forms from the database.");
            return forms;
        }
        catch (Exception ex)
        {
            _appLogger.LogError("An error occurred while retrieving all forms.", ex);
            return [];
        }
    }


    public async Task<TrackFormResult> TrackForm(int formId)
    {
        // Check if HttpContext is available
        if (_httpContextAccessor.HttpContext == null)
        {
            _appLogger.LogError("HttpContext is not available.");
            return new TrackFormResult { Exists = false, Message = "Internal error: HttpContext is unavailable." };
        }

        // Retrieve the user email claim
        var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(userEmail))
        {
            _appLogger.LogError("User email claim not found.");
            return new TrackFormResult { Exists = false, Message = "Internal error: User email claim is missing." };
        }

        try
        {
            // Query the database for the form with the provided formId and user email
            var form = await _dbContext.Forms.FirstOrDefaultAsync(x => x.CustomerId == formId && x.Email == userEmail);

            if (form != null)
            {
                _appLogger.LogInformation($"Form with ID {formId} found for user {userEmail}.");
                return new TrackFormResult
                {
                    Exists = true,
                    Message = "Form found.",
                    Status = form.Status
                };
            }
            else
            {
                _appLogger.LogWarning($"Form with ID {formId} not found for user {userEmail}.");
                return new TrackFormResult { Exists = false, Message = "Form not found." };
            }
        }
        catch (Exception ex)
        {
            _appLogger.LogError($"An error occurred while tracking the form with ID {formId} for user {userEmail}.", ex);
            return new TrackFormResult { Exists = false, Message = "An unexpected error occurred while tracking the form." };
        }
    }

    public async Task<Unit> UpdateForm(Form updateForm)
    {
        try
        {
            // Attach the entity to the context and mark it as modified
            _dbContext.Entry(updateForm).State = EntityState.Modified;

            // Ensure that the identity column is not marked as modified
            _dbContext.Entry(updateForm).Property(f => f.CustomerId).IsModified = false;

            await _dbContext.SaveChangesAsync();

            // Return Unit.Value to indicate success
            return Unit.Value;
        }
        catch (Exception ex)
        {
            // Log the error
            _appLogger.LogError("An error occurred while updating the form.", ex);

            // Return Unit.Value to avoid crashing the application
            return Unit.Value;
        }
    }




}


