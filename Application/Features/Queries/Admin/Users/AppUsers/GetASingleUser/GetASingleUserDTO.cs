using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Admin.Users.AppUsers.GetASingleUser;

public class GetASingleUserDTO
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    [NotMapped]
    public string ImageBase64 { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    public Guid RegionId { get; set; }
}
