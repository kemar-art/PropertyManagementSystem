﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PMS.UI.Services.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PMS.UI.Models.Form
{
    public class FormVM
    {
        public Guid Id { get; set; }

        public int CustomerId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string InstructionsIssuedBy { get; set; } = string.Empty;

        public string PropertyAddress { get; set; } = string.Empty;

        public string PropertyDirection { get; set; } = string.Empty;

        public string Volume { get; set; } = string.Empty;

        public string Folio { get; set; } = string.Empty;

        public string StrataPlan { get; set; } = string.Empty;

        public string IsKeyAvailable { get; set; } = string.Empty;

        public string MortgageInstitution { get; set; } = string.Empty;

        public string Other { get; set; } = string.Empty;

        public string SecondaryContactFirstName { get; set; } = string.Empty;

        public string SecondaryContactLastName { get; set; } = string.Empty;

        public string SecondaryContactEmail { get; set; } = string.Empty;

        public string SecondaryContactPhoneNumber { get; set; } = string.Empty;

        [ForeignKey("RegionId")]
        public Region? Region { get; set; }
        public Guid RegionId { get; set; }

        public string TypeOfPropertySelectedIds { get; set; } = string.Empty;
        public string ServiceRequestItemSelectId { get; set; } = string.Empty;
        public string PurposeOfValuationItemSelectedIds { get; set; } = string.Empty;
    }
}
