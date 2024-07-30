using PMS.UI.Contracts.Repository_Interface;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Services.Repository_Implementation.AuthService
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var authService = (IAuthenticationService)validationContext.GetService(typeof(IAuthenticationService));
        var email = value as string;
        var emailExists = authService.IsEmailRegisteredExist(email).Result;

        if (emailExists)
        {
            return new ValidationResult("Email already in use.");
        }

        return ValidationResult.Success;
    }
    }
}
