using Application.Features.Commands;
using Domain;
using Domain.Repository_Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repository_Interface
{
    public interface IAppraiserRerpository : IGenericRepository<Form>
    {
        Task<IEnumerable<Form>> GetFormThatWasAssignedToAppraiser();
        Task<Unit> AcceptTheFormThatWasAssigned(int? acceptFromId);
        Task<Unit> RejectTheFormThatWasAssigned(int? rejectFromId);
        Task<Unit> MarkTheFormAsInProcessThatWasAssigned(int? inProcessFromId);
        Task<Unit> SubmitFormForApprovalThatWasAssigned(int? submitFormForApproval,IFormFile frontImage, IFormFile leftimage, IFormFile rightImage, IFormFile backImage);
    }
}
