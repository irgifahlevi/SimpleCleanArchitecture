using AutoMapper;
using EmployeeManagement.Application.DTOs.Employee.Validators;
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
    public class UpdateEmployeeComandHandler : IRequestHandler<UpdateEmployeeComand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeComandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateEmployeeComand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEmployeeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeeDto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var employeeId = await _employeeRepository.Get(request.EmployeeDto.Id);

            if(employeeId == null)
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeDto.Id);
            }

            _mapper.Map(request.EmployeeDto, employeeId);

            await _employeeRepository.Update(employeeId);
            return Unit.Value;
        }
    }
}
