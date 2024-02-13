using AutoMapper;
using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Features.Employees.Requests.Queries;
using EmployeeManagement.Application.Presistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Handlers.Queries
{
    public class GetEmployeeListRequestHandler : IRequestHandler<GetEmployeeListRequest, List<EmployeeListDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeListRequestHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeeListDto>> Handle(GetEmployeeListRequest request, CancellationToken cancellationToken)
        {
            var employeeList = await _employeeRepository.GetAll();
            return _mapper.Map<List<EmployeeListDto>>(employeeList);
        }
    }
}
