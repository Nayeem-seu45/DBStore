using DBStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.DataAccess.Data.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOption userEmailOptions);

        Task SendEmailForEmailConfirmation(UserEmailOption userEmailOptions);

        Task SendEmailForForgotPassword(string email, UserEmailOption userEmailOptions);
    }
}
