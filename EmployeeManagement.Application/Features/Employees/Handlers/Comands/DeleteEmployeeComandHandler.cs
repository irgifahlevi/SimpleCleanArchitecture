﻿using AutoMapper;
using EmployeeManagement.Application.Exceptions;
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
    public class DeleteEmployeeComandHandler : IRequestHandler<DeleteEmployeeComand>
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
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            await _employeeRepository.Delete(employee);

            return Unit.Value;
        }
    }
}
