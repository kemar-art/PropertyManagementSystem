using Application.Contracts.ILogging;
using Application.Exceptions;
using Application.Features.Commands.Admin;
using Application.Features.Commands.ClientForm.CreateForm;
using Application.StaticDetails;
using AutoMapper;
using Domain;
using Domain.CheckBox;
using Domain.CheckBox.PurposeValuation;
using Domain.CheckBox.ServiceRequest;
using Domain.CheckBox.TypeOfProperty;
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

    public List<FormTypeOfPropertyItem> ServiceRequesFormTypeOfPropertyItem = [];

    public List<FormServiceRequestItem> ServiceRequestFormServiceRequestItem = [];

    public List<FormPurposeOfValuationItem> ServiceRequestFormPurposeOfValuationItem = [];


    public List<CheckBoxPropertyDto> TypeOfPropertyCheckBoxItemDto { get; set; } = [];

    public List<CheckBoxPropertyDto> ServiceRequestCheckBoxesDto { get; set; } = [];

    public List<CheckBoxPropertyDto> PurposeOfEvaluationCheckBoxesDto { get; set; } = [];

    public FormRepository(PMSDatabaseContext dbContext, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IAppLogger<FormRepository> appLogger,IMapper mapper) : base(dbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
        _appLogger = appLogger;
        _mapper = mapper;
    }

    public async Task<int> CreateFrom(CreateFormCommand createForm)
    {
        var formToCreate = _mapper.Map<Form>(createForm);
        formToCreate.Status = FormStatus.StatusSubmitted;
        formToCreate.DataCreated = DateTime.Now;

        await CreateAsync(formToCreate);

        //Find all the checkboxes that was checked by user (For Service Resquest)
        foreach (var item in ServiceRequestCheckBoxesDto)
        {
            if (item.IsChecked == true)
            {
                ServiceRequestFormServiceRequestItem.Add(new FormServiceRequestItem() { FormId = formToCreate.Id, ServiceRequestItemId = item.Id });
            }
        }
        //Saving all the checkboxes that was checked to database (For Service Resquest)
        foreach (var item in ServiceRequestFormServiceRequestItem)
        {
            _dbContext.ServiceRequestFormServiceRequestItems.Add(item);
        }

        //Find all the checkboxes that was checked by user (For Type Of Property)
        foreach (var item in TypeOfPropertyCheckBoxItemDto)
        {
            if (item.IsChecked == true)
            {
                ServiceRequesFormTypeOfPropertyItem.Add(new FormTypeOfPropertyItem() { FormId = formToCreate.Id, TypeOfPropertyItemId = item.Id });
            }
        }
        //Saving all the checkboxes that was checked to database (For Type Of Property)
        foreach (var item in ServiceRequesFormTypeOfPropertyItem)
        {
            _dbContext.ServiceRequesFormTypeOfPropertyItems.Add(item);
        }

        //Find all the checkboxes that was checked by user (For Purpsoe Of Evaluation)
        foreach (var item in PurposeOfEvaluationCheckBoxesDto)
        {
            if (item.IsChecked == true)
            {
                ServiceRequestFormPurposeOfValuationItem.Add(new FormPurposeOfValuationItem() { FormId = formToCreate.Id, PurposeOfValuationItemId = item.Id });
            }
        }
        //Saving all the checkboxes that was checked to database (For Purpsoe Of Evaluation)
        foreach (var item in ServiceRequestFormPurposeOfValuationItem)
        {
            _dbContext.ServiceRequestFormPurposeOfValuationItems.Add(item);
        }

        await _dbContext.SaveChangesAsync();

        return formToCreate.Id;
    }
}

