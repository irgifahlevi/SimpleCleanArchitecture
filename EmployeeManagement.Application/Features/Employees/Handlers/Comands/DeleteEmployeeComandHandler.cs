using AutoMapper;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Application.Features.Employees.Requests.Comands;
using EmployeeManagement.Application.Contracts.Presistance;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Handlers.Comands
{
    public class DeleteEmployeeComandHandler : IRequestHandler<DeleteEmployeeComand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public DeleteEmployeeComandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteEmployeeComand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.Get(request.Id);

            if(employee == null) 
            {
                throw new NotFoundException("Please check your data request");
            }

            await _employeeRepository.Delete(employee);

            return Unit.Value;
        }
    }
}
