using Application.Contracts.ILogging;
using Application.Exceptions;
using Application.Features.Commands.Admin;
using Application.Features.Commands.ClientForm.CreateForm;
using Application.StaticDetails;
using AutoMapper;
using Domain;
using Domain.CheckBox.ServiceRequest;
using Domain.Repository_Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations;

public class FormRepository : GenericRepository<Form>, IFormRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor; // Changed HttpContextAccessor to IHttpContextAccessor
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAppLogger<FormRepository> _appLogger;
    private readonly IMapper _mapper;
    private readonly IFormRepository _formRepository;

    public List<ServiceRequestCheckBox> ServiceRequesChecBoxItems = [];

    public FormRepository(PMSDatabaseContext dbContext, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IAppLogger<FormRepository> appLogger,IMapper mapper, IFormRepository formRepository) : base(dbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _appLogger = appLogger;
        _mapper = mapper;
        _formRepository = formRepository;
    }

    public async Task<Unit> AssignJob(AssignFormToAppraiserCommand assignFormToAppraiser)
    {
        var formToAssigned = await _dbContext.Forms.FirstOrDefaultAsync(f => f.Id == assignFormToAppraiser.FormId);
        if (formToAssigned != null)
        {
            // Fetch the user ID using the correct claim type
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("uid")?.Value;
            if (userId == null)
            {
                _appLogger.LogError("User not found in the claims.");
                throw new NotFoundException("User not found.", userId);
            }

            // Verify that the JobAssignerId exists 
            var jobAssignerExists = await _userManager.FindByIdAsync(userId);
            if (jobAssignerExists == null)
            {
                _appLogger.LogError($"The Job Assigner Id {userId} does not exist in the AspNetUsers table.");
                throw new NotFoundException("The Job Assigner Id does not exist.", userId);
            }

            // Verify that the AppraiserId exists 
            var appraiserExists = await _userManager.FindByIdAsync(assignFormToAppraiser.AppraiserId);
            if (appraiserExists == null)
            {
                _appLogger.LogError($"The Appraiser Id {assignFormToAppraiser.AppraiserId} does not exist in the AspNetUsers table.");
                throw new NotFoundException("The Appraiser Id does not exist in the AspNetUsers table.", userId);
            }

            formToAssigned.AppraiserId = assignFormToAppraiser.AppraiserId;
            formToAssigned.JobAssignerId = userId;
            formToAssigned.AdminNote = assignFormToAppraiser.AdminNote;
            formToAssigned.Status = FormStatus.StatusAssigned;

            try
            {
                _dbContext.Update(formToAssigned);
                await _dbContext.SaveChangesAsync();
                _appLogger.LogInformation("Form successfully updated.");
                return Unit.Value;
            }
            catch (DbUpdateException ex)
            {
                _appLogger.LogError("An error occurred while saving changes.", ex);
                throw new Exception("An error occurred while saving changes. Please try again later.", ex);
            }
        }

        _appLogger.LogError($"The form with Id {assignFormToAppraiser.FormId} was not found.");
        throw new NotFoundException("The form was not found with the Id value:", formToAssigned.Id);
    }

    public async Task<int> CreateFrom(CreateFormCommand createForm)
    {
        var formToCreate = _mapper.Map<Form>(createForm);
        formToCreate.Status = FormStatus.StatusSubmitted;
        formToCreate.DataCreated = DateTime.Now;

        await _formRepository.CreateAsync(formToCreate);

        //Find all the checkboxes that was checked by user (For Service Resquest)
        foreach (var item in createForm.ServiceRequestCheckBoxes)
        {
            if (item.IsChecked == true)
            {
                ServiceRequesChecBoxItems.Add(new ServiceRequestCheckBox() { FormId = formToCreate.Id, ServiceRequestCheckBoxPropertyId = item.Id });
            }
        }

        //Saving all the checkboxes that was checked to database (For Service Resquest)
        foreach (var item in ServiceRequesChecBoxItems)
        {
            var serviceRequestCheckBoxProperty = _mapper.Map<ServiceRequestCheckBoxProperty>(item);
            _dbContext.ServiceRequestCheckBoxProperties.Add(serviceRequestCheckBoxProperty);
        }

        await _dbContext.SaveChangesAsync();

        return formToCreate.Id;
    }


    public async Task<IEnumerable<Form>> GetFormByStatus(string status)
    {
        return await _dbContext.Forms
                                    //.Include(x => x.Region)
                                    .Where(x => x.Status == status)
                                    .Include(x => x.Appraiser)
                                    //.Include(x => x.ServiceRequestFormServiceRequestItem)
                                    //.ThenInclude(x => x.ServiceRequestItem)
                                    //.Include(x => x.ServiceRequesFormTypeOfPropertyItem)
                                    //.ThenInclude(x => x.TypeOfPropertyItem)
                                    //.Include(x => x.ServiceRequestFormPurposeOfValuationItem)
                                    //.ThenInclude(x => x.PurposeOfValuationItem)
                                    .ToListAsync();
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

