﻿using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public string TaxRegistrationNumber { get; set; } = string.Empty;
    public string NationalInsuranceScheme { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;

    //public IBrowserFile? Image { get; set; }


    public DateTime DateOfBirth { get; set; } = DateTime.Now;

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date), Display(Name = "Start Date")]
    public DateTime Datestarted { get; set; } = DateTime.Now;

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    [Display(Name = "End Date")]
    public DateTime DateEnded { get; set; } = DateTime.Now;
}
