using EmployeeManagement.Application.Contracts.Infastructure;
using EmployeeManagement.Application.Models;
using EmployeeManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        private static IConfiguration _emailSettings;
        public static IServiceCollection ConfigurationInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            _emailSettings = configuration.GetSection("EmailSettings");
            services.Configure<EmailSettings>(_emailSettings);
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
