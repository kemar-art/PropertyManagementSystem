using PMS.UI.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Contracts.Repository_Interface
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(string email, string password);
        Task<bool> IsRegister(RegisterVM registerVM);
        Task Logout();
    }
}