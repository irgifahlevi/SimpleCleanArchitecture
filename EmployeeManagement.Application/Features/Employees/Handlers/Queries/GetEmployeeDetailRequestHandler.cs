using AutoMapper;
using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Features.Employees.Requests.Queries;
using EmployeeManagement.Application.Contracts.Presistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Domain;

namespace EmployeeManagement.Application.Features.Employees.Handlers.Queries
{
    public class GetEmployeeDetailRequestHandler : IRequestHandler<GetEmployeeDetailRequest, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeDetailRequestHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeDetailRequest request, CancellationToken cancellationToken)
        {

            var employeDetail = await _employeeRepository.Get(request.Id);
            if (employeDetail == null)
            {
                throw new NotFoundException("Please check your data request");
            }
            return _mapper.Map<EmployeeDto>(employeDetail);
        }
    }
}
