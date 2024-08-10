using PMS.UI.Models.Atuh;
using PMS.UI.Models.Auth;
using PMS.UI.Services.Base;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Contracts.Repository_Interface
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(LoginVM loginVM);
        Task<bool> IsRegister(RegisterVM registerVM);
        Task<bool> IsEmailRegisteredExist(string email);
        Task<AppResponse> ForgetPassword(ForgetPassword passwordResetVM);
        Task<AppResponse> ResetPassword(PasswordReset resetPassword);
        Task Logout();
    }
}