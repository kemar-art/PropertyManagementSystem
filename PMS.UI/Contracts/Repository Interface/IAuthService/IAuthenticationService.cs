using PMS.UI.Models.Atuh;
using PMS.UI.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Contracts.Repository_Interface
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(LoginVM loginVM);
        Task<bool> IsRegister(RegisterVM registerVM);
        Task Logout();
    }
}