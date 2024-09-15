using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MudBlazor;
using PMS.UI.Contracts.Repository_Interface;
using PMS.UI.Models.Atuh;
using PMS.UI.Models.Auth;
using System.Threading.Tasks;

namespace PMS.UI.Pages
{
    public partial class Login
    {
        public LoginVM loginModel { get; set; }

        protected override async Task OnInitializedAsync()
        {

            loginModel = new LoginVM();


        }



        protected async Task OnValidSubmit()
        {
            // Handle login
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
