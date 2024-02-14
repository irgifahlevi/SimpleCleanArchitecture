using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs.Employee.Validators
{
    public class IEmployeeDtoValidator : AbstractValidator<IEmployeDto>
    {
        public IEmployeeDtoValidator()
        {
            RuleFor(e => e.EmployeNumber)
            .GreaterThan(0).WithMessage("EmployeNumber must be greater than 0");

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("FirstName is required");

            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(e => e.Address)
                .NotEmpty().WithMessage("Address is required");

            RuleFor(e => e.City)
                .NotEmpty().WithMessage("City is required");

            RuleFor(e => e.PhoneNumber)
                .GreaterThan(0).WithMessage("PhoneNumber must be greater than 0");

            RuleFor(e => e.Country)
                .NotEmpty().WithMessage("Country is required");
        }
    }
}
