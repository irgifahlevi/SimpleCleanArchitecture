﻿using EmployeeManagement.Application.DTOs.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employees.Requests.Comands
{
    public class UpdateEmployeeComand : IRequest<Unit>
    {
        public UpdateEmployeeDto EmployeeDto { get; set; }
    }
}
