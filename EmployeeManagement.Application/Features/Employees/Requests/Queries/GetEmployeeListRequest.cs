using EmployeeManagement.Application.DTOs.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Requests.Queries
{
    public class GetEmployeeListRequest : IRequest<List<EmployeeListDto>>
    {
    }
}
