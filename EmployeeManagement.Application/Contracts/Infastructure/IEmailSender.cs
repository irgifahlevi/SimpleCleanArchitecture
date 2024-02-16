using EmployeeManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Contracts.Infastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
