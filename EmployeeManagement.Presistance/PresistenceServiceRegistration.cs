using EmployeeManagement.Application.Contracts.Presistance;
using EmployeeManagement.Presistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance
{
    public static class PresistenceServiceRegistration
    {
        private static string _connectionString;
        public static IServiceCollection ConfigurePresistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EmployeeManagement");
            services.AddDbContext<EmployeeDbContext>(options => 
                options.UseSqlServer(_connectionString));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
