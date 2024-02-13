using EmployeeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Presistance.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
