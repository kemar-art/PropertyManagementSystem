using Application.AuthSettings;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.User.ClientUsers.Register
{
    public class ClientRegistrationCommand : IRequest<RegistrationResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Date), Display(Name = "D.O.B")]
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;

        [ForeignKey("ClientRegionId")]
        public Region? ClientRegion { get; set; }
        public Guid? ClientRegionId { get; set; }

    }
}
