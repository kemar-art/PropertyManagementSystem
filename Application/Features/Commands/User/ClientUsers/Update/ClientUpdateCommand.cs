using Application.Features.Queries.Admin.Users.AppUsers.GetASingleUser;
using Domain;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ClientUsers.Update
{
    public class ClientUpdateCommand : IRequest<BaseResult<Unit>>
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        public Guid? ClientRegionId { get; set; }
    }
}
