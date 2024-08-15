using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PMS.UI.Models.CustomValidation
{
    public class EmailContainsAtSignAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value as string;
            if (email != null)
            {
                // Regular expression to validate email format (basic validation)
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(email, emailPattern))
                {
                    return new ValidationResult("The email must contain a valid domain (e.g., '@gmail.com', '@hotmail.com').");
                }
            }

            return ValidationResult.Success;
        }
    }
}
