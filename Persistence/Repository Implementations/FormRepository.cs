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


    public FormRepository(PMSDatabaseContext dbContext, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IAppLogger<FormRepository> appLogger, IMapper mapper) : base(dbContext)
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

        await _dbContext.SaveChangesAsync();

        return formToCreate.Id;
    }

    //public async Task<Unit> UpdateFrom(UpdateFormCommand updateForm)
    //{
        
    //    //Convert incoming entity to domain entity
    //    var formToUpdate = _mapper.Map<Form>(updateForm);

    //    _dbContext.Entry(formToUpdate).State = EntityState.Modified;
    //    await _dbContext.SaveChangesAsync();


    //    return Unit.Value;

    //}
}

//    public async Task<IEnumerable<Form>> GetAllFormsToList()
//    {
//        return await _dbContext.Forms.AsNoTracking().ToListAsync();
//    }
//}

