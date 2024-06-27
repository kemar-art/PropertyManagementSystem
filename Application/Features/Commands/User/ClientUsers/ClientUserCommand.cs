using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.Features.Commands.User.ClientUsers
{
    public class ClientUserCommand : IRequest<string>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Date), Display(Name = "D.O.B")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public DateTime DateRegistered{ get; set; } = DateTime.Now;

        public string Role { get; set; } = string.Empty;

    }
}
