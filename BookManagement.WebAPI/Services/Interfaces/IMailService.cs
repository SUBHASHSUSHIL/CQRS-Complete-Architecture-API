using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.WebAPI.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailConfirmationAsync(string email, string confirmatiionLink);
    }
}
