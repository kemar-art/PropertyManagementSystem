using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PMS.UI.Models.CustomValidation
{
    public class PhoneNumberFormat : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var phoneNumber = value as string;
            if (phoneNumber != null)
            {
                // Regular expression to validate phone number format (e.g., 122-123-1234)
                var phonePattern = @"^\d{3}-\d{3}-\d{4}$";
                if (!Regex.IsMatch(phoneNumber, phonePattern))
                {
                    return new ValidationResult("The phone number must be in the format 122-123-1234.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
