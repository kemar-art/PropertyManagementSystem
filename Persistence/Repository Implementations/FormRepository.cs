﻿using Application.Contracts.ILogging;
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





    public async Task<IEnumerable<Form>> GetAllFroms()
    {
        return await _dbContext.Forms.AsNoTracking()
                                     .OrderBy(x => x.CustomerId)
                                     .ToListAsync();
    }

    public async Task<TrackFormResult> TrackForm(int formId)
    {
        // Check if HttpContext is available
        if (_httpContextAccessor.HttpContext == null)
        {
            // Log or handle the missing HttpContext
            throw new InvalidOperationException("HttpContext is not available.");
        }

        // Retrieve the user email claim
        var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        // Log the retrieved email or the lack of it
        if (string.IsNullOrEmpty(userEmail))
        {
            // Log the missing email claim
            throw new InvalidOperationException("User email claim not found.");
        }

        // Query the database for the form with the provided formId and user email
        var form = await _dbContext.Forms.FirstOrDefaultAsync(x => x.CustomerId == formId && x.Email == userEmail);

        if (form != null)
        {
            return new TrackFormResult
            {
                Exists = true,
                Message = "Form found.",
                Status = form.Status
            };
        }
        else
        {
            return new TrackFormResult { Exists = false, Message = "Form not found." };
        }
    }


    public async Task<Unit> UpdateFrom(Form updateForm)
    {
        // Attach the entity to the context and mark it as modified
        _dbContext.Entry(updateForm).State = EntityState.Modified;

        // Ensure that the identity column is not marked as modified
        _dbContext.Entry(updateForm).Property(f => f.CustomerId).IsModified = false;

        await _dbContext.SaveChangesAsync();

        return Unit.Value;
    }

}


