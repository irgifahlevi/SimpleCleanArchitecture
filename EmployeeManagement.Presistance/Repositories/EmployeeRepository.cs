using EmployeeManagement.Application.Contracts.Presistance;
using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext dbContext) : base(dbContext)
        {
        }

        // Implement another method here
    }
}
