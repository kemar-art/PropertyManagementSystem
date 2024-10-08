﻿using PMS.UI.Services.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.UI.Models.Client
{
    public class ClientVM
    {
        public string Id { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public string ImageBase64 { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;
        
        public Guid ClientRegionId { get; set; }

    }


}