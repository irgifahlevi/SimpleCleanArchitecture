using AutoMapper;
using EmployeeManagement.Application.DTOs.Employee.Validators;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Application.Features.Employees.Requests.Comands;
using EmployeeManagement.Application.Contracts.Presistance;
using EmployeeManagement.Application.Response;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.Contracts.Infastructure;
using EmployeeManagement.Application.Models;

namespace EmployeeManagement.Application.Features.Employees.Handlers.Comands
{
    public class CreateEmployeeComandHandler : IRequestHandler<CreateEmployeeComand, BaseComandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateEmployeeComandHandler(IEmployeeRepository employeeRepository, IMapper mapper, IEmailSender emailSender)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseComandResponse> Handle(CreateEmployeeComand request, CancellationToken cancellationToken)
        {
            var response = new BaseComandResponse();
            var validator = new CreateEmployeeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Create failed!";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var employee = _mapper.Map<Employee>(request.EmployeeDto);
            employee = await _employeeRepository.Add(employee);

            response.Success = true;
            response.Message = "Created successfully!";
            response.Id = employee.Id;

            var email = new Email()
            {
                To = "example@gmail.com",
                Body = $"Your data has been success fully added {employee.FirstName} {employee.LastName}",
                Subject = "Create new employee"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch(Exception ex)
            {
                throw;
            }

            return response;
        }
    }
}
