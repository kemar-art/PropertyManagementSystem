using Application.Features.Commands.User.ClientUsers.Update;
using Domain;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repository_Interface
{
    public interface IClientRepository
    {
        Task<Unit> UpdateClient(ClientUpdateCommand updateClient, string image);

        Task<ApplicationUser> GetClientById(string userId);
    }
}
