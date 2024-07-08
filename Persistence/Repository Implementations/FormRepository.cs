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

    public List<ServiceRequestCheckBox> ServiceRequesChecBoxItems = [];

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

        ////Find all the checkboxes that was checked by user (For Service Resquest)
        //foreach (var item in createForm.ServiceRequestCheckBoxes)
        //{
        //    if (item.IsChecked == true)
        //    {
        //        ServiceRequesChecBoxItems.Add(new ServiceRequestCheckBox() { FormId = formToCreate.Id, ServiceRequestCheckBoxPropertyId = item.Id });
        //    }
        //}

        ////Saving all the checkboxes that was checked to database (For Service Resquest)
        //foreach (var item in ServiceRequesChecBoxItems)
        //{
        //    var serviceRequestCheckBoxProperty = _mapper.Map<ServiceRequestCheckBoxProperty>(item);
        //    _dbContext.ServiceRequestCheckBoxProperties.Add(serviceRequestCheckBoxProperty);
        //}

        //await _dbContext.SaveChangesAsync();

        return formToCreate.Id;
    }
}

