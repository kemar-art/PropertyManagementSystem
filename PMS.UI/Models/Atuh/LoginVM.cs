﻿using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Models.Atuh
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
