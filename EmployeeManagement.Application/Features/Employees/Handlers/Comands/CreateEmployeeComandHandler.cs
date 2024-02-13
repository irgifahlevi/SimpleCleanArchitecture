using AutoMapper;
using EmployeeManagement.Application.Features.Employees.Requests.Comands;
using EmployeeManagement.Application.Presistance.Contracts;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Handlers.Comands
{
    public class CreateEmployeeComandHandler : IRequestHandler<CreateEmployeeComand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeComandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateEmployeeComand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.EmployeeDto);
            employee = await _employeeRepository.Add(employee);
            return employee.Id;
        }
    }
}
