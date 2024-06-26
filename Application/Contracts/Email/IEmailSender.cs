using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task VerificationEmail(string to, string from);

        Task PasswordGeneratorEmail(string to, string from);

        Task JobAlretEmail(string to, string acceptUrl, string rejectUrl);

        Task PasswordResetEmailAsync(string to, string from);
    }
}
