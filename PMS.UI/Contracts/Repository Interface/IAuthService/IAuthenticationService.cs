using System.ComponentModel.DataAnnotations;

namespace PMS.UI.Contracts.Repository_Interface
{
    public interface IAuthenticationService
    {
        Task<bool> IsAuthenticated(string email, string password);
        Task<bool> IsRegister(string firstName, string lastName, string email, string gender, DateTime dateOfBirth, string password);
        Task Logout();
    }
}